using System;
using Ketum.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace Ketum.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable(Keys.ConnectionString);
            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Connection string is not found in environment variables 'KETUM_CONNECTIONSTRING'. I'm using default connection string.");
                connectionString = "Server=localhost; Port=5432; Database=ketum; User Id=postgres; Password=123456789;";
            }

            var stripeApiKey = Environment.GetEnvironmentVariable(Keys.StripeAPIKey);
            if (string.IsNullOrEmpty(stripeApiKey))
            {
                Console.WriteLine("Stripe api key is not found in environment variables 'STRIPEAPIKEY'. I'm using default stripe api key string.");
                StripeConfiguration.SetApiKey("sk_test_VC6BqWBxNlcnu6mdFn8OnCLU006MJGWHgx");
            }
            else
            {
                StripeConfiguration.SetApiKey(Keys.StripeAPIKey);
            }

            bool.TryParse(Environment.GetEnvironmentVariable(Keys.TestProject), out var isTestProject);

            if (!isTestProject)
            {
                services.AddDbContext<KTDBContext>(
                    options => options.UseNpgsql(connectionString)
                );
                var scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
                using (var scope = scopeFactory.CreateScope())
                using (var db = scope.ServiceProvider.GetRequiredService<KTDBContext>())
                {
                    db.Database.Migrate();
                }
            }
            else
            {
                services.AddDbContext<KTDBContext>(options => options.UseInMemoryDatabase("ketum_test"));
            }

            services
                .AddDefaultIdentity<KTUser>()
                .AddEntityFrameworkStores<KTDBContext>()
                .AddDefaultTokenProviders();
            // Add framework services.
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services
                .AddHostedService<KTBSMonitoring
                >(); //Bizim yerimize background servisi oluşturur ve StartAsync() metodunu çağırıcak. https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-2.2
            //https://docs.microsoft.com/en-us/ASPNET/Core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(15);
                options.Cookie.Name = "ketum-auth";

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //https://docs.microsoft.com/en-us/ASPNET/Core/security/authentication/identity?view=aspnetcore-2.2&tabs=visual-studio
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    "spa-fallback",
                    new
                    {
                        controller = "Home", action = "Index"
                    });
            });
        }
    }
}
