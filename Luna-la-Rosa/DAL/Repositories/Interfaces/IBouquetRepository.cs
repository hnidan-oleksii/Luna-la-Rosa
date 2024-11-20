using DAL.Entities;
using DAL.Helpers;

namespace DAL.Repositories.Interfaces;

public interface IBouquetRepository : IGenericRepository<Bouquet>
{
	public PagedList<Bouquet> GetBouquets(BouquetParams parameters, IEnumerable<string> searchFields);
}
