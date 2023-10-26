namespace BlogApi.Controllers.Records.Requests;

public class CreateRecordRequest
{
    public int AuthorId { get; set; }
    public string RecordName { get; set; }
    public string RecordText { get; set; }
}
