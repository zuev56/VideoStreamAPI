using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoStreamAPI.Services;

namespace VideoStreamAPI.Features.Photos;

[ApiController]
[Route("[controller]")]
public class PhotosController : ControllerBase
{
    private readonly VideoStreamService _videoStreamService;

    public PhotosController(VideoStreamService videoStreamService)
    {
        _videoStreamService = videoStreamService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var imageData = await _videoStreamService.CreateImageAsync();
        return File(imageData, "image/png");
    }
}
