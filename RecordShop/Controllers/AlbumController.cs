using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RecordShop.Models.DTOs;
using RecordShop.Models.Entities;
using RecordShop.Services.Implementations;

namespace RecordShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlbumController(AlbumService service) : ControllerBase
{
    private readonly AlbumService _service = service;

    [HttpGet("health")]
    public ActionResult<string> HealthCheck()
        => (_service.Index() is null) ? NotFound("Controller is not responding") : Ok("Controller health ok");

    [HttpGet]
    public IActionResult GetAlbums()
        => Ok(_service.Index().Select(a => Album.ConvertToDTO(a)));

    [HttpGet("{id}")]
    public IActionResult GetAlbumById(int id)
    {
        var album = _service.IndexById(id);
        return album is not null ? Ok(Album.ConvertToDTO(album)) : NotFound("No album found with given Id");
    }

    [HttpGet("artist/{artist}")]
    public IActionResult GetAlbumsByArtistId(string artist)
    {
        var albums = _service.GetAlbumsByArtistId(artist);
        if (albums is null) return NotFound();
        return Ok(albums.Select(a => Album.ConvertToDTO(a)));
    }

    [HttpPost]
    public IActionResult AddAlbum(Album album)
    {
        if (album == null || !ModelState.IsValid) return BadRequest("Model supplied is invalid/empty");
        var result = _service.AddAlbum(album);
        return result is not null ? Ok(Album.ConvertToDTO(result)) : BadRequest("Operation could not be completed");
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateAlbum(int id, [FromBody] JsonPatchDocument<Album> patch)
    {
        if (patch == null || !ModelState.IsValid) return BadRequest("Model supplied is invalid/empty");
        var result = _service.UpdateAlbum(id, patch);
        return result is not null ? Ok(Album.ConvertToDTO(result)) : BadRequest("Operation could not be completed");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlbum(int id)
    {
        var result = _service.DeleteAlbum(id);
        return result ? Ok(result) : NotFound("No result found with given Id");
    }

}
