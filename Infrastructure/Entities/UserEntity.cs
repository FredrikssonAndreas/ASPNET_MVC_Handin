using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    public int? AddressID { get; set; }

    public AddressEntity? Address { get; set; }

    public int? OptionalInfoID { get; set; }

    public OptionalInfoEntity? OptionalInfo { get; set; }

}
