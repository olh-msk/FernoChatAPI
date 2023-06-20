using FernoChatAPI.Repository;
using FernoChatAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your services and the DatabaseConnection in the DI container
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ConversationsRepository>();
builder.Services.AddScoped<ConversationsService>();
builder.Services.AddScoped<ParticipantRepository>();
builder.Services.AddScoped<ParticipantService>();
builder.Services.AddScoped<MessagesRepository>();
builder.Services.AddScoped<MessagesService>();
builder.Services.AddScoped<AttachmentsRepository>();
builder.Services.AddScoped<AttachmentsService>();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("PrimaryConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();