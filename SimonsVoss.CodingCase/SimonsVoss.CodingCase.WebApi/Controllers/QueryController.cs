using Microsoft.AspNetCore.Mvc;
using SimonsVoss.CodingCase.Logic;

namespace SimonsVoss.CodingCase.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
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
}

