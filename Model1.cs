namespace WindowsFormsApp1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<countries> countries { get; set; }
        public virtual DbSet<leagues> leagues { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<players> players { get; set; }
        public virtual DbSet<rounds> rounds { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<teams> teams { get; set; }
        public virtual DbSet<transfers_rumours> transfers_rumours { get; set; }
        public virtual DbSet<trophies> trophies { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<countries>()
                .Property(e => e.country_name)
                .IsUnicode(false);

            modelBuilder.Entity<countries>()
                .HasMany(e => e.players)
                .WithRequired(e => e.countries)
                .HasForeignKey(e => e.player_id_national_team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<leagues>()
                .Property(e => e.league_name)
                .IsUnicode(false);

            modelBuilder.Entity<leagues>()
                .Property(e => e.league_country)
                .IsUnicode(false);

            modelBuilder.Entity<leagues>()
                .HasMany(e => e.teams)
                .WithRequired(e => e.leagues)
                .HasForeignKey(e => e.team_id_league)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<news>()
                .Property(e => e.news_name)
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.news_text)
                .IsUnicode(false);

            modelBuilder.Entity<players>()
                .Property(e => e.player_name)
                .IsUnicode(false);

            modelBuilder.Entity<players>()
                .Property(e => e.player_position)
                .IsUnicode(false);

            modelBuilder.Entity<teams>()
                .Property(e => e.team_name)
                .IsUnicode(false);

            modelBuilder.Entity<teams>()
                .Property(e => e.team_stadium)
                .IsUnicode(false);

            modelBuilder.Entity<teams>()
                .HasMany(e => e.players)
                .WithRequired(e => e.teams)
                .HasForeignKey(e => e.player_id_team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<teams>()
                .HasMany(e => e.rounds)
                .WithRequired(e => e.teams)
                .HasForeignKey(e => e.round_id_team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<teams>()
                .HasMany(e => e.trophies)
                .WithRequired(e => e.teams)
                .HasForeignKey(e => e.trophy_id_team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<transfers_rumours>()
                .Property(e => e.tr_name)
                .IsUnicode(false);

            modelBuilder.Entity<transfers_rumours>()
                .Property(e => e.tr_description)
                .IsUnicode(false);

            modelBuilder.Entity<trophies>()
                .Property(e => e.trophy_name)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.user_login)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .Property(e => e.user_password)
                .IsUnicode(false);
        }
    }
}
