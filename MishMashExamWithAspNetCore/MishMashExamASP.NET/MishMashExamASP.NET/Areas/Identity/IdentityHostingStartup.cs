using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MishMashExamASP.NET.Data;
using MishMashExamASP.NET.Data.Models;

[assembly: HostingStartup(typeof(MishMashExamASP.NET.Areas.Identity.IdentityHostingStartup))]
namespace MishMashExamASP.NET.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}