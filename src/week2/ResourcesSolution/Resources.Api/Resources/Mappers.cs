using Riok.Mapperly.Abstractions;
using System.Runtime.Serialization;

namespace Resources.Api.Resources;


//var response = entityToSave.MapToResponse();
//var response = new ResourceListItemModel



// Automapper - Jimmy Bogart, used a TON at Progressive (and in my code)
// Mapperly (Riok.Mapperly)

[Mapper]
public static partial class EntityMappers
{
  
  [MapperIgnoreTarget(nameof(ResourceListItemEntity.CreatedBy))]
  [MapperIgnoreTarget(nameof(ResourceListItemEntity.SecurityReviewId))]
  [MapValue(nameof(ResourceListItemEntity.Id), Use = nameof(EntityMappers.GetUniqueId))]
  [MapValue(nameof(ResourceListItemEntity.CreatedOn), Use = nameof(EntityMappers.GetCreatedBy))]
  public static partial ResourceListItemEntity MapFromRequestModel(this ResourceListItemCreateModel model);

  [MapperIgnoreTarget(nameof(ResourceListItemEntity.SecurityReviewId))]
  public static partial ResourceListItemModel MapToResponse(this ResourceListItemEntity entity);

  public static partial IQueryable<ResourceListItemModel> ProjectToResponse(this IQueryable<ResourceListItemEntity> entity);

  static Guid GetUniqueId() => Guid.NewGuid();

  static DateTimeOffset GetCreatedBy() => DateTimeOffset.UtcNow;
}

// Mapping - "If there is a place you want to go, it will get you there you know, it's the map, it's the map it's the map it's the map.

// 1 (n)=> (n + n).toString()  "2"
