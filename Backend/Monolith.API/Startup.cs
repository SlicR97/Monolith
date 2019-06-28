using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monolith.DAL;
using Monolith.DAL.Contracts;
using Monolith.DAL.Factories;
using Monolith.DAL.Models;
using Monolith.DAL.Repositories;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Monolith.API
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
         services.AddSingleton(generateContextOptions(readConnectionString().ConnectionString));
         services.AddCors();
         services.AddMvc().AddJsonOptions(opts =>
         {
            opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
         });
         services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
         services.AddScoped<Seed>();
         services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env, Seed seeder)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }
         else
         {
            app.UseHsts();
         }

         app.UseStaticFiles();
         app.UseDefaultFiles();
         app.UseHttpsRedirection();
         app.UseCors(cors => cors.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
         app.UseMvc();
         // seeder.SeedDb();
      }

      private ConnectionStringPoco readConnectionString()
      {
         var configFilePath = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\..\..\appsettings.json";
         using (StreamReader file = new StreamReader(configFilePath))
         {
            return JsonConvert.DeserializeObject<ConnectionStringPoco>(file.ReadToEnd());
         }
      }

      private DbContextOptions<DataContext> generateContextOptions(string connectionString)
         => new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(connectionString)
            .Options;
   }
}
