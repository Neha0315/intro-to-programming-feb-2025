
namespace Resources.Api.Resources.Services;

public class SecurityApi : INotifytheSecurityReviewTeam
{

  private HttpClient _httpClient;

  public SecurityApi(HttpClient httpClient)
  {
    _httpClient = httpClient;
  }

  public async Task<string> NotifyForSecurityReview(Guid id)
  {
    var response = await _httpClient.PostAsJsonAsync("/locations-notifications", new SoftwareTeamNotification(id));

    response.EnsureSuccessStatusCode(); // if I get anything other than a status code of 200-299, throw an exception.

    var responseMessage = await response.Content.ReadFromJsonAsync<SoftwareTeamNotificationResponse>();

    if(responseMessage is null)
    {
      throw new NullReferenceException("Software team messed us up, yo.");
    }
    return responseMessage.NotificationId.ToString();
  }
}


public record SoftwareTeamNotification(Guid ResourceId);

public record SoftwareTeamNotificationResponse(Guid NotificationId, Guid ResourceId);
