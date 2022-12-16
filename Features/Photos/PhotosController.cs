using Microsoft.AspNetCore.Mvc;

namespace RtspAPI.Features.Photos;

[ApiController]
[Route("[controller]")]
public class PhotosController : ControllerBase
{
    private readonly ILogger<PhotosController> _logger;

    public PhotosController(ILogger<PhotosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public byte[] Get()
    {
        throw new NotImplementedException();
        return Array.Empty<byte>();
    }
}
