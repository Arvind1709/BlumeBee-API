namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_intervention module.</summary>
public sealed class StudentInterventionResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public string? ConcernType { get; set; }

    public DateOnly? IdentifiedDate { get; set; }

    public string? SupportPlan { get; set; }

    public long? ResponsibleStaffId { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? Status { get; set; }

    public bool? ParentCounsellingNeeded { get; set; }

    public string? Remarks { get; set; }

}
