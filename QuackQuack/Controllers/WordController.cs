using AutoMapper;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace QuackQuack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{
    // readonly IUnitOfWork _unitOfWork;
    readonly ILogger<WordController> _logger;
    // readonly IMapper _mapper;

    // public WordController(IUnitOfWork unitOfWork,
    // IMapper mapper)
    // {
    //     _mapper = mapper;
    //     _unitOfWork = unitOfWork;
    //     _logger = logger;
    // }

    public WordController(ILogger<WordController> logger) { }

    [HttpGet("{word}")]
    public async Task<IActionResult> GetWordDefinition(string word)
    {
        var fetchers = new MediumFetcher(_logger);
        await fetchers.GetPosts("quackquackquack");
        return Ok();
        // var findResult = await _unitOfWork.WordRepository.FindFullDefinition(word);
        // if (findResult.Ok)
        // {
        //     return Ok(_mapper.Map<WordResponse>(findResult.Unwrap()));
        // }

        // return BadRequest(findResult.GetError());
    }

    // [HttpGet("suggest")]
    // public async Task<IActionResult> GetSuggestion(string keyword)
    // {
    //     var findResult = await _unitOfWork.WordRepository.QueryAsync(filter: x => x.Word.StartsWith(keyword),
    //      selector: x => x.Word,
    //      skip: 0,
    //      take: 20,
    //      sort: x => x.Word);

    //     if (findResult.Ok)
    //     {
    //         var result = findResult.Unwrap();
    //         return Ok(result);
    //     }

    //     return Ok(Enumerable.Empty<string>());
    // }
}
