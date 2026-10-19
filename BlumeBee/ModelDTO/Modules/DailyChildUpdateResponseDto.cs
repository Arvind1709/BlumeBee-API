namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the daily_child_update module.</summary>
public sealed class DailyChildUpdateResponseDto
{
    public long? Id { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public int? AttendanceCodeId { get; set; }

    public string? MealNotes { get; set; }

    public string? ToiletingNotes { get; set; }

    public string? NapNotes { get; set; }

    public string? Mood { get; set; }

    public string? ClassParticipation { get; set; }

    public string? SpecialNote { get; set; }

    public string? PickupPerson { get; set; }

    public long? TeacherStaffId { get; set; }

}
