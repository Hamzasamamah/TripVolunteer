using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningHub.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Finalaboutu> Finalaboutus { get; set; } = null!;
        public virtual DbSet<Finalcategory> Finalcategories { get; set; } = null!;
        public virtual DbSet<Finalcontactu> Finalcontactus { get; set; } = null!;
        public virtual DbSet<Finalgallery> Finalgalleries { get; set; } = null!;
        public virtual DbSet<Finalhome> Finalhomes { get; set; } = null!;
        public virtual DbSet<Finalinvoice> Finalinvoices { get; set; } = null!;
        public virtual DbSet<Finalpayment> Finalpayments { get; set; } = null!;
        public virtual DbSet<Finalreview> Finalreviews { get; set; } = null!;
        public virtual DbSet<Finaltestimonial> Finaltestimonials { get; set; } = null!;
        public virtual DbSet<Finaltrip> Finaltrips { get; set; } = null!;
        public virtual DbSet<Finaluser> Finalusers { get; set; } = null!;
        public virtual DbSet<Finaluserrole> Finaluserroles { get; set; } = null!;
        public virtual DbSet<Finalusertrip> Finalusertrips { get; set; } = null!;
        public virtual DbSet<Finalvisacard> Finalvisacards { get; set; } = null!;
        public virtual DbSet<Finalvolunteer> Finalvolunteers { get; set; } = null!;
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=C##Dina;PASSWORD=12345;DATA SOURCE=DESKTOP-0CTF0NM:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##DINA")
                .UseCollation("USING_NLS_COMP");


            modelBuilder.Entity<Finalaboutu>(entity =>
            {
                entity.HasKey(e => e.ABOUT_US_ID)
                    .HasName("SYS_C008514");

                entity.ToTable("FINALABOUTUS");

                entity.Property(e => e.ABOUT_US_ID)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_US_ID");

                entity.Property(e => e.HOME_ID)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Paragraph)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Finalaboutus)
                    .HasForeignKey(d => d.HOME_ID)
                    .HasConstraintName("FK_ABOUTUS_HOME");
            });

            modelBuilder.Entity<Finalcategory>(entity =>
            {
                entity.HasKey(e => e.Categoryid)
                    .HasName("SYS_C008530");

                entity.ToTable("FINALCATEGORIES");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Finalcontactu>(entity =>
            {
                entity.HasKey(e => e.CONTACT_US_ID)
                    .HasName("SYS_C008517");

                entity.ToTable("FINALCONTACTUS");

                entity.Property(e => e.CONTACT_US_ID)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_US_ID");

                entity.Property(e => e.HOME_ID)
                    .HasColumnType("NUMBER")
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Paragraph)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Finalcontactus)
                    .HasForeignKey(d => d.HOME_ID)
                    .HasConstraintName("FK_CONTACTUS_HOME");
            });

            modelBuilder.Entity<Finalgallery>(entity =>
            {
                entity.HasKey(e => e.Galleryid)
                    .HasName("SYS_C008577");

                entity.ToTable("FINALGALLERY");

                entity.Property(e => e.Galleryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GALLERYID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.HasOne(d => d.Testimonial)
                    .WithMany(p => p.Finalgalleries)
                    .HasForeignKey(d => d.Testimonialid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008579");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Finalgalleries)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008578");
            });

            modelBuilder.Entity<Finalhome>(entity =>
            {
                entity.HasKey(e => e.HOME_ID)
                    .HasName("SYS_C008512");

                entity.ToTable("FINALHOME");

                entity.Property(e => e.HOME_ID)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Paragraph)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PARAGRAPH");
            });

            modelBuilder.Entity<Finalinvoice>(entity =>
            {
                entity.HasKey(e => e.Invoiceid)
                    .HasName("SYS_C008558");

                entity.ToTable("FINALINVOICES");

                entity.Property(e => e.Invoiceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INVOICEID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Invoicecontent)
                    .IsUnicode(false)
                    .HasColumnName("INVOICECONTENT");

                entity.Property(e => e.Timestamp)
                    .HasPrecision(6)
                    .HasColumnName("TIMESTAMP");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Finalinvoices)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008560");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Finalinvoices)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008559");
            });

            modelBuilder.Entity<Finalpayment>(entity =>
            {
                entity.HasKey(e => e.Paymentid)
                    .HasName("SYS_C008564");

                entity.ToTable("FINALPAYMENT");

                entity.Property(e => e.Paymentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENTID");

                entity.Property(e => e.Invoiceid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("INVOICEID");

                entity.Property(e => e.Paymentamount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PAYMENTAMOUNT");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYMENTDATE");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Finalpayments)
                    .HasForeignKey(d => d.Invoiceid)
                    .HasConstraintName("RPAYMENT_FK4");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Finalpayments)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008566");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Finalpayments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008565");
            });

            modelBuilder.Entity<Finalreview>(entity =>
            {
                entity.HasKey(e => e.Reviewid)
                    .HasName("SYS_C008532");

                entity.ToTable("FINALREVIEW");

                entity.Property(e => e.Reviewid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEWID");

                entity.Property(e => e.Dateposted)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEPOSTED")
                    .HasDefaultValueSql("SYSDATE\n");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Stars)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STARS");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Finaltestimonial>(entity =>
            {
                entity.HasKey(e => e.Testimonialid)
                    .HasName("SYS_C008571");

                entity.ToTable("FINALTESTIMONIALS");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Dateposted)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEPOSTED")
                    .HasDefaultValueSql("SYSDATE\n");

                entity.Property(e => e.Message)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Finaltestimonials)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008573");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Finaltestimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008572");
            });

            modelBuilder.Entity<Finaltrip>(entity =>
            {
                entity.HasKey(e => e.Tripid)
                    .HasName("SYS_C008542");

                entity.ToTable("FINALTRIPS");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Cost)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COST");

                entity.Property(e => e.Currentparticipants)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CURRENTPARTICIPANTS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Enddate)
                    .HasColumnType("DATE")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Finaldestination)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FINALDESTINATION");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Maplink)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("MAPLINK");

                entity.Property(e => e.Maximumparticipants)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MAXIMUMPARTICIPANTS");

                entity.Property(e => e.Startdate)
                    .HasColumnType("DATE")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Startdestination)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STARTDESTINATION");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tripname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TRIPNAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Finaltrips)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008543");
            });

            modelBuilder.Entity<Finaluser>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C008526");

                entity.ToTable("FINALUSERS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Datejoined)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEJOINED")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Finalusers)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008527");
            });

            modelBuilder.Entity<Finaluserrole>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("SYS_C008521");

                entity.ToTable("FINALUSERROLES");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Finalusertrip>(entity =>
            {
                entity.HasKey(e => e.Usertripid)
                    .HasName("SYS_C008547");

                entity.ToTable("FINALUSERTRIPS");

                entity.Property(e => e.Usertripid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERTRIPID");

                entity.Property(e => e.Isvolunteer)
                    .HasPrecision(1)
                    .HasColumnName("ISVOLUNTEER")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Tripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Finalusertrips)
                    .HasForeignKey(d => d.Tripid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008549");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Finalusertrips)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008548");
            });

            modelBuilder.Entity<Finalvisacard>(entity =>
            {
                entity.HasKey(e => e.Visaid)
                    .HasName("SYS_C008581");

                entity.ToTable("FINALVISACARD");

                entity.Property(e => e.Visaid)
                    .HasPrecision(10)
                    .HasColumnName("VISAID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Cardnumber)
                    .HasPrecision(16)
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasPrecision(3)
                    .HasColumnName("CVV");

                entity.Property(e => e.Holdname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HOLDNAME");
            });

            modelBuilder.Entity<Finalvolunteer>(entity =>
            {
                entity.HasKey(e => e.Volunteerid)
                    .HasName("SYS_C008552");

                entity.ToTable("FINALVOLUNTEERS");

                entity.Property(e => e.Volunteerid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VOLUNTEERID");

                entity.Property(e => e.Datejoined)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEJOINED")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Tripscount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIPSCOUNT")
                    .HasDefaultValueSql("0\n");

                entity.Property(e => e.Usertripid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERTRIPID");

                entity.HasOne(d => d.Usertrip)
                    .WithMany(p => p.Finalvolunteers)
                    .HasForeignKey(d => d.Usertripid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008553");
            });

      

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
