using KoperasiRegistrationAPI.Data;
using KoperasiRegistrationAPI.Interfaces;
using KoperasiRegistrationAPI.Repository;
using KoperasiRegistrationAPI.Services;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<KoperasiAccountsDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("KoperasiDbConnection")));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<INotificationService, MockNotificationService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
