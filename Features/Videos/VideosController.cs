using System;
using Microsoft.AspNetCore.Mvc;

namespace VideoStreamAPI.Features.Videos;

[ApiController]
[Route("[controller]")]
public class VideosController : ControllerBase
{
    public VideosController()
    {
    }

    // Async method
    [HttpGet]
    public byte[] Get()
    {
        throw new NotImplementedException();
    }
}