﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepairShopAPI;
using Microsoft.AspNetCore.Identity;

namespace RepairShopAPI.Data
{
    public class RepairShopAPIContext : DbContext
    {
        public RepairShopAPIContext (DbContextOptions<RepairShopAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RepairShopAPI.accounts> accounts { get; set; } = default!;
        public DbSet<RepairShopAPI.appointments> appointments { get; set; } = default!;
        public DbSet<RepairShopAPI.parts> parts { get; set; } = default!;
        public DbSet<RepairShopAPI.persons> persons { get; set; } = default!;
        public DbSet<RepairShopAPI.usedparts> usedparts { get; set; } = default!;
        public DbSet<RepairShopAPI.serials_location> serials_location { get; set; } = default!;
    }
}
