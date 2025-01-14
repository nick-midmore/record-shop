using Microsoft.AspNetCore.JsonPatch;
using RecordShop.Models;

namespace RecordShop.Data;

public class AlbumRepository(ShopContext context)
{
    private readonly ShopContext _context = context;
    public List<Album>? Index()
        => _context.Albums.ToList();

    public Album? IndexById(int id)
        => _context.Albums.FirstOrDefault(a => a.Id == id);

    public Album? AddAlbum(Album album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
        return album;
    }

    public Album? UpdateAlbum(int id, JsonPatchDocument<Album> patch)
    {
        var album = IndexById(id);
        patch.ApplyTo(album);
        _context.SaveChanges();
        return album;
    }

    public bool DeleteAlbum(int id)
    {
        var toDelete = IndexById(id);
        if(toDelete != null)
        {
            _context.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}