namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the medicine_administration module.</summary>
public sealed class MedicineAdministrationResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public DateOnly? AdministrationDate { get; set; }

    public TimeOnly? AdministrationTime { get; set; }

    public string? MedicineName { get; set; }

    public string? Dosage { get; set; }

    public string? Instruction { get; set; }

    public long? AdministeredByStaffId { get; set; }

    public bool? ParentConsentReceived { get; set; }

    public string? Remarks { get; set; }

}
