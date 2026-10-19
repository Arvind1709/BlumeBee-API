using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the incident_report module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class IncidentReportRequestDto
{
    [Required]
    [StringLength(30)]
    public string? IncidentCode { get; set; }

    [Required]
    public DateOnly? IncidentDate { get; set; }

    public TimeOnly? IncidentTime { get; set; }

    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public int? IncidentTypeId { get; set; }

    public string? Description { get; set; }

    public int? SeverityId { get; set; }

    public long? ReportedByStaffId { get; set; }

    public string? ImmediateActionTaken { get; set; }

    public bool? FirstAidGiven { get; set; }

    public bool? ParentInformed { get; set; }

    public bool? FollowUpRequired { get; set; }

    [StringLength(50)]
    public string? ClosureStatus { get; set; }

    public string? Remarks { get; set; }

}
