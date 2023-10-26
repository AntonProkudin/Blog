namespace BlogApi.Functions.Record;

public interface IRecordFunction
{
    Task<IEnumerable<Record>> GetRecords();
    Task<Record> GetRecord(int recordId);
    Task<IEnumerable<Record>> GetRecordsUser(int userId);
    Task<int> DeleteRecord(int recordId);
    Task<int> ChangeRecord(int recordId, int authorId, string recordName, string recordText, DateTime TimeCreated);
    Task<int> CreateRecord(int authorId, string recordName, string recordText);
}
