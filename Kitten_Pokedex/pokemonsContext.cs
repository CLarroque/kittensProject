using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kitten_Pokedex
{
    public partial class pokemonsContext : DbContext
    {
        public pokemonsContext()
        {
        }

        public pokemonsContext(DbContextOptions<pokemonsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Move> Moves { get; set; }
        public virtual DbSet<Pokedex> Pokedices { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=51.77.156.169;user=wpuser;password=motdepasse;database=pokemons", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.1.45-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("items");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Namechinese)
                    .HasMaxLength(16)
                    .HasColumnName("namechinese");

                entity.Property(e => e.Nameenglish)
                    .IsRequired()
                    .HasMaxLength(19)
                    .HasColumnName("nameenglish");

                entity.Property(e => e.Namejapanese)
                    .HasMaxLength(10)
                    .HasColumnName("namejapanese");
            });

            modelBuilder.Entity<Move>(entity =>
            {
                entity.ToTable("moves");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Accuracy)
                    .HasColumnType("int(11)")
                    .HasColumnName("accuracy");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("category");

                entity.Property(e => e.Cname)
                    .HasMaxLength(6)
                    .HasColumnName("cname");

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("ename");

                entity.Property(e => e.Jname)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("jname");

                entity.Property(e => e.MaxPp)
                    .HasColumnType("int(11)")
                    .HasColumnName("max_pp");

                entity.Property(e => e.Power)
                    .HasColumnType("int(11)")
                    .HasColumnName("power");

                entity.Property(e => e.Pp)
                    .HasColumnType("int(11)")
                    .HasColumnName("pp");

                entity.Property(e => e.Tm)
                    .HasColumnType("int(11)")
                    .HasColumnName("tm");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<Pokedex>(entity =>
            {
                entity.ToTable("pokedex");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.BaseAttack)
                    .HasColumnType("int(11)")
                    .HasColumnName("baseAttack");

                entity.Property(e => e.BaseDefense)
                    .HasColumnType("int(11)")
                    .HasColumnName("baseDefense");

                entity.Property(e => e.BaseHp)
                    .HasColumnType("int(11)")
                    .HasColumnName("baseHP");

                entity.Property(e => e.BaseSpAttack)
                    .HasColumnType("int(11)")
                    .HasColumnName("baseSp_Attack");

                entity.Property(e => e.BaseSpDefense)
                    .HasColumnType("int(11)")
                    .HasColumnName("baseSp_Defense");

                entity.Property(e => e.BaseSpeed)
                    .HasColumnType("int(11)")
                    .HasColumnName("baseSpeed");

                entity.Property(e => e.Namechinese)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("namechinese");

                entity.Property(e => e.Nameenglish)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("nameenglish");

                entity.Property(e => e.Namefrench)
                    .HasMaxLength(12)
                    .HasColumnName("namefrench");

                entity.Property(e => e.Namejapanese)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("namejapanese");

                entity.Property(e => e.Type0)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("type0");

                entity.Property(e => e.Type1)
                    .HasMaxLength(8)
                    .HasColumnName("type1");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.English)
                    .HasName("PRIMARY");

                entity.ToTable("types");

                entity.Property(e => e.English)
                    .HasMaxLength(8)
                    .HasColumnName("english");

                entity.Property(e => e.Chinese)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("chinese");

                entity.Property(e => e.French)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("french");

                entity.Property(e => e.Japanese)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("japanese");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
