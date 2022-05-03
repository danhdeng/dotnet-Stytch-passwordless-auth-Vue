using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindfulGift.API.BusinessLogic.Auth;
using MindfulGift.API.Config;
using MindfulGift.API.DataAccess;
using MindfulGift.API.Models;
using MindfulGift.API.Models.Stytch.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddCors();
builder.Services.AddOptions();
builder.Services.AddTransient<IAuthService, StytchService>();
builder.Services.Configure<StytchOptions>(builder.Configuration.GetSection("Stytch"));

builder.Services.AddDbContext<MindfulGiftDbContext>(
    opts => {
        opts.EnableSensitiveDataLogging();
        opts.EnableDetailedErrors();
        opts.UseNpgsql(builder.Configuration.GetConnectionString("AppDb"));
    },
    ServiceLifetime.Transient
);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(build => {
    build.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.MapPost("/createOrLogin", async ([FromBody] AuthRequest authRequest, IAuthService authService) => {
    var response = await authService.SendMagicLink(authRequest.Email);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest();
});

app.MapGet("/auth", async ([FromBody] string token, IAuthService authService) => {
    var response= await authService.AuthenticateMagicLink(token);
    return response.IsSuccess 
    ? Results.Redirect($"http://localhost:3000?sessionTOken={response.SessionToken}")
    : Results.Unauthorized();
});

app.MapPost("/verifyToken", async ([FromBody] StytchAuthenticationRequest authRequest, IAuthService authService) => {
    var response = await authService.VerifySession(authRequest.Token);
    return !string.IsNullOrWhiteSpace(response.UserId) 
    ? Results.Ok(response) 
    : Results.Unauthorized();   
});

app.Run();
