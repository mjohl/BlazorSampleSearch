namespace ShipSearch.Models;

public class StarshipSearchResult
{
    public int count { get; set; }
    public string next { get; set; }
    public object previous { get; set; }
    public List<Starship> results { get; set; }
}