using BlogApi.Controllers.Comments.Requests;
using BlogApi.Controllers.Comments.Response;
using BlogApi.Controllers.Records.Requests;
using BlogApi.Controllers.Records.Response;
using BlogApi.Functions.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers.Comments;

[Route("api/[controller]")]
public class CommentController : Controller
{
    private readonly IConfiguration _configuration;

    private readonly ICommentFunction _commFunction;
    public CommentController(IConfiguration configuration, ICommentFunction commFunction)
    {
        _configuration = configuration;
        _commFunction = commFunction;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetComments(int idRecord)
    {

        var response = new CommentsResponse
        {
            Comments = await _commFunction.GetComments(idRecord)
        };
        return Ok(response);
    }
    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var response = await _commFunction.DeleteComment(id);
        return Ok(response);
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateComment([FromBody] CreateCommRequest request)
    {
        var response = await _commFunction.CreateComment(request.ForRecordId, request.FromUserId, request.Text);
        return Ok(response);
    }
}
