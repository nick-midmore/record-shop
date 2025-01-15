using System.Runtime.CompilerServices;

namespace RecordShopClient.States;

public abstract class State
{
    protected Application _application;

    public abstract Task Run();

    public State(Application application)
    {
        _application = application;
    }
}