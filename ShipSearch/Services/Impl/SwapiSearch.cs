using ShipSearch.Models;
using System.Text.Json;

namespace ShipSearch.Services.Impl;

public class SwapiSearch : ISwapiSearch
{
    public async Task<IEnumerable<Starship>> SearchStarships(string searchTerm)
    {
        var nextLink = "https://swapi.dev/api/starships";    
        
        var starships = new List<Starship>();
        
        using var client = new HttpClient();
        while (nextLink != null)
        {
            var response = await client.GetAsync(nextLink);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<StarshipSearchResult>(json);
            starships.AddRange(result.results);
            nextLink = result.next;
        }

        return starships.Where(x => x.name.Contains(searchTerm));
    }
}