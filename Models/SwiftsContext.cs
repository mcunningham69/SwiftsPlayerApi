using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SwiftsPlayerApi.Models;

public partial class SwiftsContext : DbContext
{


public SwiftsContext(DbContextOptions<SwiftsContext> options)
    : base(options)
{
}



    public virtual DbSet<Playerstatus> Playerstatus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseNpgsql("Host=swiftsplayers.postgres.database.azure.com;Port=5432;Database=Swifts;Username=michael.cunningham@westernswifts.com.au;Password=manuZexE5e;Ssl Mode=Require;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Playerstatus>(entity =>
        {
            entity.HasKey(e => e.Playerid);
            entity.ToTable("playerstatus");

            entity.Property(e => e.Attendingsession).HasColumnName("attendingsession");
            entity.Property(e => e.Courtno).HasColumnName("courtno");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Finishedat)
                .HasMaxLength(100)
                .HasColumnName("finishedat");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Gameid).HasColumnName("gameid");
            entity.Property(e => e.DurationInSeconds).HasColumnName("durationinseconds");
            entity.Property(e => e.Gamescount).HasColumnName("gamescount");
            entity.Property(e => e.Grade)
                .HasMaxLength(100)
                .HasColumnName("grade");
            entity.Property(e => e.Isadmin).HasColumnName("isadmin");
            entity.Property(e => e.Ischoosing).HasColumnName("ischoosing");
            entity.Property(e => e.Ischosen).HasColumnName("ischosen");
            entity.Property(e => e.Notified).HasColumnName("notified");
            entity.Property(e => e.Isfacilitator).HasColumnName("isfacilitator");
            entity.Property(e => e.Isplaying).HasColumnName("isplaying");
            entity.Property(e => e.Isselectable).HasColumnName("isselectable");
            entity.Property(e => e.Istimeout).HasColumnName("istimeout");
            entity.Property(e => e.Iswaiting).HasColumnName("iswaiting");
            entity.Property(e => e.Orderofplay).HasColumnName("orderofplay");
            entity.Property(e => e.Playercategories).HasColumnName("playercategories");
            entity.Property(e => e.Playerid).HasColumnName("playerid");
            entity.Property(e => e.Playername)
                .HasMaxLength(100)
                .HasColumnName("playername");
            entity.Property(e => e.Squareid)
                .HasMaxLength(100)
                .HasColumnName("squareid");
            entity.Property(e => e.Startedat)
                .HasMaxLength(100)
                .HasColumnName("startedat");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
            entity.Property(e => e.Visits).HasColumnName("visits");
            entity.Property(e => e.Warmingup).HasColumnName("warmingup");
            entity.Property(e => e.NeedsSync).HasColumnName("needssync");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
