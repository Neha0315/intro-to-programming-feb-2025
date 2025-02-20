using Riok.Mapperly.Abstractions;
using System.Runtime.Serialization;

namespace Resources.Api.Resources;


//var response = entityToSave.MapToResponse();
//var response = new ResourceListItemModel

//public static class EnitityMappers
//{

//  public static ResourceListItemModel MapToResponse(this ResourceListItemEntity entity)
//  {
//    return new ResourceListItemModel()
//    {
//      Id = entity.Id,
//      Title = entity.Title,
//      Description = entity.Description,
//      CreatedBy = entity.CreatedBy,
//      CreatedOn = entity.CreatedOn,
//      Link = entity.Link,
//      Tags = entity.Tags
//    };
//  }

//}

[Mapper]
public static partial class EntityMappers
{



  [MapperIgnoreTarget(nameof(ResourceListItemEntity.CreatedBy))]
  [MapValue(nameof(ResourceListItemEntity.Id), Use = nameof(EntityMappers.GetUniqueId))]
  [MapValue(nameof(ResourceListItemEntity.CreatedOn), Use = nameof(EntityMappers.GetCreatedBy))]
  public static partial ResourceListItemEntity MapFromRequestModel(this ResourceListItemCreateModel model);
  public static partial ResourceListItemModel MapToResponse(this ResourceListItemEntity entity);

  public static partial IQueryable<ResourceListItemModel> ProjectToResponse(this IQueryable<ResourceListItemEntity> entity);

  static Guid GetUniqueId() => Guid.NewGuid();

  static DateTimeOffset GetCreatedBy() => DateTimeOffset.UtcNow;
}
