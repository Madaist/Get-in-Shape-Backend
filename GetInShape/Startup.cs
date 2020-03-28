using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GetInShape.Contexts;
using GetInShape.Repositories.AddressRepository;
using GetInShape.Repositories.ClassRepository;
using GetInShape.Repositories.GymClubClassRepository;
using GetInShape.Repositories.GymClubRepository;
using GetInShape.Repositories.InstructorClassRepository;
using GetInShape.Repositories.InstructorRepository;
using GetInShape.Repositories.InstructorSpecializationRepository;
using GetInShape.Repositories.SongRepository;
using GetInShape.Repositories.SpecializationRepository;


namespace GetInShape
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IGymClubClassRepository, GymClubClassRepository>();
            services.AddTransient<IGymClubRepository, GymClubRepository>();
            services.AddTransient<IInstructorClassRepository, InstructorClassRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<IInstructorSpecializationRepository, InstructorSpecializationRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<ISpecializationRepository, SpecializationRepository>();
        }

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
            app.UseCors(builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            app.UseMvc();
        }
    }
}
