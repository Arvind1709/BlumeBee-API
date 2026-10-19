using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the learning_outcome module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class LearningOutcomeRequestDto
{
    public int? ClassId { get; set; }

    public int? DomainId { get; set; }

    [Required]
    [StringLength(255)]
    public string? Milestone { get; set; }

    public string? Description { get; set; }

    [StringLength(50)]
    public string? AgeBand { get; set; }

    public bool? IsActive { get; set; }

}
