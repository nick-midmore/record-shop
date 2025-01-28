using RecordShopApp.Client.Models;
using System.Text.Json.Serialization;

namespace RecordShopApp.Models;

public class Album
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("artist")]
    public string Artist { get; set; }
    [JsonPropertyName("year")]
    public string Year { get; set; }
    [JsonPropertyName("genre")]
    public string Genre { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("stock")]
    public string Stock { get; set; }

    public static AlbumDTO ConvertToDTO(Album a)
    {
        var dto = new AlbumDTO()
        {
            Title = a.Title,
            Artist = a.Artist,
            Year = a.Year.ToString(),
            Description = a.Description,
            Genre = a.Genre,
            Stock = a.Stock,
        };
        return dto;
    }
}
