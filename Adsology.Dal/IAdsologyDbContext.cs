using System;
using System.Linq;
using System.Threading.Tasks;
using Adsology.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Adsology.Dal
{
    public interface IAdsologyDbContext
    {
        DbSet<Articles> Articles { get; set; }
        DbSet<BillingAddresses> BillingAddresses { get; set; }
        DbSet<OrderStatuses> OrderStatuses { get; set; }
        DbSet<Orders> Orders { get; set; }
        DbSet<Payments> Payments { get; set; }
        Task SaveChangesAsync();
    }
}
