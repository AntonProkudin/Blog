namespace BlogApi.Controllers.Records.Response;

public class RecordsResponse
{
    public IEnumerable<Functions.Record.Record> Records { get; set; } = null!;
}
