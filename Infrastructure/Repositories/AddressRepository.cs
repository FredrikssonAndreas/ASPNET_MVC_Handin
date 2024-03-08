using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class AddressRepository(DataContext context) : Repo<AddressEntity, DataContext>(context)
{
	private readonly DataContext _context = context;
}
