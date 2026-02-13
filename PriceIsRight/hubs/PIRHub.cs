using Microsoft.AspNetCore.SignalR;
public class PIRHub : Hub
{
    private static Dictionary<string, string> _connectedClients = new();

    public const string AudienceRole = "Audience";
    public const string HostRole = "Host";
    public const string ContestantRole = "Contestant";
    public const string PlayerRole = "Player";
    public const string WheelGroupOneRole = "WheelGroupOne";
    public const string WheelGroupTwoRole = "WheelGroupTwo";
    public const string ShowcaseRole = "Showcase";       


    public override async Task OnConnectedAsync()
    {
        _connectedClients.Add(Context.ConnectionId, AudienceRole);
        await Groups.AddToGroupAsync(Context.ConnectionId, AudienceRole); 
        Console.WriteLine($"Player {_connectedClients.Count} connected");

        // notify the client
        await Clients.Caller.SendAsync("Connected", "You're connected, please stand by... ");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, _connectedClients[Context.ConnectionId]);
        _connectedClients.Remove(Context.ConnectionId);
        Console.WriteLine($"Player Disconnected");

        await base.OnDisconnectedAsync(exception);
    }

    public async Task PromoteClient(string clientId, string newRole)
    {
        if(!_connectedClients.ContainsKey(clientId)) return;

        await Groups.RemoveFromGroupAsync(clientId, _connectedClients[clientId]);
        _connectedClients[clientId] = newRole;
        await Groups.AddToGroupAsync(clientId, newRole);
        Console.WriteLine($"{clientId} promoted to {newRole}");
    }

    public async Task ResetGame()
    {
        foreach (string clientId in _connectedClients.Keys)
        {
            if(_connectedClients[clientId] == HostRole) continue;

            await Groups.RemoveFromGroupAsync(clientId,_connectedClients[clientId]);
            _connectedClients[clientId] = AudienceRole;
            await Groups.AddToGroupAsync(clientId,AudienceRole);
        }
        await Clients.All.SendAsync("GameReset","A new game is starting, please stand by ... ");
        Console.WriteLine("All clients reset to audience role");
    }

    public async Task RegisterAsHost()
    {
        if(_connectedClients.ContainsValue(HostRole)) return;

        _connectedClients[Context.ConnectionId] = HostRole;
        await Groups.AddToGroupAsync(Context.ConnectionId, HostRole);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, AudienceRole);
        Console.WriteLine($"Player {Context.ConnectionId} has been promoted to Host");
        await Clients.Caller.SendAsync("HostRegistered", "You are now the Host");
        
    }
}