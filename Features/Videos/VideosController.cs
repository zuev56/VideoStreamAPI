using Microsoft.AspNetCore.Mvc;

namespace RtspAPI.Features.Videos;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{
    private readonly ILogger<VideosController> _logger;

    public VideosController(ILogger<VideosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public byte[] Get()
    {
        throw new NotImplementedException();
        // Async method
        return Array.Empty<byte>();
    }
}
