using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_document module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentDocumentRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [Required]
    [StringLength(100)]
    public string? DocumentName { get; set; }

    public bool? Submitted { get; set; }

    public DateOnly? SubmissionDate { get; set; }

    public long? VerifiedByStaffId { get; set; }

    public string? Remarks { get; set; }

}
