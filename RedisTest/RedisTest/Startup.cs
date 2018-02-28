namespace RedisTest
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using EasyCaching.Redis;
    using EasyCaching.Serialization.MessagePack;
    using EasyCaching.Core.Internal;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultRedisCache(option =>
            {
                option.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
                option.Password = "";
                option.Database = 10;
            });
            //put here!
            services.AddDefaultMessagePackSerializer();


            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
