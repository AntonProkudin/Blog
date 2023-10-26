using BlogApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Functions.User;

public class UserFunction:IUserFunction
{
    private readonly BlogContext _blogContext;

    public UserFunction(BlogContext blogContext)
    {
        _blogContext = blogContext;
    }
    public async Task<User?> Verify(string email, string password)
    {
        var entity = await _blogContext.UsersTbl
           .Where(x => (x.Email == email))
           .FirstOrDefaultAsync();
        if (entity == null)
            return null;
        var result = new User
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Role = entity.Role,
        };

       if(email == entity.Email && password == entity.Password)
            return result;
       return null;

    }


    public async Task<int> Registrate(string email, string password, string firstName, string lastName)
    {
        var entity = new UserTbl
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };

        _blogContext.UsersTbl.Add(entity);
        var result = await _blogContext.SaveChangesAsync();
        return result;
    }
    public async Task<IEnumerable<User>> GetUsers()
    {
        var entities = await _blogContext.UsersTbl.ToListAsync();

        return entities.Select(x => new User
        {
            Id = x.Id,
            Email = x.Email,
            Password = x.Password,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Role = x.Role,
        });
    }
    public async Task<User> GetUser(int id)
    {
        var entity = await _blogContext.UsersTbl.Where(x => (x.Id == id)).FirstOrDefaultAsync();
        User result = new User
        {
            Id = entity.Id,
            Email = entity.Email,
            Password = entity.Password,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Role = entity.Role,
        };
        return result;
    }
    public async Task<int> DeleteUser(int userId)
    {
        UserTbl user = new UserTbl() { Id = userId };

        _blogContext.UsersTbl.Attach(user);
        _blogContext.UsersTbl.Remove(user);

        var result = await _blogContext.SaveChangesAsync();

        return result;
    }
    public async Task<int> ChangeUserRole(int userId, string role)
    {
        UserTbl user = new UserTbl() { Id = userId };
        user.Role = role;

        _blogContext.UsersTbl.Attach(user);
        _blogContext.UsersTbl.Update(user);

        var result = await _blogContext.SaveChangesAsync();
        return result;
    }
    public async Task<bool> isAuthor(int userId)
    {
        bool result = false;
        var user = await _blogContext.UsersTbl.Where(x => (x.Id == userId)).FirstOrDefaultAsync();

        if (user == null)
            return result;

        if (user.Role == "admin" || user.Role =="author")
            result = true;

        return result;
    }
    public async Task<bool> isAdmin(int userId)
    {
        bool result = false;
        var user = await _blogContext.UsersTbl.Where(x => (x.Id == userId)).FirstOrDefaultAsync();
       
        if (user == null)
            return result;
        
        if (user.Role == "admin")
            result = true;

        return result;
    }
}
