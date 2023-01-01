using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamAPI.Features.Videos;

[ApiController]
[Route("[controller]")]
public class M3u8Controller : ControllerBase
{
    private readonly VideoFilesProvider _videoFilesProvider;

    public M3u8Controller(VideoFilesProvider videoFilesProvider)
    {
        _videoFilesProvider = videoFilesProvider;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var m3u8Bytes = await _videoFilesProvider.GetM3u8Async();
        return File(m3u8Bytes, "application/octet-stream", enableRangeProcessing: true);
    }
}