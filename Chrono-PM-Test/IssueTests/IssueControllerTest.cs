using Chrono_PM_API.Controllers;
using Chrono_PM_API.Dtos.Issue;
using Chrono_PM_API.Models;
using Chrono_PM_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Chrono_PM_Test.IssueTests;

public class IssueControllerTest
{
    [Test]
    public async Task GetIssueAsync_Returns_Ok_With_IssueList()
    {
        var mockUserStore = new Mock<IUserStore<AppUser>>();

        var mockUserManager = new Mock<UserManager<AppUser>>(
            mockUserStore.Object, null, null, null, null, null, null, null, null);
        var mockIssueService = new Mock<IIssueService>();

        var issues = new List<IssueDto>()
        {
            new IssueDto() { Id = "1", Title = "Issue 1" },
            new IssueDto() { Id = "2", Title = "Issue 2" }
        };

        mockIssueService.Setup(service => service.GetIssuesAsync()).ReturnsAsync(issues);

        var controller = new IssueController(mockIssueService.Object, mockUserManager.Object);

        var result = await controller.GetIssuesAsync();

        Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
    }
}