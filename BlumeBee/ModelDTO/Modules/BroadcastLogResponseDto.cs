namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the broadcast_log module.</summary>
public sealed class BroadcastLogResponseDto
{
    public long? Id { get; set; }

    public DateOnly? BroadcastDate { get; set; }

    public string? BroadcastType { get; set; }

    public string? Subject { get; set; }

    public string? MessageBody { get; set; }

    public string? TargetGroup { get; set; }

    public long? SentByStaffId { get; set; }

    public string? Channel { get; set; }

    public string? Remarks { get; set; }

}
