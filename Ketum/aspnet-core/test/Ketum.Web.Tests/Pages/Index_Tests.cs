using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace ketum.Pages
{
    public class Index_Tests : ketumWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
