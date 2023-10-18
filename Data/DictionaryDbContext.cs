using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class DictionaryDbContext : DbContext
{
    public DictionaryDbContext(DbContextOptions<DictionaryDbContext> options) : base(options)
    {
    }

    public DbSet<WordRecord> Words { set; get; }
    public DbSet<WordType> WordTypes { set; get; }
    public DbSet<WordTypeLink> WordTypeLinks { set; get; }
    public DbSet<WordMeaning> WordMeanings { set; get; }
    public DbSet<Example> Examples { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WordRecord>().HasKey(x => x.Word);
        modelBuilder.Entity<WordRecord>().Property(x => x.Word).HasMaxLength(128).HasColumnType("varchar");
        modelBuilder.Entity<WordRecord>().Property(x => x.EnUkPronounce).HasMaxLength(20).HasColumnType("varchar");
        modelBuilder.Entity<WordRecord>().Property(x => x.EnUsPronounce).HasMaxLength(20).HasColumnType("varchar");
        modelBuilder.Entity<WordRecord>().Property(x => x.ViPronounce).HasMaxLength(20).HasColumnType("varchar");

        modelBuilder.Entity<WordType>().HasKey(x => x.Id);
        modelBuilder.Entity<WordType>().Property(x => x.En).HasMaxLength(40).HasColumnType("varchar");
        modelBuilder.Entity<WordType>().Property(x => x.Vi).HasMaxLength(40).HasColumnType("varchar");

        modelBuilder.Entity<WordTypeLink>().HasKey(x => x.Id);
        modelBuilder.Entity<WordTypeLink>().Property(x => x.Word).HasMaxLength(128).HasColumnType("varchar");

        modelBuilder.Entity<WordMeaning>().HasKey(x => x.Id);
        modelBuilder.Entity<WordMeaning>().Property(x => x.EnMeaning).HasColumnType("varchar").HasMaxLength(256);
        modelBuilder.Entity<WordMeaning>().Property(x => x.ViMeaning).HasColumnType("varchar").HasMaxLength(256);

        modelBuilder.Entity<Example>().HasKey(x => x.Id);
        modelBuilder.Entity<Example>().Property(x => x.EnExample).HasColumnType("varchar").HasMaxLength(256);
        modelBuilder.Entity<Example>().Property(x => x.ViMeaning).HasColumnType("varchar").HasMaxLength(256);

        modelBuilder.Entity<WordRecord>().HasMany(x => x.WordTypeLinks).WithOne(x => x.WordRecord).HasForeignKey(x => x.Word).IsRequired();
        modelBuilder.Entity<WordType>().HasMany(x => x.WordTypeLinks).WithOne(x => x.WordType).HasForeignKey(x => x.WordTypeId).IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}
