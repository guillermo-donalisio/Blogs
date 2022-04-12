using Blogs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var hostBuilder = Host.CreateDefaultBuilder() 
    .ConfigureServices((hostContext, services) =>
    {
        //Add you business services
        var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BlogContext>(x => x.UseSqlServer(connectionString));
    
    }).Build();
