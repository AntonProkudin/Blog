namespace BlogApi.Entities;

public class RecordTbl
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string RecordName { get; set; }
    public string RecordText { get; set; }
    public DateTime TimeCreated { get; set; }
}
