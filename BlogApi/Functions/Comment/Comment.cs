namespace BlogApi.Functions.Comment;

public class Comment
{
    public int Id { get; set; }
    public int ForRecordId { get; set; }
    public int FromUserId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; }
    public string? AuthorComment { get; set;}
}
