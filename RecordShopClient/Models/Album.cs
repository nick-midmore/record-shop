using System.Text.Json.Serialization;

namespace RecordShopClient.Models;

public class Album
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("artist")]
    public string Artist { get; set; }
    [JsonPropertyName("genre")]
    public string Genre { get; set; }
    [JsonPropertyName("year")]
    public string Year { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("stock")]
    public string Stock { get; set; }
}