using Microsoft.AspNetCore.JsonPatch;
using RecordShop.Data;
using RecordShop.Models.Entities;
using RecordShop.Services.Interfaces;

namespace RecordShop.Services.Implementations;

public class AlbumService(AlbumRepository repo) : IAlbumService
{
    private readonly AlbumRepository _repo = repo;

    public List<Album>? Index()
        => _repo.Index();

    public Album? IndexById(int id)
        => _repo.IndexById(id);

    public Album? AddAlbum(Album album)
        => _repo.AddAlbum(album);

    public Album? UpdateAlbum(int id, JsonPatchDocument<Album> patchDocument)
        => _repo.UpdateAlbum(id, patchDocument);

    public bool DeleteAlbum(int id)
        => _repo.DeleteAlbum(id);
}
