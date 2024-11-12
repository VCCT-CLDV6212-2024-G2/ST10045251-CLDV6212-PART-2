using ST10045251_CLDV6212_POE.Services;

var builder = WebApplication.CreateBuilder(args);

// Explicitly add the appsettings.json file
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Retrieve the connection string from configuration
string connectionString = builder.Configuration.GetConnectionString("AzureSqlDb");

// Add the DatabaseService to the dependency injection container
builder.Services.AddSingleton(new DatabaseService(connectionString));

// Add controllers with views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{action=Index}/{id?}",
        defaults: new { controller = "Storage" }
    );
});

app.Run();
