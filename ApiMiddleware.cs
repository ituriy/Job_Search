using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Job_Search.Models;

namespace Job_Search
{
    public class ApiMiddleware
    {
        private readonly RequestDelegate next;

        public ApiMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, ApplicationContext _DBcontext)
        {
            var path = context.Request.Path;
            if (path.Equals("/api/Jobs/"))
            {

                if (context.Request.Method == "GET")
                {
                    if (context.Request.Query.Count == 0)
                    {
                        List<Jobs> jobs = _DBcontext.Jobs.ToList();
                        await context.Response.WriteAsJsonAsync(jobs);
                    }
                    else
                    {
                        var pair = context.Request.Query.First();
                        string? filterColumnName = pair.Key;
                        string? filterValue = pair.Value;
                        List<Jobs> responseJob = new List<Jobs>();
                        switch (filterColumnName)
                        {
                            case "Id":
                                int JobId = int.Parse(filterValue);
                                responseJob.Add(_DBcontext.Jobs.Find(JobId));
                                break;
                            default: break;
                        }
                        await context.Response.WriteAsJsonAsync(responseJob);
                    }
                }
            }
            else if (path.Equals("/api/Openings/"))
            {
                if (context.Request.Method == "GET")
                {
                    if (context.Request.Query.Count == 0)
                    {
                        List<Openings> Openings = _DBcontext.Openings.ToList();
                        await context.Response.WriteAsJsonAsync(Openings);
                    }
                    else
                    {
                        var pair = context.Request.Query.First();
                        string? filterColumnName = pair.Key;
                        string? filterValue = pair.Value;
                        List<Openings> responseOpening = new List<Openings>();
                        switch (filterColumnName)
                        {
                            case "Id":
                                int LibraryId = int.Parse(filterValue);
                                responseOpening.Add(_DBcontext.Openings.Find(LibraryId));
                                break;
                            default: break;
                        }
                        await context.Response.WriteAsJsonAsync(responseOpening);
                    }
                }
            }
            else
            {
                await next.Invoke(context);
            }
        }
    }
}
