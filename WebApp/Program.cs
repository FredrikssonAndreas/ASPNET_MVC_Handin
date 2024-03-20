using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));
builder.Services.AddHttpClient();

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;

}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/index";
    x.AccessDeniedPath = "/signin";

    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});


builder.Services.AddAuthentication().AddFacebook(x =>
{
    x.AppId = "293931280386403";
    x.AppSecret = "adc64d8a91b7ad96f5e32dbdb3cc238b";
    x.Fields.Add("first_name");
    x.Fields.Add("last_name");
});

builder.Services.AddAuthentication().AddGoogle(x =>
{
    x.ClientId = "200009194355-vqbtfm2gg0gdu5ag5l68r7no0rlkd8cq.apps.googleusercontent.com";
    x.ClientSecret = "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";    
});

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<OptionalInfoRepository>();




var app = builder.Build();
app.UseHsts();
app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
