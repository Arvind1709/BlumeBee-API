namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the incident_report module.</summary>
public sealed class IncidentReportResponseDto
{
    public long? Id { get; set; }

    public string? IncidentCode { get; set; }

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

    public string? ClosureStatus { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedAt { get; set; }

}
