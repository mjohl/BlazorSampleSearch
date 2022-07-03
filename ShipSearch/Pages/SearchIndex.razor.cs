using Microsoft.AspNetCore.Components;
using ShipSearch.Models;
using ShipSearch.Services.Impl;

namespace ShipSearch.Pages;

public partial class SearchIndex
{
    [Inject] private SwapiSearch _swapiSearch { get; set; }

    private IEnumerable<Starship>? _foundStarships = new List<Starship>();
    private string searchTerm { get; set; }
    private bool isLoading { get; set; }
    private bool errorShow { get; set; }
    private string errorMessage { get; set; }
    
    private async Task RunSearch()
    {
        try
        {
            isLoading = true;
            _foundStarships = await _swapiSearch.SearchStarships(searchTerm);
            isLoading = false;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            errorMessage = e.Message;
            errorShow = true;
            isLoading = false;
        }
    }

    private void ResetError()
    {
        errorMessage = "";
        errorShow = false;
    }
}