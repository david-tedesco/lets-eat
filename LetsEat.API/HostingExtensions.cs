using Duende.IdentityServer;
using LetsEat.API.Data;
using LetsEat.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace LetsEat.API
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;

                    // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                    options.EmitStaticAudienceClaim = true;
                })
                .AddInMemoryIdentityResources(builder.Environment.IsDevelopment() ? ConfigDev.IdentityResources : ConfigProd.IdentityResources)
                .AddInMemoryApiScopes(builder.Environment.IsDevelopment() ? ConfigDev.ApiScopes : ConfigProd.ApiScopes)
                .AddInMemoryClients(builder.Environment.IsDevelopment() ? ConfigDev.Clients : ConfigProd.Clients)
                .AddAspNetIdentity<User>();

            builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityConstants.ExternalScheme;
                    options.ClientId = "500723915351-shfa7lcoeekkoupm8ldrebjsu554qed6.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    options.SaveTokens = true;
                    options.UsePkce = true;
                });

            builder.Services.AddControllers();
            builder.Services.AddRazorPages();

            builder.Services.AddTransient<IEmailSender, EmailSender>();
            builder.Services.Configure<MailKitEmailSenderOptions>(
                builder.Configuration
                .GetSection("ExternalProviders")
                .GetSection("MailKit")
                .GetSection("SMTP"));

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.MapRazorPages()
                .RequireAuthorization();
            return app;
        }
    }
}