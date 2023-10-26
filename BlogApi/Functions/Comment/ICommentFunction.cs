namespace BlogApi.Functions.Comment;

public interface ICommentFunction
{
    Task<IEnumerable<Comment>> GetComments(int idRecord);
    Task<int> DeleteComment(int commentId);
    Task<int> DeleteCommentsByRecord(int recordId);
    Task<int> CreateComment(int forRecordId, int fromUserId, string text);
}
