using BlogApi.Controllers.Records.Requests;
using BlogApi.Controllers.Records.Response;
using BlogApi.Functions.Comment;
using BlogApi.Functions.Record;
using BlogApi.Functions.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers.Records
{
    [Route("api/[controller]")]
    public class RecordController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ICommentFunction _commFunction;
        private readonly IRecordFunction _recordFunction;
        public RecordController(IConfiguration configuration, IRecordFunction recordFunction, ICommentFunction commFunction)
        {
            _configuration = configuration;
            _recordFunction = recordFunction;
            _commFunction = commFunction;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetRecords()
        {
            
            var response = new RecordsResponse
            {
                Records  = await _recordFunction.GetRecords()
                
            };
            return Ok(response);
        }

        [Authorize]
        [HttpGet("ByUser")]//../api/Record/ByUser?id=9
        public async Task<IActionResult> GetRecordsUsers(int id)
        {
            var response = new RecordsResponse
            {
                Records = await _recordFunction.GetRecordsUser(id),

            };
            return Ok(response);
        }
        [Authorize]
        [HttpGet("One")]//../api/Record/ByUser?id=9
        public async Task<IActionResult> GetOneRecord(int id)
        {
            var response = new RecordResponse
            {
                Record = await _recordFunction.GetRecord(id),

            };
            return Ok(response);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var deleteComm = await _commFunction.DeleteCommentsByRecord(id);
            var response = await _recordFunction.DeleteRecord(id);
            return Ok(response);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutRecord([FromBody] Record request)
        {
            var response = await _recordFunction.ChangeRecord(request.Id, request.AuthorId, request.RecordName, request.RecordText, request.TimeCreated);
            return Ok(response);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecord([FromBody] CreateRecordRequest request)
        {
            var response = await _recordFunction.CreateRecord(request.AuthorId, request.RecordName, request.RecordText);
            return Ok(response);
        }
    }
}
