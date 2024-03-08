using Microsoft.AspNetCore.SignalR;

namespace SignalR.API;

public class MyHub : Hub
{
    public static List<string> Names = new List<string>();
    public async Task sendMessage(string name)
    {
        Names.Add(name);
        await Clients.All.SendAsync("ReceiveNames", name);
    }

    public async Task getNames()
    {
        await Clients.All.SendAsync("ReceiveNames", Names);
    }
}
