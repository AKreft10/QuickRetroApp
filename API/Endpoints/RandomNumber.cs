namespace Web.Controllers;

public class RandomNumber : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetRandomNumber, "RandomNumber");
    }

    public int GetRandomNumber()
    {
        var rnd = new Random();
        return rnd.Next(1, 10000);
    }
}