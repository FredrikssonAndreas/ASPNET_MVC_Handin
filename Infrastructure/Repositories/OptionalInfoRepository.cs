using Infrastructure.Contexts;
using Infrastructure.Entities;


namespace Infrastructure.Repositories;

public class OptionalInfoRepository(DataContext context) : Repo<OptionalInfoEntity, DataContext>(context)
{
	private readonly DataContext _context = context;
}
