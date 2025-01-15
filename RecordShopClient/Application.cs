using RecordShopClient.States;

namespace RecordShopClient;
public class Application
{
    public State State { get; set; }
    public bool isRunning { get; set; } = true;

    public Application()
    {
        State = new MenuState(this);
    }

    public async Task Run()
    {
        while (isRunning)
        {
            await State.Run();
        }
    }
}
