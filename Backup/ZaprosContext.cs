using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RosGeoDevOps.Models
{
    public class ZaprosContext : DbContext
    {
        public DbSet<ZaprosModel> Zaprosi { get; set; }
    }
}