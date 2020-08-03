using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Ketum.Pages
{
    public class Index_Tests : KetumWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
