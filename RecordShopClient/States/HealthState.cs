namespace RecordShopClient.States;

internal class HealthState : State
{
    public HealthState(Application application) : base(application)
    {
    }

    public override async Task Run()
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7280/api/album/health");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"Response error code: {response.StatusCode}");
                }
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();

            _application.State = new MenuState(_application);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

}