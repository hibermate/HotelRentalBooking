using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace HotelRentalBooking.Credential
{
    public class ApiKeyHandle : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
           CancellationToken cancellationtoken)
        {
            bool isValidAPIkey = false;
            IEnumerable<String> Isheader;
            var checkApiKeyExists = request.Headers.TryGetValues("API_KEY", out Isheader);

            if (checkApiKeyExists)
            {
                string apikeyclient = Isheader.FirstOrDefault();
              // isValidAPIkey = demoen.Keys.Count(x => x.status.Equals("true") && x.APIKey.Equals(apikeyclient)) > 0;
            }

            if (!isValidAPIkey)
            {
                return request.CreateResponse(HttpStatusCode.Forbidden, "Bad api key");
            }

            var response = await base.SendAsync(request, cancellationtoken);

            return response;
        }
    }
}