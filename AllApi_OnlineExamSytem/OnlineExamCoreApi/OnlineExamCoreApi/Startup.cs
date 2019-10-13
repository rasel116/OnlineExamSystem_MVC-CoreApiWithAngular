using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineExamCoreApi.Models;
using OnlineExamCoreApi.Models.Repository;

namespace OnlineExamCoreApi
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // Added Student
            services.AddScoped<IDataAccessRepository<Student>, ClsStudent>();

            // Added Teacher
            services.AddScoped<IDataAccessRepository<Teacher>, ClsTeacher>();

            // Added Registration
            services.AddScoped<IDataAccessRepository<Registration>, ClsRegistration>();

            // Added Test
            services.AddScoped<IDataAccessRepository<Test>, ClsTest>();

            // Added Choice
            services.AddScoped<IDataAccessRepository<Choice>, ClsChoice>();

            // Added Question
            services.AddScoped<IDataAccessRepository<Question>, ClsQuestion>();

            // Added Subject
            services.AddScoped<IDataAccessRepository<Subject>, ClsSubject>();

            // Added Exhibit
            services.AddScoped<IDataAccessRepository<Exhibit>, ClsExhibit>();

            // Added QuestionCategory
            services.AddScoped<IDataAccessRepository<QuestionCategory>, ClsQuestionCategory>();


            // Added QuestionXDuration
            services.AddScoped<IDataAccessRepository<QuestionXDuration>, ClsQuestionXDuration>();

            // Added TestXQuestion
            services.AddScoped<IDataAccessRepository<TestXQuestion>, ClsTestXQuestion>();

            // Added TestXPaper
            services.AddScoped<IDataAccessRepository<TestXPaper>, ClsTestXPaper>();

            // Added AdminPanel
            services.AddScoped<IDataAccessRepository<AdminPanel>, ClsAdminPanel>();

            // Added Organization
            services.AddScoped<IDataAccessRepository<Organization>, ClsOrganization>();

            //-------------------------///
            services.AddDbContext<CrudInCoreWebApiDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DbCon")));

            services.AddIdentity<IdentityUser, IdentityRole>(
               option =>
               {
                   option.Password.RequireDigit = false;
                   option.Password.RequiredLength = 6;
                   option.Password.RequireNonAlphanumeric = false;
                   option.Password.RequireUppercase = false;
                   option.Password.RequireLowercase = false;
               }
               ).AddEntityFrameworkStores<CrudInCoreWebApiDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Site"],
                    ValidIssuer = Configuration["Jwt:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigninKey"]))
                };
            });
            //-------------------------///
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
