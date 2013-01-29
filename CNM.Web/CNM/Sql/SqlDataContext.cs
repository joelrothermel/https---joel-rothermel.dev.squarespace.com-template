using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using CNM.Models;

namespace CNM.Sql
{
    public class SqlDataContext : DbContext
    {
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Charity> Charities { get; set; }
        public DbSet<SkillEntity> Skills { get; set; }
        public DbSet<ServiceAreaEntity> ServiceAreas { get; set; }
        public DbSet<CharitySearchResult> CharitySearchIndex { get; set; }
        public DbSet<OldSecurity> OldSecurity { get; set; }
        public DbSet<BoardMemberSearchResult> BoardMemberSearchIndex { get; set; }
        public DbSet<ZipCode> Zips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardMember>().HasKey(x => x.BoardMemberId).ToTable("BoardMember");
            modelBuilder.Entity<Charity>().HasKey(x => x.CharityId).ToTable("Charity");
            modelBuilder.Entity<SkillEntity>().HasKey(x => x.SkillId).ToTable("Skill");
            modelBuilder.Entity<ServiceAreaEntity>().HasKey(x => x.ServiceAreaId).ToTable("ServiceArea");

            modelBuilder.Entity<ServiceAreaEntity>().HasKey(x => x.ServiceAreaId).ToTable("ServiceArea");
            modelBuilder.Entity<CharitySearchResult>().HasKey(x => x.CharityId).ToTable("CharitySearch");
            modelBuilder.Entity<BoardMemberSearchResult>().HasKey(x => x.BoardMemberId).ToTable("BoardMemberSearch");
            modelBuilder.Entity<ZipCode>().HasKey(x => x.Zip).ToTable("Zip_Code");

            modelBuilder.Entity<Charity>().HasMany(x => x.NeededSkills).WithMany(x => x.Charities).Map(x =>
                {
                    x.ToTable("CharitySkill");
                    x.MapLeftKey("CharityId");
                    x.MapRightKey("SkillId");

                });

            modelBuilder.Entity<BoardMember>().HasMany(x => x.AvailableSkills).WithMany(x => x.BoardMembers).Map(x =>
            {
                x.ToTable("BoardMemberSkill");
                x.MapLeftKey("BoardMemberId");
                x.MapRightKey("SkillId");
            });

            modelBuilder.Entity<Charity>().HasMany(x => x.NeededServiceAreas).WithMany(x => x.InterestedCharities).Map(x =>
            {
                x.ToTable("CharityServiceArea");
                x.MapLeftKey("CharityId");
                x.MapRightKey("ServiceAreaId");
            });

            modelBuilder.Entity<BoardMember>().HasMany(x => x.Interests).WithMany(x => x.BoardMembersWithThisInterest).Map(x =>
                {
                    x.ToTable("BoardMemberServiceArea");
                    x.MapLeftKey("BoardMemberId");
                    x.MapRightKey("ServiceAreaId");
                });

            modelBuilder.Entity<OldSecurity>()
                .ToTable("dbo.Name_Security");
            modelBuilder.Entity<OldSecurity>()
                .Property(x => x.Username)
                .HasColumnName("WEB_LOGIN");

            base.OnModelCreating(modelBuilder);
        }
    }
}
