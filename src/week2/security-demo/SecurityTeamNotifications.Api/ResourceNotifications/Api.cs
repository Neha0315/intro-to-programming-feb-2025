namespace SecurityTeamNotifications.Api.ResourceNotifications;

public static class Api
{
  public static IEndpointRouteBuilder MapResourceNotifications(this IEndpointRouteBuilder builder)
  {
    builder.MapPost("/resources-notifications", (ResourceNotificationCreateModel request) =>
    {
      var response = new ResourceNotificationResponseModel(request.ResourceId, Guid.NewGuid());
      return TypedResults.Ok(response);
    }).WithDescription("Notifications of posts including the tag 'security'");
    return builder;
  }
}


public record ResourceNotificationCreateModel(Guid ResourceId);

public record ResourceNotificationResponseModel(Guid ResourceId, Guid NotificationId);
