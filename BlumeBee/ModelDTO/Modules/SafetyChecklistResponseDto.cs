namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the safety_checklist module.</summary>
public sealed class SafetyChecklistResponseDto
{
    public long? Id { get; set; }

    public DateOnly? ChecklistDate { get; set; }

    public string? ChecklistItem { get; set; }

    public string? Area { get; set; }

    public string? Status { get; set; }

    public long? CheckedByStaffId { get; set; }

    public string? IssueFound { get; set; }

    public string? CorrectiveAction { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Remarks { get; set; }

}
