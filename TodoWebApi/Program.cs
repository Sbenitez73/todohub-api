using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Todo.WebApi.Application;
using Todo.WebApi.Application.Abstractions;
using Todo.WebApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies((typeof(Program).Assembly)));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var keyvaultUrl = builder.Configuration.GetSection("keyvault:KeyVaultUrl");
var keyvaultClientId = builder.Configuration.GetSection("keyvault:ClientId");
var keyvaultClientSecret = builder.Configuration.GetSection("keyvault:ClientSecret");
var keyvaultDirectoryId = builder.Configuration.GetSection("keyvault:DirectoryId");

var credential = new ClientSecretCredential(keyvaultDirectoryId.Value!.ToString(),
                                            keyvaultClientId.Value!.ToString(),
                                            keyvaultClientSecret.Value!.ToString());

builder.Configuration.AddAzureKeyVault(keyvaultUrl.Value!.ToString(),
                                       keyvaultClientId.Value!.ToString(),
                                       keyvaultClientSecret.Value!.ToString(),
                                       new DefaultKeyVaultSecretManager());

var client = new SecretClient(new Uri(keyvaultUrl.Value!.ToString()), credential);

builder.Services.AddDbContext<TaskContext>(options =>
{
    options.UseSqlServer(client.GetSecret("sqldbtodo").Value.Value.ToString());
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