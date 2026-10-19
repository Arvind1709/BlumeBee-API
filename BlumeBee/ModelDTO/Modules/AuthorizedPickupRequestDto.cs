using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the authorized_pickup module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class AuthorizedPickupRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [Required]
    [StringLength(150)]
    public string? AdultName { get; set; }

    [StringLength(80)]
    public string? RelationshipToChild { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [StringLength(100)]
    public string? IdReference { get; set; }

    public bool? PhotoVerified { get; set; }

    public bool? IsActive { get; set; }

    public string? Remarks { get; set; }

}
