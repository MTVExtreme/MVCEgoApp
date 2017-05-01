namespace PersonalityEgo.Migrations
{
    using PersonalityEgo.DAL;
    using PersonalityEgo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonalityEgo.DAL.EgoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonalityEgo.DAL.EgoContext context)
        {

            var departments = new List<Department>
            {
                new Department {Name = "Military" },
                new Department {Name = "Law" },
                new Department {Name = "Enterainment" },
                new Department {Name = "Engineering" },
                new Department {Name = "Trial" },
                new Department {Name = "Governament" }

            };

            departments.ForEach(s => context.Department.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role { RoleName = "Guard", DepartmentID = departments.Single( i => i.Name == "Military").DepartmentID},
                new Role { RoleName = "Researcher", DepartmentID = departments.Single( i => i.Name == "Engineering").DepartmentID },
                new Role { RoleName = "Searcher", DepartmentID = departments.Single( i => i.Name == "Military").DepartmentID },
                new Role { RoleName = "Tech Designer", DepartmentID = departments.Single( i => i.Name == "Engineering").DepartmentID },
                new Role { RoleName = "Queen", DepartmentID = departments.Single( i => i.Name == "Governament").DepartmentID },
                new Role { RoleName = "Judge", DepartmentID = departments.Single( i => i.Name == "Trial").DepartmentID },
                new Role { RoleName = "Proscuter", DepartmentID = departments.Single( i => i.Name == "Trial").DepartmentID },
                new Role { RoleName = "Plaintiff", DepartmentID = departments.Single( i => i.Name == "Trial").DepartmentID },
                new Role { RoleName = "Defendant", DepartmentID = departments.Single( i => i.Name == "Trial").DepartmentID },
                new Role { RoleName = "Attorny", DepartmentID = departments.Single( i => i.Name == "Trial").DepartmentID }
            };

            roles.ForEach(s => context.Role.AddOrUpdate(p => p.RoleName, s));
            context.SaveChanges();


            var personalities = new List<Personality>
            {
                new Personality { FirstName = "Mea", LastName = "Soroni", Birthday = DateTime.Parse("07/06"), Gender = Gender.Female, RoleID = 8},
                new Personality { FirstName = "Eve", LastName = "Villiar", Birthday = DateTime.Parse("01/06"), Gender = Gender.Female, RoleID = 4},
                new Personality { FirstName = "Calvin", LastName = "Mavine", Birthday = DateTime.Parse("05/03"), Gender = Gender.Male, RoleID = 10},
                new Personality { FirstName = "Hunter ", LastName = "Blake", Gender = Gender.Male, RoleID = 1},
                new Personality { FirstName = "Jane", LastName = "Raizoni", Birthday = DateTime.Parse("10/04"), Gender = Gender.Female, RoleID = 9},
                new Personality { FirstName = "Kalie", LastName = "Tazen", Birthday = DateTime.Parse("10/23"), Gender = Gender.Female, RoleID = 3},
                new Personality { FirstName = "Halie", LastName = "Tazen", Birthday = DateTime.Parse("10/23"), Gender = Gender.Female, RoleID = 7},
                new Personality { FirstName = "Xavier", LastName = "Rosemary", Birthday = DateTime.Parse("01/06"), Gender = Gender.Male, RoleID = 1},
                new Personality { FirstName = "Rachiel", LastName = "Vessalius", Birthday = DateTime.Parse("02/26"), Gender = Gender.Female, RoleID = 3},
                new Personality { FirstName = "Laynce", LastName = "Caster", Gender = Gender.Undefined, RoleID = 1},
                new Personality { FirstName = "Gwen", LastName = "Gardez", Birthday = DateTime.Parse("03/16"), Gender = Gender.Female, RoleID = 9},
                new Personality { FirstName = "Tyler", LastName = "Vermillion", Birthday = DateTime.Parse("01/06"), MentalAge = 19 , Gender = Gender.Male, RoleID = 6},
                new Personality { FirstName = "Daisy", LastName = "Phillips", Gender = Gender.Female, RoleID = 3}
            };

            personalities.ForEach(s => context.Personality.AddOrUpdate(p => p.FirstName, s));
            context.SaveChanges();

            var charges = new List<Charge>
            {
                new Charge { ChargeName = "Murder"},
                new Charge { ChargeName = "Assault"},
                new Charge { ChargeName = "Fruad"}
            };

            charges.ForEach(s => context.Charge.AddOrUpdate(p => p.ChargeName, s));
            context.SaveChanges();

            var trials = new List<Trial>
            {
                new Trial
                {
                    Personalities = new List<Personality>(),

                    ChargeID = charges.Single(i => i.ChargeName == "Murder").ChargeID,
                    IsComplete = false
                }

            };
            trials.ForEach(s => context.Trial.AddOrUpdate(p => p.ChargeID, s));

            context.SaveChanges();


        }
    }
}

