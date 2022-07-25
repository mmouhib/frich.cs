using frich.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddTransient<IFrichRepo, SqlFrichRepo>();

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<FrichDbContext>(options => options.UseNpgsql(connectionString));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}