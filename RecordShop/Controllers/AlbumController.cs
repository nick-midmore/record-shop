using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RecordShop.Models;
using System.Reflection.Metadata.Ecma335;

namespace RecordShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController(AlbumRepository repo) : ControllerBase
{
    private readonly AlbumRepository _repository = repo;

    [HttpGet]
    public IActionResult GetAlbums()
        => Ok(_repository.Index());

    [HttpGet("{id}")]
    public IActionResult GetAlbumById(int id)
        => Ok(_repository.IndexById(id));

    [HttpPost]
    public IActionResult AddAlbum(Album album)
        => Ok(_repository.AddAlbum(album));

    [HttpPatch("{id}")]
    public IActionResult UpdateAlbum(int id, [FromBody] JsonPatchDocument patch)
        => Ok(_repository.UpdateAlbum(id, patch));

    [HttpDelete("{id}")]
    public IActionResult DeleteAlbum(int id)
        => Ok(_repository.DeleteAlbum(id));

}
