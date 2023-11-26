namespace HigiaServer.Infra.Data.Mappings;

public class BaseUserMap : IEntityTypeConfiguration<BaseUserEntity>
{
    public void Configure(EntityTypeBuilder<BaseUserEntity> builder)
    {
        builder.ToTable("user")
            .HasDiscriminator(x => x.IsAdmin)
            .HasValue<Collaborator>(false)
            .HasValue<Administrator>(true);

        builder.HasIndex(x => x.Id)
            .IsUnique();

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasColumnName("first_name")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasColumnName("last_name")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.IsAdmin)
            .HasColumnName("is_admin")
            .HasColumnType("BOOLEAN")
            .IsRequired();

        builder.Property(x => x.Birthday)
            .HasColumnName("birthday")
            .HasColumnType("TIMESTAMP")
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasColumnName("phone_number")
            .HasColumnType("TEXT")
            .IsRequired();
    }
}