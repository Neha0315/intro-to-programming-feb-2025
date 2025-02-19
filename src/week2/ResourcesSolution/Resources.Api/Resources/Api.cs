using FluentValidation;
using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Resources.Api.Resources;


// Get a 200 Ok when you do a GET /resources
public class Api(IValidator<ResourceListItemCreateModel> validator, IDocumentSession session) : ControllerBase
{

  [HttpGet("/resources")]
  public async Task<ActionResult> GetAllResources()
  {
    var response = await session.Query<ResourceListItemEntity>()
       .Select(r => new ResourceListItemModel() {

         Id = r.Id,
         CreatedBy = r.CreatedBy,
         CreatedOn = r.CreatedOn,
         Description = r.Description,
         Link = r.Link,
         Tags = r.Tags,
         Title = r.Title,
       }).ToListAsync();
    return Ok(response);
  }

  [HttpPost("/resources")]
  public async Task<ActionResult> AddResourceItem([FromBody] ResourceListItemCreateModel request)
  {

    var validations = await validator.ValidateAsync(request);

    if (validations.IsValid == false)
    {
      return BadRequest(validations.ToDictionary()); // more on that later.
    }

    // Do the "Business Stuff" (this is often the hard part)
    // Create and store an entity in the database

    var entityToSave = new ResourceListItemEntity
    {
      Id = Guid.NewGuid(),
      Description = request.Description,
      Link = request.Link,
      Tags = request.Tags,
      LinkText = request.LinkText,
      Title = request.Title,
      CreatedBy = "sue@aol.com", // slimed for now
      CreatedOn = DateTimeOffset.Now,
    };

    session.Store(entityToSave);
    await session.SaveChangesAsync();



    // From that entity, create a response to send to the requester
    var response = new ResourceListItemModel
    {
      Id = entityToSave.Id,
      Title = entityToSave.Title,
      Description = entityToSave.Description,
      CreatedBy = entityToSave.CreatedBy,
      CreatedOn =entityToSave.CreatedOn,
      Link = entityToSave.Link,
      Tags = entityToSave.Tags
    };

    // TODO: Consider making this a 201 Created. More "nuanced".
    return Ok(response);
  }
}
