using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using eStoreClient.Pages.Inheritance;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Presentation.Pages
{
    public class LoginModel : ClientAbstract
    {
        public LoginModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //Xây dựng URL cho api
            string url = "api/users/Login";
            // Parameter
            var queryParameter = new Dictionary<string, string>
            {
                {"username", username},
                {"password", password}
            };
            string queryString = string.Join("&", queryParameter.Select(x => $"{x.Key}={x.Value}"));
            url = $"{url}?{queryString}";
            HttpResponseMessage respone = await HttpClient.PostAsync(url, null);
            if (respone.IsSuccessStatusCode)
            {
                var content = await respone.Content.ReadAsStringAsync();

                string[] tokenParts = content.Split('.');
                string payloadBase64 = tokenParts[1];

                byte[] payloadBytes = Convert.FromBase64String(payloadBase64);
                string payloadJson = Encoding.UTF8.GetString(payloadBytes);

                JsonDocument payload = JsonDocument.Parse(payloadJson);

                // Truy cập các trường trong payload
                string role = payload.RootElement.GetProperty("role").GetString();
                if (role.Equals("2"))
                {
                    _context.HttpContext.Session.SetString("token", content);
                    return RedirectToPage("Index");
                }
            }
           
                ViewData["Message"] = "You do not have permission to do this function, only Staff!";
                return Page();
        }
    }
}
