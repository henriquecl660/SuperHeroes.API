using HeroService.Endpoints;
using HeroService.Infrastructure;
using HeroService.Repositories;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using ConnectionContext = HeroService.Infrastructure.ConnectionContext;

var builder = WebApplication.CreateSlimBuilder(args);




builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(options =>
{
    //options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});
builder.Services.Configure<RouteOptions>(options =>
{
    options.SetParameterPolicy<RegexRouteConstraint>("regex");
});
builder.Services.AddDbContext<ConnectionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddScoped<IHeroRepository, HeroRepository>();


// Adding CORS exception

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader() // Allow any headers
                                .AllowAnyMethod(); // Allow any HTTP methods
                      });
});

//

var app = builder.Build();


// Aplica a política CORS
app.UseCors("MyPolicy");





if (app.Environment.IsDevelopment())
{


    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

}





HeroEndpoints.Map(app);

app.Run();





