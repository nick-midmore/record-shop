using RecordShop.Models.DTOs;
using System.Text.Json.Serialization;

namespace RecordShop.Models.Entities;

public class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public Stock Stock { get; set; }

    public static AlbumDTO ConvertToDTO(Album a)
    {
        var dto = new AlbumDTO() 
        { 
            Title = a.Title,
            Artist = a.Artist, 
            Year = a.Year.ToString(),
            Description = a.Description, 
            Genre = a.Genre, 
            Stock = a.Stock.Quantity.ToString(),
        };
        return dto;
    }
}