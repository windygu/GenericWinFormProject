namespace App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WinForm.Entities.Authentication;

    internal sealed class Configuration : DbMigrationsConfiguration<TestModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "GenericWinAppTests";
        }

        protected override void Seed(App.TestModelContext context)
        {
           
            context.Roles.AddOrUpdate(
                 r => r.Id
              ,
              new Role { Id = 1, Name = "Root",Hidden= true },
              new Role { Id = 2, Name = "Admin" },
              new Role { Id = 3, Name = "User" },
              new Role { Id = 4, Name = "Project Management system" }
            );

        }
    }
}
