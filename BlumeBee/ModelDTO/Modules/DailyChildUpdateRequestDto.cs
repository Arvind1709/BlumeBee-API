using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the daily_child_update module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class DailyChildUpdateRequestDto
{
    [Required]
    public DateOnly? UpdateDate { get; set; }

    [Required]
    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public int? AttendanceCodeId { get; set; }

    public string? MealNotes { get; set; }

    public string? ToiletingNotes { get; set; }

    public string? NapNotes { get; set; }

    [StringLength(50)]
    public string? Mood { get; set; }

    [StringLength(100)]
    public string? ClassParticipation { get; set; }

    public string? SpecialNote { get; set; }

    [StringLength(150)]
    public string? PickupPerson { get; set; }

    public long? TeacherStaffId { get; set; }

}
