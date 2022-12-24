using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Nager.VideoStream;

namespace VideoStreamAPI.Services;

public sealed class VideoStreamService
{
    private readonly VideoStreamClient _videoStreamClient;
    private readonly string _rtspStreamUri;
    private readonly string _workingDirectory;
    private readonly ILogger<VideoStreamService> _logger;

    public VideoStreamService(
        VideoStreamClient videoStreamClient,
        string rtspStreamUri,
        string workingDirectory,
        ILogger<VideoStreamService> logger)
    {
        _videoStreamClient = videoStreamClient;
        _rtspStreamUri = rtspStreamUri;
        _workingDirectory = workingDirectory.TrimEnd('/');
        _logger = logger;
    }

    public async Task<byte[]> CreateImageAsync()
    {
        var inputSource = new StreamInputSource(_rtspStreamUri);
        //var inputSource = new WebcamInputSource("Microsoft® LifeCam HD-3000");

        var cts = new CancellationTokenSource();
        var imagePath = $"{_workingDirectory}/img_{DateTime.Now:yyMMdd_HHmmss}.png";
        _videoStreamClient.NewImageReceived += NewImageReceived;
        
        await _videoStreamClient.StartFrameReaderAsync(inputSource, OutputImageFormat.Png, cts.Token);

        return File.ReadAllBytes(imagePath);

        void NewImageReceived(byte[] imageData)
        {
            try
            {
                File.WriteAllBytes(imagePath, imageData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace); // don't recognize extension method for an exception
            }
            finally
            {
                _videoStreamClient.NewImageReceived -= NewImageReceived;
                cts.Cancel();
            }
        }
    }
}