using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net.Http.Json;


namespace Job_Search.Pages
{
    public class CreateOpeningModel : PageModel
    {
        static HttpClient httpClient = new HttpClient();
      

        async public Task OnGet()
        {
            object? data = await httpClient.GetFromJsonAsync("", typeof(Person));

            
        }
        
    }

}
