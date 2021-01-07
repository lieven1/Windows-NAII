using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Repositories;
using API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace API
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            
            services.AddOpenApiDocument(c =>
            {
                c.DocumentName = "apidocs";
                c.Title = "Reizen API";
                c.Version = "v1";
                c.Description = "Reizen API description";
                c.AddSecurity("JWT", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey, //use API keys for authorization. An API key is a token that a client provides when making API calls.
                    In = OpenApiSecurityApiKeyLocation.Header, //token is passed in the header
                    Name = "Authorization", //name of header to be used
                    Description = "Type into the textbox: Bearer {your JWT token}. " //description above textfield to enter bearer token
                });

                c.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));

            });
            services.AddSwaggerDocument();

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.User.RequireUniqueEmail = true).AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true //Ensure token hasn't expired
                };
            });

            services.AddScoped<DataInitializer>();
            services.AddScoped<IReisRepository, ReisRepository>();
            services.AddScoped<IActiviteitsRepository, ActiviteitRepository>();
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<ICheckListItemRepository, CheckListItemRepository>();
            services.AddScoped<ICheckListRepository, CheckListRepository>();
            services.AddScoped<IVerplaatsingRepository, VerplaatsingRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataInitializer dataInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwaggerUi3();
            app.UseOpenApi();

            dataInitializer.InitializeData().Wait();
        }
    }
}
