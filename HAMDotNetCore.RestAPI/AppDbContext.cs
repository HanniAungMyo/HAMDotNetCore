
using HAMDotNetCore.RestAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMDotNetCore.RestAPI
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectingString = "Data Source =LAPTOP\\SQLSERVER;Initial Catalog =DotNet;User Id =sa;Password =sa@123;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectingString);
            }
        }

           public DbSet<BlogDataModel> Blogs { get; set; }
            
        }
    }



