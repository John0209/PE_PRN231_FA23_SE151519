using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using eStoreClient.Pages.Inheritance;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Presentation.Pages
{
    public class DetailsModel : ClientAbstract
    {
        public DetailsModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        public async Task OnGetAsync(int? id)
        {
            string token = _context.HttpContext.Session.GetString("token");
            // Thêm token vào tiêu đề yêu cầu HTTP
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = $"api/students/{id}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Student = JsonConvert.DeserializeObject<Student>(content);
            }
        }
    }
}
