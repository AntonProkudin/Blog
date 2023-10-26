namespace BlogApi.Controllers.Comments.Response;

public class CommentsResponse
{
    public IEnumerable<Functions.Comment.Comment> Comments { get; set; } = null!;
}
