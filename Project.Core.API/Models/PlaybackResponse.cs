using ReportPortal.Client;
using ReportPortal.Shared;
using static Project.Core.API.Models.PlaylistTrackObject;

namespace Project.Core.API.Models;

public record PlaybackResponse
{
    public Device? Device { get; set; }
    public string? RepeatState { get; set; }
    public bool ShuffleState { get; set; }
    public Context? Context { get; set; }
    public long Timestamp { get; set; } 
    public int? ProgressMs { get; set; } 
    public bool IsPlaying { get; set; }
    public string? CurrentlyPlayingType { get; set; }
    public TrackObject? Item { get; set; } 
    public Actions Actions { get; set; }
}

public record Device
{
    public string? Id { get; set; } 
    public bool IsActive { get; set; }
    public bool IsPrivateSession { get; set; }
    public bool IsRestricted { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int? VolumePercent { get; set; }
    public bool SupportsVolume { get; set; }
}

public class Context
{
    public string? Type { get; set; }
    public string? Href { get; set; }
    public ExternalUrls? ExternalUrls { get; set; }
    public string? Uri { get; set; }
}

public class Actions
{
    public bool? InterruptingPlayback { get; set; }
    public bool? Pausing { get; set; }
    public bool? Resuming { get; set; }
    public bool? Seeking { get; set; }
    public bool? SkippingNext { get; set; }
    public bool? SkippingPrev { get; set; }
    public bool? TogglingRepeatContext { get; set; }
    public bool? TogglingShuffle { get; set; }
    public bool? TogglingRepeatTrack { get; set; }
    public bool? TransferringPlayback { get; set; }
}