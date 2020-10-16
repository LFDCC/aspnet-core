using MyProject.UserRoles;
using Microsoft.EntityFrameworkCore;

using MyProject.Roles;
using MyProject.Users;

using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MyProject.EntityFrameworkCore
{
    public static class MyProjectDbContextModelCreatingExtensions
    {
        public static void ConfigureMyProject(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<User>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "Users", MyProjectConsts.DbSchema);
                b.HasIndex(t => t.UserName).HasName("ID_User_UserName");
                b.HasMany(u => u.UserRoles).WithOne(t => t.User).HasForeignKey(ur => ur.UserId).IsRequired();

                b.ConfigureByConvention();
                b.ConfigureStringDefaultLength();


                /* Configure more properties here */
            });

            builder.Entity<Role>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "Roles", MyProjectConsts.DbSchema);
                b.HasMany(r => r.UserRoles).WithOne(t => t.Role).HasForeignKey(ur => ur.RoleId).IsRequired();
                b.ConfigureByConvention();
                b.ConfigureStringDefaultLength();

                /* Configure more properties here */
            });


            builder.Entity<UserRole>(b =>
            {
                b.ToTable(MyProjectConsts.DbTablePrefix + "UserRoles", MyProjectConsts.DbSchema);

                b.HasOne(t => t.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasOne(t => t.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired();

                b.ConfigureByConvention();

                b.HasKey(e => new
                {
                    e.UserId,
                    e.RoleId,
                });

                /* Configure more properties here */
            });
        }
    }
}
