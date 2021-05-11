using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Mode
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Event_Portal", Version = "v1" });
            });


              services.AddAuthentication(options =>
              {
              options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(jwtOptions =>
              {
              jwtOptions.Authority = @"https://login.microsoftonline.com/geshdo.com";
              jwtOptions.TokenValidationParameters.ValidateIssuer = true;
              jwtOptions.TokenValidationParameters.ValidateAudience = true;
              jwtOptions.TokenValidationParameters.ValidIssuer = "https://login.microsoftonline.com/cd20e4c9-f82c-4d3e-9224-90f2bc4be1a0/v2.0";
              jwtOptions.TokenValidationParameters.ValidAudience = "1a602afd-b047-4730-892f-715f551f9c97";
              });

    
      services.AddMvc();
    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event_Portal v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}