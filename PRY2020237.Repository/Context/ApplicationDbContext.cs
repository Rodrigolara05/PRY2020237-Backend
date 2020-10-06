using PRY2020237.Entity;
using Microsoft.EntityFrameworkCore;

namespace PRY2020237.Repository.Context{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<User> User {get; set;}
        public DbSet<Project> Project {get; set;}
        public DbSet<PageView> PageView {get; set;}
        public DbSet<Component> Component {get; set;}
        public DbSet<ComponentType> ComponentType {get; set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){
        }
    }
}