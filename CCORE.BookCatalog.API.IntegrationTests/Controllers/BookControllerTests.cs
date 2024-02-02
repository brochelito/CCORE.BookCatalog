using CCORE.BookCatalog.API.IntegrationTests.Base;
using CCORE.BookCatalog.Application.Features.Books.Queries.GetBooksList;
using System.Net;
using System.Text.Json;
using Xunit;

namespace CCORE.BookCatalog.API.IntegrationTests.Controllers
{
    public class BookControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public BookControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsUnauthorizedResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/books");
         
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.False(response.IsSuccessStatusCode);
        }       
    }
}
