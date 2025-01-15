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
}