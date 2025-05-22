using System.Net;
using System.Net.Http.Json;
using Club.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Club.Test;

public class MemberControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public MemberControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetMembers_ReturnsOk()
    {
        // Arrange
        var response = await _client.GetAsync("/api/Member");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PostMember_ReturnsCreated()
    {
        // Arrange
        var newMember = new Member
        {
            Name = "Test Member",
            Email = "test@example.com"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/Member", newMember);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
