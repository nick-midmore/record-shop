using RecordShopApp.Models;

namespace RecordShopApp.Client.Models;

public class AlbumDTO
{
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
            Year = dto.Year,
            Genre = dto.Genre,
            Description = dto.Description,
            Stock = dto.Stock
        };
    }
}