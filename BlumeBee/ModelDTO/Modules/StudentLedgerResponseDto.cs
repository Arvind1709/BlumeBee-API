namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_ledger module.</summary>
public sealed class StudentLedgerResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public DateOnly? EntryDate { get; set; }

    public string? EntryType { get; set; }

    public string? ReferenceTable { get; set; }

    public long? ReferenceId { get; set; }

    public decimal? DebitAmount { get; set; }

    public decimal? CreditAmount { get; set; }

    public string? Remarks { get; set; }

}
