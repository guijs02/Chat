using Chat;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddRouting();
builder.Services.AddSignalR(signal =>
{
    signal.EnableDetailedErrors = true;

});
var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.AllowAnyOrigin();

});
    app.MapHub<ChatHub>("/chat");

//app.MapBlazorHub();

//app.Map("/", async context =>
//{
//    if (!context.WebSockets.IsWebSocketRequest)
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

//    using var webSocket = await context.WebSockets.AcceptWebSocketAsync();

//    while (true)
//    {
//        await webSocket.SendAsync()
//    }
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");



app.Run();
