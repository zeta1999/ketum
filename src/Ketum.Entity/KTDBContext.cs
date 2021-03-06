﻿using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ketum.Entity
{
    public class KTDBContext : IdentityDbContext<KTUser, IdentityRole<Guid>, Guid>
    {
        public KTDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<KTDMonitor> Monitors { get; set; }
        public DbSet<KTDMonitorStep> MonitorSteps { get; set; }
        public DbSet<KTDMonitorStepLog> MonitorStepLogs { get; set; }
        public DbSet<KTDSubscription> Subscriptions { get; set; }
        public DbSet<KTDSubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<KTDSubscriptionFeature> SubscriptionFeatures { get; set; }
        public DbSet<KTDSubscriptionTypeFeature> SubscriptionTypeFeatures { get; set; }
        public DbSet<KTDPayment> Payments { get; set; }
        public DbSet<KTDMonitorAlert> MonitorAlerts { get; set; }
        public DbSet<KTDMonitorAlertLog> MonitorAlertLogs { get; set; }
    }
}