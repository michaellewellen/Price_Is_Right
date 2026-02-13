public class Prize 
{
    public int Id {get;set;}
    public string? Tier {get;set;}
    public string? Name {get;set;}
    public decimal MSRP {get;set;}
    public string? ShortDescription {get;set;}   
    public string? LongDescription {get;set;}
    public string? ImageURL {get;set;}
    public bool IsActive {get;set;}

    public Prize ()
    {
        
    }
}