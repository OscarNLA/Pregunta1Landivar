using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcLandivarPr1.Models
{
    public class DataContext : DbContext 
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Pr1LandivarAPI.Models.Landivar> Landivars { get; set; }
    }
}