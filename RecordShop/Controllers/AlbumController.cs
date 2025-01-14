using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Data;
using RecordShop.Models;

namespace RecordShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController(AlbumRepository repo) : ControllerBase
{
    private readonly AlbumRepository _repository = repo;

    [HttpGet("health")]
    public IActionResult HealthCheck()
        => (_repository.Index() is null) ? NotFound("Controller is not responding") : Ok("Controller health ok");

    [HttpGet]
    public IActionResult GetAlbums()
        => Ok(_repository.Index());

    [HttpGet("{id}")]
    public IActionResult GetAlbumById(int id)
    {
        var album = _repository.IndexById(id);
        return album is not null ? Ok(album) : NotFound("No album found with given Id");
    }

    [HttpPost]
    public IActionResult AddAlbum(Album album)
    {
        if (album == null || !ModelState.IsValid) return BadRequest("Model supplied is invalid/empty");
        var result = _repository.AddAlbum(album);
        return result is not null ? Ok(result) : BadRequest("Operation could not be completed");
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateAlbum(int id, [FromBody] JsonPatchDocument<Album> patch)
    {
        if (patch == null || !ModelState.IsValid) return BadRequest("Model supplied is invalid/empty");
        var result = _repository.UpdateAlbum(id, patch);
        return result is not null ? Ok(result) : BadRequest("Operation could not be completed");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlbum(int id)
    {
        var result = _repository.DeleteAlbum(id);
        return result ? Ok(result) : NotFound("No result found with given Id");
    }

}
