using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the medicine_administration module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class MedicineAdministrationRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [Required]
    public DateOnly? AdministrationDate { get; set; }

    [Required]
    public TimeOnly? AdministrationTime { get; set; }

    [StringLength(150)]
    public string? MedicineName { get; set; }

    [StringLength(100)]
    public string? Dosage { get; set; }

    public string? Instruction { get; set; }

    public long? AdministeredByStaffId { get; set; }

    public bool? ParentConsentReceived { get; set; }

    public string? Remarks { get; set; }

}
