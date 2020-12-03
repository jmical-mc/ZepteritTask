using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZepteritTask.Common.Enums;
using ZepteritTask.Database;
using ZepteritTask.Database.Entities;
using ZepteritTask.Repository;

namespace ZepteritTask
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZepteritTask", Version = "v1" });
            });

            services.AddDbContext<ZepteritTaskContenxt>(opt
            => opt.UseSqlServer(Configuration.GetConnectionString("Default")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZepteritTask v1"));
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ZepteritTaskContenxt>();
              
                if (context.Database.EnsureCreated())
                {
                    Seed(context);
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterRepositories();
        }

        private void Seed(ZepteritTaskContenxt context)
        {
            for (int i = 1; i <= 10; i++)
            {
                var orders = new List<Order>();
                var randomNumber = new Random().Next(1, 9);

                for (int j = 1; j <= randomNumber; j++)
                {
                    var paymentMethodNumber = randomNumber > 3 ? 3 : randomNumber;

                    orders.Add(new Order
                    {
                        City = "Rzeszów",
                        NetPrice = 100 + randomNumber,
                        GrosPrice = 117 + randomNumber,
                        PaymentMethod = (PaymentMethod)paymentMethodNumber,
                        PostCode = "12-123",
                        Amount = randomNumber,
                        ProductCode = $"AX13{randomNumber}456{randomNumber}",
                        Street = $"Słoneczna {randomNumber}",
                        CreatedDate = DateTime.UtcNow
                    });
                }

                context.Stores.Add(new Store
                {
                    Name = $"Sklep {i}",
                    StoreNumber = i.ToString(),
                    CreatedDate = DateTime.UtcNow,
                    Orders = orders
                });

                context.SaveChanges();
            }
        }
    }
}
