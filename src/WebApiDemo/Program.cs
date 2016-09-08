﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("hosting.json", optional: true).Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
