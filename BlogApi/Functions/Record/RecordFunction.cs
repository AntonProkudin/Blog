using BlogApi.Entities;
using BlogApi.Functions.User;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogApi.Functions.Record;

public class RecordFunction : IRecordFunction
{
    private readonly BlogContext _blogContext;
    private readonly IUserFunction _userFunction;
    public RecordFunction(BlogContext blogContext, IUserFunction userFunction)
    {
        _userFunction = userFunction;
        _blogContext = blogContext;
    }
    public async Task<int> DeleteRecord(int recordId)
    {
        RecordTbl record = new RecordTbl() { Id = recordId };

        _blogContext.RecordTbl.Attach(record);
        _blogContext.RecordTbl.Remove(record);

        var result = await _blogContext.SaveChangesAsync();

        return result;
    }

    public async Task<IEnumerable<Record>> GetRecords()
    {
        var entities = await _blogContext.RecordTbl.OrderByDescending(x => x.TimeCreated).ToListAsync();
        var result = new List<Record>();

        foreach (var entity in entities)
        {
            var user = await _userFunction.GetUser(entity.AuthorId);
            var record = new Record
            {
                Id = entity.Id,
                AuthorId = entity.AuthorId,
                RecordText = entity.RecordText,
                RecordName = entity.RecordName,
                RecordAuthor = user.FirstName + " " + user.LastName,
                TimeCreated = entity.TimeCreated,
            };
            result.Add(record);
        }
        return result.Select(e => new Record {
            Id = e.Id,
            AuthorId = e.AuthorId,
            RecordName = e.RecordName,
            RecordText = e.RecordText,
            TimeCreated = e.TimeCreated,
            RecordAuthor = e.RecordAuthor,
        });
    }
    public async Task<Record> GetRecord(int recordId)
    {
        var entity = await _blogContext.RecordTbl.Where(x => (x.Id == recordId)).FirstOrDefaultAsync();
        if (entity == null)
            return null;
        var user = await _userFunction.GetUser(entity.AuthorId);
            var result = new Record
            {
                Id = entity.Id,
                AuthorId = entity.AuthorId,
                RecordText = entity.RecordText,
                RecordName = entity.RecordName,
                RecordAuthor = user.FirstName + " " + user.LastName,
                TimeCreated = entity.TimeCreated,
            };

        return result;
    }

    public async Task<int> ChangeRecord(int recordId, int authorId, string recordName, string recordText, DateTime TimeCreated)
    {
        RecordTbl record = new RecordTbl() { 
            Id = recordId,
            AuthorId = authorId,
            RecordName = recordName,
            RecordText = recordText,
            TimeCreated = DateTime.Now,
        };

        _blogContext.RecordTbl.Attach(record);
        _blogContext.RecordTbl.Update(record);

        var result = await _blogContext.SaveChangesAsync();
        return result;
    }
    public async Task<int> CreateRecord(int authorId, string recordName, string recordText)
    {
        RecordTbl record = new RecordTbl()
        {
            AuthorId = authorId,
            RecordName = recordName,
            RecordText = recordText,
            TimeCreated = DateTime.Now,
        };

        _blogContext.RecordTbl.Add(record);

        var result = await _blogContext.SaveChangesAsync();
        return result;
    }

    public async Task<IEnumerable<Record>> GetRecordsUser(int userId)
    {
        var entities = await _blogContext.RecordTbl.Where(x => (x.AuthorId == userId)).ToListAsync();

        return entities.Select(e => new Record
        {
            Id = e.Id,
            AuthorId = e.AuthorId,
            RecordName = e.RecordName,
            RecordText = e.RecordText,
            TimeCreated = e.TimeCreated,
        });
    }
}
