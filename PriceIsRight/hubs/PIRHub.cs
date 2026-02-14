using Microsoft.AspNetCore.SignalR;
public class PIRHub : Hub
{
    private static Dictionary<string, ConnectedClient> _connectedClients = new();

    public const string AudienceRole = "Audience";
    public const string HostRole = "Host";
    public const string ContestantRole = "Contestant";
    public const string PlayerRole = "Player";
    public const string WheelGroupOneRole = "WheelGroupOne";
    public const string WheelGroupTwoRole = "WheelGroupTwo";
    public const string ShowcaseRole = "Showcase";       


    public override async Task OnConnectedAsync()
    {
        var client = new ConnectedClient(Context.ConnectionId, "Anonymous");
        _connectedClients.Add(Context.ConnectionId, client);
        await Groups.AddToGroupAsync(Context.ConnectionId, client.Role); 
        Console.WriteLine($"Player {_connectedClients.Count} connected");

        // notify the client
        await Clients.Caller.SendAsync("Connected", "You're connected, please stand by... ");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var client = _connectedClients[Context.ConnectionId];
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, client.Role);
        _connectedClients.Remove(Context.ConnectionId);
        Console.WriteLine($"Player Disconnected");

        await base.OnDisconnectedAsync(exception);
    }

    public async Task PromoteClient(string clientId, string newRole)
    {
        if(!_connectedClients.ContainsKey(clientId)) return;
        var client = _connectedClients[clientId];
        await Groups.RemoveFromGroupAsync(clientId, client.Role);
        client.Role = newRole;
        await Groups.AddToGroupAsync(clientId, newRole);
        Console.WriteLine($"{clientId} promoted to {newRole}");
    }

    public async Task ResetGame()
    {
        foreach (string clientId in _connectedClients.Keys)
        {
            var client = _connectedClients[clientId];
            if(client.Role == HostRole) continue;

            await Groups.RemoveFromGroupAsync(clientId,client.Role);
            client.Role = AudienceRole;
            await Groups.AddToGroupAsync(clientId,AudienceRole);
        }
        await Clients.All.SendAsync("GameReset","A new game is starting, please stand by ... ");
        Console.WriteLine("All clients reset to audience role");
    }

    public async Task RegisterAsHost()
    {
        foreach (var c in _connectedClients.Values)    
            if(c.Role == HostRole) return;

        var client = _connectedClients[Context.ConnectionId];
        client.Role = HostRole;
        await Groups.AddToGroupAsync(Context.ConnectionId, HostRole);
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, AudienceRole);
        Console.WriteLine($"Player {Context.ConnectionId} has been promoted to Host");
        await Clients.Caller.SendAsync("HostRegistered", "You are now the Host");
    }

    public async Task SetName(string name)
    {
        var client = _connectedClients[Context.ConnectionId];
        client.Name = name;

        var names = _connectedClients.Values
            .Select(c => c.Name)
            .ToList();

        await Clients.All.SendAsync("UpdateAudience", names);
    }
}