    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using Auth0.AspNetCore.Authentication;

    using Lab5.Authentication;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllersWithViews();
    builder.Services.AddScoped<Auth0Authentication>();

    builder.Services.AddHttpClient<Lab6API>(client =>
    {
        client.BaseAddress = new Uri("http://localhost:7225/");
    }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    });

    builder.Services.AddAuthentication("AuthScheme")
        .AddCookie("AuthScheme", options =>
        {
            options.LoginPath = "/Account/Login";
            options.ExpireTimeSpan = TimeSpan.FromHours(1);
        });

    builder.Services.AddAuthorization();
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
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
