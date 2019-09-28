using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.Models
{
    public class MyDbContext :DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //配置联合主键
            modelBuilder.Entity<Sys_UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<Sys_RoleMenu>().HasKey(x => new { x.MenuId, x.RoleId });

        }

        public DbSet<Sys_User> sys_Users  { get; set; }
        public DbSet<Sys_Menu> sys_Menus  { get; set; }
        public DbSet<Sys_Role> sys_Roles  { get; set; }
        public DbSet<Sys_UserRole> sys_UserRoles  { get; set; }
        public DbSet<Sys_RoleMenu>  sys_RoleMenus { get; set; }
    }
}
