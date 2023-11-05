using Microsoft.AspNetCore.Mvc;
using SimonsVoss.CodingCase.Contract.Dto;
using SimonsVoss.CodingCase.Logic;

namespace SimonsVoss.CodingCase.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QueryController : ControllerBase
{
    private readonly IQueryLogic queryLogic;

    public QueryController(IQueryLogic queryLogic)
    {
        this.queryLogic = queryLogic;
    }

    [HttpGet(Name = "GetData")]
    public Task<IActionResult> Get([FromQuery] string searchString)
    {
        var result = this.queryLogic.QueryData(searchString);
        return Task.FromResult<IActionResult>(Ok(result));
    }

    [HttpGet]
    [Route("details")]
    public Task<IActionResult> GetItemDetails([FromQuery] Guid itemId)
    {
        ItemDetails result = this.queryLogic.GetItemDetails(itemId);
        return Task.FromResult<IActionResult>(Ok(result));
    }
}

