using System.Security.Principal;
using System.Web;

namespace MyShop.WebUI.Tests.Mocks
{
    public class MockHttpContext : HttpContextBase
    {
        private MockRequest request;
        private MockResponse response;
        private HttpCookieCollection cookies;
        private IPrincipal fakeUser;

        public MockHttpContext()
        {
            cookies = new HttpCookieCollection();
            this.request = new MockRequest(cookies);
            this.response = new MockResponse(cookies);
        }

        public override IPrincipal User
        {
            get { return this.fakeUser; }
            set { fakeUser = value; }
        }

        public override HttpRequestBase Request => request;

        public override HttpResponseBase Response => response;
    }

   

    public class MockResponse : HttpResponseBase
    {
        public MockResponse(HttpCookieCollection cookies)
        {
            this.Cookies = cookies;
        }

        public override HttpCookieCollection Cookies { get; }
    }

    public class MockRequest : HttpRequestBase
    {
        public MockRequest(HttpCookieCollection cookies)
        {
            this.Cookies = cookies;
        }

        public override HttpCookieCollection Cookies { get; }
    }


}