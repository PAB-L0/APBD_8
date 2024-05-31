using Labs_8.Exceptions;
using Labs_8.RequestModels;
using Labs_8.Services;
using Labs_8.Validators;

namespace Labs_8.Endpoints;

public static class MyDatabaseEndpoints
{
    public static void RegisterMyDatabaseEndpoints(this WebApplication webApplication)
    {
        webApplication.MapGet("/accounts/{accountId:int}", GetAccountById);
        webApplication.MapPost("/products", CreateProductWithCategories);
    }

    private static async Task<IResult> GetAccountById(IService service, int accountId)
    {
        try
        {
            return Results.Ok(await service.GetAccountById(accountId));
        }
        catch (NotFoundException notFoundException)
        {
            return Results.NotFound(notFoundException.Message);
        }
    }

    private static async Task<IResult> CreateProductWithCategories(IService service, CreateProductRequestModel productRequestModel, ProductRequestModelValidator validator)
    {
        var validation = await validator.ValidateAsync(productRequestModel);

        if (!validation.IsValid)
        {
            return Results.ValidationProblem(validation.ToDictionary());
        }

        try
        {
            var result = await service.CreateProductWithCategories(productRequestModel);
            return Results.Created($"/products/{result}", result);
        }
        catch (NotFoundException notFoundException)
        {
            return Results.BadRequest(notFoundException.Message);
        }
    }
}