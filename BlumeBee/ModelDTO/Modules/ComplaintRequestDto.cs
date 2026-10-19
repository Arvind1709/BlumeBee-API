using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the complaint module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class ComplaintRequestDto
{
    [Required]
    [StringLength(30)]
    public string? ComplaintCode { get; set; }

    [Required]
    public DateOnly? ComplaintDate { get; set; }

    [StringLength(150)]
    public string? ComplaintBy { get; set; }

    [StringLength(30)]
    public string? ReferenceType { get; set; }

    public long? ReferenceId { get; set; }

    [StringLength(100)]
    public string? Category { get; set; }

    public string? Description { get; set; }

    public long? AssignedToStaffId { get; set; }

    public string? ActionTaken { get; set; }

    public DateOnly? ResolutionDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
