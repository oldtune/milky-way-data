using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace QuackQuack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MediumPostController : ControllerBase
{
    readonly ILogger<MediumPostController> _logger;
    readonly MediumConfigurations _mediumConfigs;

    public MediumPostController(ILogger<MediumPostController> logger,
    IOptions<MediumConfigurations> mediumConfigs)
    {
        _logger = logger;

        if (mediumConfigs.Value == null)
        {
            throw new NullReferenceException("Configurations cannot be empty");
        }

        _mediumConfigs = mediumConfigs.Value;
    }

    [HttpGet("")]
    public async Task<IActionResult> GetMediumPosts()
    {
        var mediumFeedFetcher = new MediumFetcher(_logger);
        var post = await mediumFeedFetcher.FetchPosts(_mediumConfigs.Username);
        return Ok(post);
    }
}
