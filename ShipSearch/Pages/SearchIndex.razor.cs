using Microsoft.AspNetCore.Components;
using ShipSearch.Models;
using ShipSearch.Services.Impl;

namespace ShipSearch.Pages;

public partial class SearchIndex
{
    [Inject]
    SwapiSearch _swapiSearch { get; set; }

    private IEnumerable<Starship> foundStarships = new List<Starship>();
    private string searchTerm { get; set; }
    private bool isLoading { get; set; }
    private async Task RunSearch()
    {
        isLoading = true;
        foundStarships = await _swapiSearch.SearchStarships(searchTerm);
        isLoading = false;
    }
}