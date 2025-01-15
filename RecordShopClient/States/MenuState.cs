using RecordShopClient.Utils;
using Spectre.Console;

namespace RecordShopClient.States;

public class MenuState : State
{
    public MenuState(Application application) : base(application)
    {
    }

    public override Task Run()
    {
        Console.Clear();
        var option = AnsiConsole.Prompt(
            new SelectionPrompt<MenuOption>()
            .Title("Select an option:")
            .AddChoices(
                MenuOption.Albums,
                MenuOption.Stock,
                MenuOption.CheckHealth,
                MenuOption.Exit
            ));

        switch(option)
        {
            case MenuOption.Albums:
                _application.State = new AlbumState(_application); 
                break;
            case MenuOption.Stock:
                _application.State = new StockState(_application);
                break;
            case MenuOption.CheckHealth:
                _application.State = new HealthState(_application);
                break;
            case MenuOption.Exit:
                _application.isRunning = false;
                break;
        }
        return Task.CompletedTask;
    }
}