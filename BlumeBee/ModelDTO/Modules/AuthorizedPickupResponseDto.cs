namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the authorized_pickup module.</summary>
public sealed class AuthorizedPickupResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public string? AdultName { get; set; }

    public string? RelationshipToChild { get; set; }

    public string? PhoneNumber { get; set; }

    public string? IdReference { get; set; }

    public bool? PhotoVerified { get; set; }

    public bool? IsActive { get; set; }

    public string? Remarks { get; set; }

}
