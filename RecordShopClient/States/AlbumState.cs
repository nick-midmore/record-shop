using RecordShopClient.Models;
using RecordShopClient.Utils;
using Spectre.Console;
using System.Text.Json;

namespace RecordShopClient.States;

internal class AlbumState : State
{
    public AlbumState(Application application) : base(application)
    {
    }

    public override async Task Run()
    {
        Console.Clear();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<AlbumOption>()
            .Title("Select an option:")
            .AddChoices(
                AlbumOption.ViewAll,
                AlbumOption.ViewById,
                AlbumOption.AddAlbum,
                AlbumOption.UpdateAlbum,
                AlbumOption.DeleteAlbum,
                AlbumOption.Back
            ));

        switch (option)
        {
            case AlbumOption.ViewAll:
                await ViewAll();
                break;
            case AlbumOption.ViewById:
                await ViewById();
                break;
        }
    }

    private async Task ViewById()
    {
        try
        {
            var id = AnsiConsole.Prompt(new TextPrompt<int>("Enter an album Id"));
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:7280/api/album/{id}");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    var album = JsonSerializer.Deserialize<Album>(message);
                    ViewAlbum(album);
                }
                else
                {
                    Console.WriteLine($"Response error code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}, press any key to continue...");
            Console.ReadKey();
        }
    }

    private async Task ViewAll()
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7280/api/album");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    var albums = JsonSerializer.Deserialize<List<Album>>(message);
                    ListAlbums(albums);
                }
                else
                {
                    Console.WriteLine($"Response error code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}, press any key to continue...");
            Console.ReadKey();
        }

        _application.State = new MenuState(_application);
    }

    private void ViewAlbum(Album album)
    {
        var panel = new Panel($@"Title: {album.Title}
Artist: {album.Artist}
Year: {album.Year}
Genre: {album.Genre}
Description: {album.Description}
Stock: {album.Stock}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 1, 2, 1);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }

    private void ListAlbums(List<Album> albums)
    {
        Console.Clear();
        var table = new Table();
        table.AddColumn("Title");
        table.AddColumn("Artist");
        table.AddColumn("Year");
        table.AddColumn("Genre");
        table.AddColumn("Description");
        table.AddColumn("Stock");
        table.ShowRowSeparators = true;

        foreach (var album in albums)
        {
            table.AddRow(
                album.Title,
                album.Artist,
                album.Year,
                album.Genre,
                album.Description,
                album.Stock);
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        Console.Clear();
    }
}