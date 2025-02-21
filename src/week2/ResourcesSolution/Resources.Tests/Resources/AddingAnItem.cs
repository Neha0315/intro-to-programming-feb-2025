

using Alba;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Resources.Api.Resources;

namespace Resources.Tests.Resources;

public class AddingAnItem
{
  [Fact]
  public async Task AddingAnItemWithASecurityTagNotifiesTheSoftwareApi()
  {
    var host = await AlbaHost.For<Program>(config=>
    {
   
    });
    var itemToPost = new ResourceListItemCreateModel
    {
      Description = "description",
      Title = "title",
      Link = "https://test-doubles.hypertheory.com",
      LinkText = "Hypertheory",
      Tags = ["dog", "cat", "security", "tacos"]
    };

    var postResponse = await host.Scenario(api =>
    {
      api.Post.Json(itemToPost).ToUrl("/resources");
    });

    var entityReturned = postResponse.ReadAsJson<ResourceListItemModel>();

    Assert.NotNull(entityReturned);

    Assert.True(entityReturned.IsBeingReviewedForSecurity);


  }

  [Fact]
  public async Task AddingAnItemWithoutASecurityTagDoesNotNotifyTheSoftwareApi()
  {
   
    var host = await AlbaHost.For<Program>(config =>
    {
     
    });
    var itemToPost = new ResourceListItemCreateModel
    {
      Description = "description",
      Title = "title",
      Link = "https://test-doubles.hypertheory.com",
      LinkText = "Hypertheory",
      Tags = ["dog", "cat", "tacos"]
    };

    var postResponse = await host.Scenario(api =>
    {
      api.Post.Json(itemToPost).ToUrl("/resources");
    });

    var entityReturned = postResponse.ReadAsJson<ResourceListItemModel>();

    Assert.NotNull(entityReturned);

    Assert.False(entityReturned.IsBeingReviewedForSecurity);
   
  }

}

//public class StubbedSecurityTeam : INotifytheSecurityReviewTeam
//{
//  public Task<string> NotifyForSecurityReview(Guid id)
//  {
//    return Task.FromResult("tacos-id-from-the-team");
//  }
//}
