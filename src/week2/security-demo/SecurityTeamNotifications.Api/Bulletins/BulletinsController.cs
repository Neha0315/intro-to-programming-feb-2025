
using Microsoft.AspNetCore.Mvc;

namespace SecurityTeamNotifications.Api.Bulletins;
[ApiController]
public class BulletinsController : ControllerBase
{
    [HttpGet("/bulletins")]

    public async Task<ActionResult<IList<Bulletin>>> GetAllBulletins()
    {
        var bulletins = new List<Bulletin>
        {

            new() { Id = Guid.NewGuid(), Topic = "IdentityServer4", Description = "IdentityServer4 is Being Delisted - Please Don't Use"},
            new() { Id = Guid.NewGuid(), Topic = "Node 18", Description = "Node 18 is EOL"},
            new() { Id = Guid.NewGuid(), Topic = "New Password Policy", Description="Change your Passwords!" }
        };

        return Ok(bulletins);
    }
    
}

public record Bulletin
{
    public Guid Id { get; set; }
    public string Topic { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
}
