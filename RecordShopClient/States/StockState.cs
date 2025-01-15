namespace RecordShopClient.States;

internal class StockState : State
{
    public StockState(Application application) : base(application)
    {
    }

    public override Task Run()
    {
        return Task.CompletedTask;
    }
}