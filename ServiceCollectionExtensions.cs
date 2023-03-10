using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nager.VideoStream;
using VideoStreamAPI.Services;

namespace VideoStreamAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVideoStreamClient(this IServiceCollection services)
    {
        services.AddScoped<VideoStreamClient>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var ffmpegPath = configuration["FFmpegPath"];
            return new VideoStreamClient(ffmpegPath);
        });

        return services;
    }

    public static IServiceCollection AddRtspImageService(this IServiceCollection services)
    {
        services.AddScoped<RtspImageService>(sp =>
        {
            var videoStreamClient = sp.GetRequiredService<VideoStreamClient>();
            var configuration = sp.GetRequiredService<IConfiguration>();
            var rtspStreamUri = configuration["RtspStreamUri"];
            var workingDirectory = configuration["ImagesDirectory"];
            var logger = sp.GetRequiredService<ILogger<RtspImageService>>();

            return new RtspImageService(videoStreamClient, rtspStreamUri, workingDirectory, logger);
        });

        return services;
    }

    public static IServiceCollection AddVideoFilesProvider(this IServiceCollection services)
    {
        services.AddScoped<VideoFilesProvider>(sp =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var workingDirectory = configuration["VideosDirectory"];
            var videoFilesName = configuration["VideoFilesName"];

            return new VideoFilesProvider(workingDirectory, videoFilesName);
        });

        return services;
    }
}