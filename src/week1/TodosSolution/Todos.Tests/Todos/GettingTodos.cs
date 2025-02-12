
using Alba;
using Todos.Api.Todos;

namespace Todos.Tests.Todos;
public class GettingTodos
{

    [Fact]
    public async Task GetsAOkStatusCode()
    {
        var host = await AlbaHost.For<Program>();
        // a bit of time between these two.
        await host.Scenario(api =>
        {
            api.Get.Url("/todos");
            api.StatusCodeShouldBeOk(); // 200

        });
    }

    [Fact]
    public async Task CanAddAnItemToTheTodoList()
    {
        var host = await AlbaHost.For<Program>();
        var itemToAdd = new TodoListCreateItem
        {
            Description = "Make Tacos " + Guid.NewGuid(),
        };
        await host.Scenario(api =>
        {
            api.Post.Json(itemToAdd).ToUrl("/todos");

            api.StatusCodeShouldBeOk();

        });
        // see if it is on my todo list.
        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url("/todos");

        });

       var listOfTodos = getResponse.ReadAsJson<List<TodoListItem>>();

        Assert.NotNull(listOfTodos);

        bool found = false;

        // format code same as for each element, if any element has the condition after arrow
        // var hasMyItem = listOfTodos.Any(item => item.Description == itemToAdd.Description);

        //dot net static; run quickly 
        //can't chnage the type when running 
        //uses classes, object or grouping or related things 

        //don't know ahead of time; oop ways to codify to make concepts more concrete
        //change as we go

        // Fewer elements (less "stuff")
        foreach(TodoListItem item in listOfTodos) 
        {
            if (item.Description == itemToAdd.Description)
            {
                found = true;
                break;
            }
                
        }

        Assert.True(found);
    }
}
