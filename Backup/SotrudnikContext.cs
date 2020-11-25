using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RosGeoDevOps.Models
{
    public class SotrudnikContext : DbContext
    {
        public DbSet<SotrudnikModel> Sotrudniki { get; set; }
    }
}