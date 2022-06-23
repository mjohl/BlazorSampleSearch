using ShipSearch.Models;

namespace ShipSearch.Services;

public interface ISwapiSearch
{
    Task<IEnumerable<Starship>?> SearchStarships(string searchTerm);
}