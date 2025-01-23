using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using RecordShop.Models.Entities;

namespace RecordShop.Data;

public class AlbumRepository(ShopContext context)
{
    private readonly ShopContext _context = context;
    public List<Album>? Index()
        => _context.Albums
        .Include(a => a.Stock)
        .ToList();

    public Album? IndexById(int id)
        => _context.Albums.Include(a => a.Stock).FirstOrDefault(a => a.Id == id);

    public List<Album>? GetAlbumsByArtistId(string artist)
    {
        var albums = Index().Where(a => a.Artist.Contains(artist)).ToList();
        if (albums == null) return null;
        return albums;
    }

    public Album? AddAlbum(Album album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
        return album;
    }

    public Album? UpdateAlbum(int id, JsonPatchDocument<Album> patch)
    {
        var album = IndexById(id);
        if (album == null) return null;
        patch.ApplyTo(album);
        _context.SaveChanges();
        return album;
    }

    public bool DeleteAlbum(int id)
    {
        var toDelete = IndexById(id);
        if (toDelete != null)
        {
            _context.Remove(toDelete);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}