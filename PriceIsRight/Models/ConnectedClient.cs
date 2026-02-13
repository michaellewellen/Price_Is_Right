public class ConnectedClient
{
    public string? ConnectionId { get; set; }
    public string? Name { get; set; }    
    public string? Role { get; set; }

    public ConnectedClient(string connectionId, String name, String role = PIRHub.AudienceRole)
    {
        ConnectionId = connectionId;
        Name = name;
        Role = role;
    }
}