using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Models;
using eStoreClient.Pages.Inheritance;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Presentation.Pages
{
    public class CreateModel : ClientAbstract
    {
        public CreateModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string token = _context.HttpContext.Session.GetString("token");
            // Thêm token vào tiêu đề yêu cầu HTTP
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = "api/students";
            // Chuyển đổi đối tượng ProductRequest thành chuỗi JSON
            var jsonContent = JsonConvert.SerializeObject(Student);
            // Tạo nội dung HTTP để gửi đi
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            // Gửi yêu cầu POST đến API
            var response = await HttpClient.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }
            else
            {
                ViewData["Message"] = "Create Fail!";
                return Page();
            }
        }

    }
}
