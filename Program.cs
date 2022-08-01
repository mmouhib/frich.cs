using FluentValidation.AspNetCore;
using frich.Data;
using frich.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();
    builder.Services.AddTransient<IPersonRepo, SqlFrichRepo>();

    var connectionString = builder.Configuration["DatabaseConnectionString"];

    builder.Services.AddDbContext<FrichDbContext>(options => options.UseNpgsql(connectionString));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers().AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

    builder.Services
        .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>());
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}