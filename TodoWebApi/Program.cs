using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Todo.DrivenAdapter.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Build main configuration
BuildConfiguration();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


void BuildConfiguration()
{
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
    builder.Services.AddDbContext<TodoContext>(options =>
    {
        options.UseSqlServer(client.GetSecret("sqldbtodo").Value.Value.ToString());
    });
}
