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
using System.Reflection.Metadata;
using System.Net.Http.Headers;

namespace Presentation.Pages
{
    public class IndexModel : ClientAbstract
    {
        public IndexModel(IHttpClientFactory http, IHttpContextAccessor httpContextAccessor) : base(http, httpContextAccessor)
        {
        }
        [BindProperty]
        public List<Student> Student { get; set; } = default!;
        //[BindProperty]
        //public List<StudentGroup> Group { get; set; }
        [BindProperty]
        public int groupId { get; set; }
        [BindProperty]
        public DateTime minBirthday { get; set; }
        [BindProperty]
        public DateTime maxBirthday { get; set; }
        public async Task OnGetAsync()
        {
            string token = _context.HttpContext.Session.GetString("token");
            // Thêm token vào tiêu đề yêu cầu HTTP
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            // Gọi API endpoint từ dự án API.
            HttpResponseMessage response = await HttpClient.GetAsync("api/students");
         
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Student = JsonConvert.DeserializeObject<List<Student>>(content);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            string token = _context.HttpContext.Session.GetString("token");
            // Thêm token vào tiêu đề yêu cầu HTTP
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string url = $"api/students/search?groupId={groupId}&minBirthdate={minBirthday}&maxBirthdate={maxBirthday}";
            HttpResponseMessage response = await HttpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                Student = JsonConvert.DeserializeObject<List<Student>>(content);
                return Page();
            }
            await OnGetAsync();
            ViewData["Message"] = "student don't exits!";
            return Page();
        }
        // HttpResponseMessage _group = await HttpClient.GetAsync("api/groups");
        // var content2= await _group.Content.ReadAsStringAsync();
        //Group = JsonConvert.DeserializeObject<List<StudentGroup>>(content);

    }
}
