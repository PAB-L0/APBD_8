using Labs_8.Contexts;
using Labs_8.Exceptions;
using Labs_8.Models;
using Labs_8.RequestModels;
using Labs_8.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace Labs_8.Services;

public class Service(MyDatabaseContext myDatabaseContext) : IService
{
    public async Task<GetAccountResponseModel> GetAccountById(int id)
    {
        var response = await myDatabaseContext.Accounts.Where(account => account.AccountId == id).Join(myDatabaseContext.Roles, account => account.RoleId,
            role => role.RoleId, (account, role) => new GetAccountResponseModel
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Phone = account.Phone,
                RoleName = role.Name
            }).FirstOrDefaultAsync();

        if (response is null)
        {
            throw new NotFoundException($"Account with id: {id} does not exist");
        }

        var productsResponse = await myDatabaseContext.ShoppingCarts.Where(shoppingCart => shoppingCart.AccountId == id)
            .Join(myDatabaseContext.Products, shoppingCart => shoppingCart.ProductId, product => product.ProductId,
                (shoppingCart, product) => new
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Amount = shoppingCart.Amount
                }).ToListAsync();

        response.Cart = productsResponse;
        return response;
    }

    public async Task<int> CreateProductWithCategories(CreateProductRequestModel productRequestModel)
    {
        var categoryIds = await myDatabaseContext.Categories.Select(category => category.CategoryId).Distinct()
            .ToListAsync();

        if (productRequestModel.ProductCategories is not null && !productRequestModel.ProductCategories.All(productCategory => categoryIds.Contains(productCategory)))
        {
            throw new NotFoundException("Entered product categories do not exist");
        }

        await myDatabaseContext.Products.AddAsync(new Product
        {
            Name = productRequestModel.ProductName,
            Weight = productRequestModel.ProductWeight,
            Width = productRequestModel.ProductWidth,
            Height = productRequestModel.ProductHeight,
            Depth = productRequestModel.ProductDepth
        });

        await myDatabaseContext.SaveChangesAsync();
        
        var productId = await myDatabaseContext.Products.MaxAsync(product => product.ProductId);

        if (productRequestModel.ProductCategories is not null)
        {
            foreach (var categoryId in productRequestModel.ProductCategories)
            {
                await myDatabaseContext.ProductsCategories.AddAsync(new ProductsCategories
                {
                    ProductId = productId,
                    CategoryId = categoryId
                });
            }

            await myDatabaseContext.SaveChangesAsync();    
        }

        return productId;
    }
}