namespace PersonalityEgo.Migrations
{
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
            var personalities = new List<Personality>
            {
                new Personality { FirstName = "Mea", LastName = "Soroni", Birthday = DateTime.Parse("07-06"), Gender = Gender.Female},
                new Personality { FirstName = "Eve", LastName = "Villiar", Birthday = DateTime.Parse("01-06"), Gender = Gender.Female},
                new Personality { FirstName = "Calvin", LastName = "Mavine", Birthday = DateTime.Parse("05-03"), Gender = Gender.Male},
                new Personality { FirstName = "Hunter ", LastName = "Blake", Gender = Gender.Male},
                new Personality { FirstName = "Jane", LastName = "Raizoni", Birthday = DateTime.Parse("10-04"), Gender = Gender.Female},
                new Personality { FirstName = "Kalie", LastName = "Tazen", Birthday = DateTime.Parse("10-23"), Gender = Gender.Female},
                new Personality { FirstName = "Halie", LastName = "Tazen", Birthday = DateTime.Parse("10-23"), Gender = Gender.Female},
                new Personality { FirstName = "Xavier", LastName = "Rosemary", Birthday = DateTime.Parse("01-06"), Gender = Gender.Male},
                new Personality { FirstName = "Rachiel", LastName = "Vessalius", Birthday = DateTime.Parse("02-26"), Gender = Gender.Female},
                new Personality { FirstName = "Laynce", LastName = "Caster", Gender = Gender.Undefined},
                new Personality { FirstName = "Gwen", LastName = "Gardez", Birthday = DateTime.Parse("03-16"), Gender = Gender.Female},
                new Personality { FirstName = "Tyler", LastName = "Vermillion", Birthday = DateTime.Parse("01-06"), MentalAge = 19 , Gender = Gender.Male},
                new Personality { FirstName = "Daisy", LastName = "Phillips", Gender = Gender.Female}
            };

            personalities.ForEach(s => context.Personality.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department {Name = "Military" },
                new Department {Name = "Law" },
                new Department {Name = "Enterainment" },
                new Department {Name = "Engineering" },
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

            };

            roles.ForEach(s => context.Role.AddOrUpdate(p => p.RoleName, s));
            context.SaveChanges();

            var skills = new List<Skill>
            {
                new Skill { SkillName = "Strength" },
                new Skill { SkillName = "Speed" },
                new Skill { SkillName = "Leadership" },
                new Skill { SkillName = "Humor" },
                new Skill { SkillName = "Intelligence" },
                new Skill { SkillName = "Perception" }
            };

            skills.ForEach(s => context.Skill.AddOrUpdate(p => p.SkillName, s));
            context.SaveChanges();

            var roleAssignments = new List<RoleAssignment>
            {
                new RoleAssignment {
                    PersonalityID = personalities.Single( i => i.FirstName == "Mea" && i.LastName == "Soroni").ID,
                    RoleID = roles.Single(i => i.RoleName == "Queen").RoleID,
                    SkillID = skills.Single(i => i.SkillName == "Leadership").SkillID},

                new RoleAssignment {
                    PersonalityID = personalities.Single( i => i.FirstName == "Rachiel" && i.LastName == "Vessalius").ID,
                    RoleID = roles.Single(i => i.RoleName == "Guard").RoleID,
                    SkillID = skills.Single(i => i.SkillName == "Strength").SkillID},

                new RoleAssignment {
                    PersonalityID = personalities.Single( i => i.FirstName == "Daisy" && i.LastName == "Phillips").ID,
                    RoleID = roles.Single(i => i.RoleName == "Searcher").RoleID,
                    SkillID = skills.Single(i => i.SkillName == "Speed").SkillID}

            };

            roleAssignments.ForEach(s => context.RoleAssignment.AddOrUpdate(p => p.PersonalityID, s));
            context.SaveChanges();

            var charges = new List<Charge>
            {
                new Charge { ChargeName = "Murder"},
                new Charge { ChargeName = "Assault"},
                new Charge { ChargeName = "Fruad"}
            };

            charges.ForEach(s => context.Charge.AddOrUpdate(p => p.ChargeID, s));
            context.SaveChanges();

            var trials = new List<Trial>
            {
                new Trial
                {
                    PlaintiffID = personalities.Single( i => i.FirstName == "Mea" && i.LastName == "Soroni").ID,
                    ProscuterID = personalities.Single( i => i.FirstName == "Halie" && i.LastName == "Tazen").ID,
                    DefendantID = personalities.Single( i => i.FirstName == "Gwen" && i.LastName == "Gardez").ID,
                    AttornyID = personalities.Single( i => i.FirstName == "Calvin" && i.LastName == "Mavine").ID,
                    JudgeID = personalities.Single( i => i.FirstName == "Tyler" && i.LastName == "Vermillion").ID,
                    ChargeID = charges.Single(i => i.ChargeName == "Murder").ChargeID,
                    IsComplete = false
                }

            };

            trials.ForEach(s => context.Trial.AddOrUpdate(p => p.TrialID, s));
            context.SaveChanges();

        }
    }
}
