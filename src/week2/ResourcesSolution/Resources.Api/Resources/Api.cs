using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator, IDocumentSession session, ILogger<Api> _logger) : ControllerBase
{

  [HttpGet("/resources")]
  public async Task<ActionResult> GetAllResources(CancellationToken token)
  {
    
    var response = await session.Query<ResourceListItemEntity>()
     .ProjectToResponse()
       .OrderBy(r => r.CreatedOn)
       .ThenBy(r => r.CreatedBy)
       .ToListAsync(token);
   
    return Ok(response);
  }

  [HttpPost("/resources")]
  public async Task<ActionResult> AddResourceItem(
    [FromBody] ResourceListItemCreateModel request,
    [FromServices] UserInformationProvider userInfo,
  [FromServices] INotifytheSecurityReviewTeam _securityReviewTeam)
  {


    var validations = await validator.ValidateAsync(request);

    if (validations.IsValid == false)
    {
      return BadRequest(validations.ToDictionary()); // more on that later.
    }


    var entityToSave = request.MapFromRequestModel();

   
    entityToSave.CreatedBy = await userInfo.GetUserNameAsync();

    // Distributed Transaction - Both of these things have to happen or neither of them should.
    // "Transactional Outbox"
    // 
    if (request.Tags.Any(t => t == "security"))
    {
      // send an HTTP request to an API that doesn't even exist yet, and take the code that doesn't exist yet, and store it in the database
      // and add a property to the response that says "pendingSecurityReview"
      // WTCYWYH
     
    string securityReviewId = await _securityReviewTeam.NotifyForSecurityReview(entityToSave.Id);
      entityToSave.SecurityReviewId = securityReviewId;

      // TODO: Add Something to the Entity?

    }
   
    session.Store(entityToSave);
    await session.SaveChangesAsync();


    var response = entityToSave.MapToResponse();
    if (entityToSave.SecurityReviewId != null)
    {
      response.IsBeingReviewedForSecurity = true;
    }

 
    return Ok(response);
  }

  // GET /resources/3898398039=93898398983-39879839
  [HttpGet("/resources/{id:guid}")]
  public async Task<ActionResult> GetById(Guid id)
  {
    
    return Ok();
  }
}


public class UserInformationProvider
{
  public async Task<string> GetUserNameAsync()
  {
    return "babs@aol.com"; // for now.
  }
}


public interface INotifytheSecurityReviewTeam
{
  Task<string> NotifyForSecurityReview(Guid id);
}
