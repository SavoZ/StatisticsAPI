using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StatisticsDataBase.DB
{
    public partial class StatisticsContext : DbContext
    {
        public StatisticsContext()
        {
        }

        public StatisticsContext(DbContextOptions<StatisticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CouponLeagueStatistic> CouponLeagueStatistics { get; set; }
        public virtual DbSet<CouponListLeagueSetting> CouponListLeagueSettings { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<StatisticsCountry> StatisticsCountries { get; set; }
        public virtual DbSet<StatisticsMatch> StatisticsMatches { get; set; }
        public virtual DbSet<StatisticsSeason> StatisticsSeasons { get; set; }
        public virtual DbSet<StatisticsTable> StatisticsTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=SAVO;Initial Catalog=Statistics;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CouponListLeagueSetting>(entity =>
            {
                entity.Property(e => e.RowHeightId).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.Property(e => e.LeagueId).ValueGeneratedNever();

                entity.Property(e => e.LeagueName).IsUnicode(false);
            });

            modelBuilder.Entity<StatisticsCountry>(entity =>
            {
                entity.Property(e => e.CountryName).IsUnicode(false);

                entity.Property(e => e.SportName).IsUnicode(false);
            });

            modelBuilder.Entity<StatisticsMatch>(entity =>
            {
                entity.Property(e => e.AwayName).IsUnicode(false);

                entity.Property(e => e.EventGroupName).IsUnicode(false);

                entity.Property(e => e.Finished).HasDefaultValueSql("((0))");

                entity.Property(e => e.HomeName).IsUnicode(false);

                entity.Property(e => e.MatchId).IsUnicode(false);

                entity.Property(e => e.SeasonName).IsUnicode(false);

                entity.Property(e => e.SportName).IsUnicode(false);
            });

            modelBuilder.Entity<StatisticsSeason>(entity =>
            {
                entity.Property(e => e.CompentitionName).IsUnicode(false);

                entity.Property(e => e.SeasonName).IsUnicode(false);

                entity.Property(e => e.WinerName).IsUnicode(false);
            });

            modelBuilder.Entity<StatisticsTable>(entity =>
            {
                entity.Property(e => e.GroupName).IsUnicode(false);

                entity.Property(e => e.SeasonName).IsUnicode(false);

                entity.Property(e => e.TeamName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
