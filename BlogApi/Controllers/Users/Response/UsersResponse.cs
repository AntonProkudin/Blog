namespace BlogApi.Controllers.Users.Response;

public class UsersResponse
{
    public IEnumerable<Functions.User.User> Users { get; set; } = null!;
}
