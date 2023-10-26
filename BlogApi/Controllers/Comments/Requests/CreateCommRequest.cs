namespace BlogApi.Controllers.Comments.Requests;

public class CreateCommRequest
{
    public int ForRecordId { get; set; }
    public int FromUserId { get; set; }
    public string Text { get; set; }
}
