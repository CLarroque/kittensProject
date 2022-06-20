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
        public virtual DbSet<Pokedex> Pokedices { get; set; }
        public virtual DbSet<PokemonsUser> PokemonsUsers { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=51.77.156.169;User=remote-user;Password=?GzmyKt?xRgD!LQ8GGqxqKMR3ncs;Database=pokemons", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8-0-29-mysql"));
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

            modelBuilder.Entity<Pokedex>(entity =>
            {
                entity.ToTable("pokedex");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
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
                    .HasColumnType("int(8)")
                    .HasColumnName("type0");

                entity.Property(e => e.Type1)
                    .HasColumnType("int(8)")
                    .HasColumnName("type1");
            });

            modelBuilder.Entity<PokemonsUser>(entity =>
            {
                entity.ToTable("pokemonsUser");

                entity.HasIndex(e => e.IdItem, "idItem");

                entity.HasIndex(e => e.IdPokemon, "idPokemon");

                entity.HasIndex(e => e.IdUser, "idUser");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdItem)
                    .HasColumnType("int(11)")
                    .HasColumnName("idItem");

                entity.Property(e => e.IdPokemon)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPokemon");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("idUser");

                entity.Property(e => e.Slot)
                    .HasColumnType("int(11)")
                    .HasColumnName("slot");

                entity.HasOne(d => d.IdItemNavigation)
                    .WithMany(p => p.PokemonsUsers)
                    .HasForeignKey(d => d.IdItem)
                    .HasConstraintName("pokemonsUser_ibfk_3");

                entity.HasOne(d => d.IdPokemonNavigation)
                    .WithMany(p => p.PokemonsUsers)
                    .HasForeignKey(d => d.IdPokemon)
                    .HasConstraintName("pokemonsUser_ibfk_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PokemonsUsers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("pokemonsUser_ibfk_1");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("types");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Chinese)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("chinese");

                entity.Property(e => e.English)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("english");

                entity.Property(e => e.French)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("french");

                entity.Property(e => e.Japanese)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("japanese");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .HasColumnType("int(255)")
                    .HasColumnName("id");

                entity.Property(e => e.Death)
                    .HasColumnType("int(11)")
                    .HasColumnName("death");

                entity.Property(e => e.Killed)
                    .HasColumnType("int(11)")
                    .HasColumnName("killed");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
