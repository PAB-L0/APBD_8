namespace Labs_8.ResponseModels;

public class GetAccountResponseModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string RoleName { get; set; } = null!;
    public IEnumerable<object>? Cart { get; set; }
}