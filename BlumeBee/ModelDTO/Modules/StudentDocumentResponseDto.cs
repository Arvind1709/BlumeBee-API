namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_document module.</summary>
public sealed class StudentDocumentResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public string? DocumentName { get; set; }

    public bool? Submitted { get; set; }

    public DateOnly? SubmissionDate { get; set; }

    public long? VerifiedByStaffId { get; set; }

    public string? Remarks { get; set; }

}
