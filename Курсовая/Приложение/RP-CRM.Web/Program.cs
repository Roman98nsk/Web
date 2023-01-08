using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RP_CRM.Web;

Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
    .Build()
    .Run();