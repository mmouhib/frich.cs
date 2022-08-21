using FluentValidation.AspNetCore;
using frich.Data;
using frich.Data.Interfaces;
using frich.Data.Repositories;
using frich.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddControllers();

    {
        // add repos & UOW to dep. injection
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        builder.Services.AddTransient<IPersonRepo, PersonRepo>();
        builder.Services.AddTransient<IRoundRepo, RoundRepo>();
    }


    // database conn string config
    var connectionString = builder.Configuration["DatabaseConnectionString"];

    // add db context to dep. injection
    builder.Services.AddDbContext<FrichDbContext>(options => { options.UseNpgsql(connectionString); });

    // add AutoMapper to dep. injection
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // add PATCH request dependencies
    builder.Services.AddControllers().AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

    // add FluentValidation for model (& modelstate) validation 
    builder.Services.AddFluentValidation(config => { config.RegisterValidatorsFromAssemblyContaining<Program>(); });
}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}