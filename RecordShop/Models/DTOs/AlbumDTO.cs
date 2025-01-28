using RecordShop.Models.Entities;

namespace RecordShop.Models.DTOs;

public class AlbumDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Year { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Stock { get; set; }

    public static Album ConvertToAlbum(AlbumDTO dto)
    {
        return new Album()
        {
            Title = dto.Title,
            Artist = dto.Artist,
            Year = int.Parse(dto.Year),
            Genre = dto.Genre,
            Description = dto.Description,
            Stock = new Stock() { Quantity = int.Parse(dto.Stock) }
        };
    }
}
