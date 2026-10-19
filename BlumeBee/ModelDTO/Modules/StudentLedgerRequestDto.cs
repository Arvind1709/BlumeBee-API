using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_ledger module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentLedgerRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [Required]
    public DateOnly? EntryDate { get; set; }

    [Required]
    [StringLength(50)]
    public string? EntryType { get; set; }

    [StringLength(50)]
    public string? ReferenceTable { get; set; }

    public long? ReferenceId { get; set; }

    public decimal? DebitAmount { get; set; }

    public decimal? CreditAmount { get; set; }

    public string? Remarks { get; set; }

}
