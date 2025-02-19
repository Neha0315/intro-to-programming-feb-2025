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
public static partial class EnityMappers
{

  [MapperIgnoreTarget(nameof(ResourceListItemEntity.Id))]
  [MapperIgnoreTarget(nameof(ResourceListItemEntity.CreatedOn))]
  [MapperIgnoreTarget(nameof(ResourceListItemEntity.CreatedBy))]

  public static partial ResourceListItemEntity MapFromRequestModel(this ResourceListItemCreateModel model);
  public static partial ResourceListItemModel MapToResponse(this ResourceListItemEntity entity);

  public static partial IQueryable<ResourceListItemModel> ProjectToResponse(this IQueryable<ResourceListItemEntity> entity);
}
