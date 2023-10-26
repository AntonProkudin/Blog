using BlogApi.Entities;
using BlogApi.Functions.Record;
using BlogApi.Functions.User;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Functions.Comment;

public class CommentFunction:ICommentFunction
{

    private readonly BlogContext _blogContext;
    private readonly IUserFunction _userFunction;
    public CommentFunction(BlogContext blogContext, IUserFunction userFunction)
    {
        _userFunction = userFunction;
        _blogContext = blogContext;
    }
    public async Task<IEnumerable<Comment>> GetComments(int idRecord) 
    {
        var entities = await _blogContext.CommentTbl.Where(x => (x.ForRecordId == idRecord)).ToListAsync();
        var result = new List<Comment>();

        foreach (var entity in entities)
        {
            var user = await _userFunction.GetUser(entity.FromUserId);
            var comm = new Comment
            {
                Id = entity.Id,
                ForRecordId = entity.ForRecordId,
                FromUserId = entity.FromUserId,
                Text = entity.Text,
                AuthorComment = user.FirstName + " " + user.LastName,
                CreatedTime = entity.CreatedTime,
            };
            result.Add(comm);
        }
        return result.Select(e => new Comment
        {
            Id = e.Id,
            ForRecordId = e.ForRecordId,
            FromUserId = e.FromUserId,
            Text = e.Text,
            CreatedTime = e.CreatedTime,
            AuthorComment = e.AuthorComment,
        });
    }
    public async Task<int> DeleteComment(int commentId) 
    {
        CommentTbl comm = new CommentTbl() { Id = commentId };

        _blogContext.CommentTbl.Attach(comm);
        _blogContext.CommentTbl.Remove(comm);

        var result = await _blogContext.SaveChangesAsync();

        return result;
    }
    public async Task<int> DeleteCommentsByRecord(int idRecord)
    {
        _blogContext.CommentTbl.RemoveRange(_blogContext.CommentTbl.Where(x => x.ForRecordId == idRecord));
        //db.SaveChanges();
        var result = await _blogContext.SaveChangesAsync();
        return result;



       // var entities = await _blogContext.CommentTbl.Where(x => (x.ForRecordId == idRecord)).ToListAsync();
       // if (entities == null)
       //     return 1;
       // foreach (var entity in entities)
       // {
       // CommentTbl comm = new CommentTbl() { Id = entity.Id };
       //
       // _blogContext.CommentTbl.Remove
       // var result = await _blogContext.SaveChangesAsync();
       // }
       // return 1;
    }
    public async Task<int> CreateComment(int forRecordId, int fromUserId, string text) 
    {
        CommentTbl comm = new CommentTbl()
        {
            ForRecordId = forRecordId,
            FromUserId = fromUserId,
            Text = text,
            CreatedTime = DateTime.Now,
        };

        _blogContext.CommentTbl.Add(comm);

        var result = await _blogContext.SaveChangesAsync();
        return result;
    }
}
