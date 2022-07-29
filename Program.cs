using frich.Data;
using frich.Data.Interfaces;
using frich.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddTransient<IPersonRepo, SqlFrichRepo>();
    //builder.Services.AddTransient<IMatchesRepo, SqlMatchRepo>();

    var connectionString = builder.Configuration["DatabaseConnectionString"];

    builder.Services.AddDbContext<FrichDbContext>(options => options.UseNpgsql(connectionString));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}