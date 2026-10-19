using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the broadcast_log module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class BroadcastLogRequestDto
{
    [Required]
    public DateOnly? BroadcastDate { get; set; }

    [StringLength(100)]
    public string? BroadcastType { get; set; }

    [StringLength(200)]
    public string? Subject { get; set; }

    public string? MessageBody { get; set; }

    [StringLength(100)]
    public string? TargetGroup { get; set; }

    public long? SentByStaffId { get; set; }

    [StringLength(50)]
    public string? Channel { get; set; }

    public string? Remarks { get; set; }

}
