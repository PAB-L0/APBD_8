using Labs_8.RequestModels;
using Labs_8.ResponseModels;

namespace Labs_8.Services;

public interface IService
{
    Task<GetAccountResponseModel> GetAccountById(int id);
    Task<int> CreateProductWithCategories(CreateProductRequestModel productRequestModel);
}