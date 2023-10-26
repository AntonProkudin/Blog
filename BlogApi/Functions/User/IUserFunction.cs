namespace BlogApi.Functions.User;

public interface IUserFunction
{
    Task<int> Registrate(string email, string password, string firstname, string lastname);
    Task<User?> Verify(string email, string password);

    //admin
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<int> DeleteUser(int userId);
    Task<int> ChangeUserRole(int userId, string role);
    Task<bool> isAuthor(int userId);
    Task<bool> isAdmin(int userId);

}
