using Mvc101.Services.SmsService;
using SendGrid.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISmsService, WissenSmsService>();
builder.Services.AddSendGrid(Options =>
{
    Options.ApiKey = "12345";
});

//builder.Services.Addscoped<IEmailService, OutlookEmailService>();

builder.Services.AddScoped<ISmsService, WissenSmsService>();
builder.Services.AddSendGrid(options =>
{
    options.ApiKey = "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";
});



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
