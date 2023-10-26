namespace BlogApi.Entities;

public class CommentTbl
{
    public int Id { get; set; }
    public int ForRecordId { get; set; }
    public int FromUserId { get; set; }
    public string Text { get; set; }
    public DateTime CreatedTime { get; set; }
}
