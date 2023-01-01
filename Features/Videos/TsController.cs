using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamAPI.Features.Videos;

[ApiController]
[Route("[controller]")]
public class TsController : ControllerBase
{
    private readonly VideoFilesProvider _videoFilesProvider;

    public TsController(VideoFilesProvider videoFilesProvider)
    {
        _videoFilesProvider = videoFilesProvider;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(string fileName)
    {
        var tsBytes = await _videoFilesProvider.GetTsAsync(fileName);
        return File(tsBytes, "application/octet-stream", enableRangeProcessing: true);
    }
}