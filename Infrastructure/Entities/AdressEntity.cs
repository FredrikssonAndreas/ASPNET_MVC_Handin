namespace Infrastructure.Entities;

public class AdressEntity
{
    public int Id { get; set; } 

    public string AdressLine { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public ICollection<UserEntity> Users { get; set; } = [];
}