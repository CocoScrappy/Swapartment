using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Swapartment.Areas.Identity.Data;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Reflection;
using Swapartment.Helpers;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

try {
// Get values from the config given their key and their target type.
var conn_str = builder.Configuration["sql_con_str"] ?? throw new InvalidOperationException("Connection string 'sql_con_str' not found.");

builder.Services.AddDbContext<SwapartmentIdentityDbContext>(options =>
   options.UseSqlServer(conn_str));

builder.Services.AddDefaultIdentity<SwapartmentUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SwapartmentIdentityDbContext>();


//builder.Services.AddOptions<AzureStorageConfig>().Bind(Configuration.GetSection("AzureStorageConfig"));//solving upload.cshtml.cs IOptions problem - actually didn't solve it

builder.Services.Configure<AzureStorageConfig>(builder.Configuration.GetSection("AzureStorageConfig"));
// Add services to the container.
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
// Host.CreateDefaultBuilder(args)
//     .ConfigureAppConfiguration((context, config) =>
//     {
//         var buildConfiguration = config.Build();
//         string keyVaultUri = buildConfiguration["KeyVaultConfig:KeyVaultUri"];
//         string tenantId = buildConfiguration["KeyVaultConfig:TenantId"];
//         string clientId = buildConfiguration["KeyVaultConfig:ClientId"];
//         string clientSecret = buildConfiguration["KeyVaultConfig:ClientSecret"];
//         var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
//         var client = new SecretClient(new Uri(keyVaultUri), credential);
//         config.AddAzureKeyVault(client, new AzureKeyVaultConfiguration());
//     });
//retrieve connection string from Azure Key Vault
// var keyVaultClient = new SecretClient(new Uri("https://kv-swapartment-sql.vault.azure.net/"), new DefaultAzureCredential());
// var connectionString = keyVaultClient.GetSecret("swpt-constr-secret").Value.Value;

//connect SQL database to the application using the connection string

} catch (Exception e) {
    Console.WriteLine(e.Message);
}