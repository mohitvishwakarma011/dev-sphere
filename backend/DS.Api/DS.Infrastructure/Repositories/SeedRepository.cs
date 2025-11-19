using DS.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace DS.Infrastructure.Repositories
{
    public class SeedRepository(AppDbContext context, IPasswordHasher<User> hasher) : ISeedRepository
    {
        public async Task SeedCategories()
        {
            if (await context.Categories.AnyAsync())
            {
                return;
            }

            await context.Categories.AddRangeAsync(DefaultSeedData.Categories);
        }

        public async Task SeedSubCategories()
        {
            if (await context.SubCategories.AnyAsync())
            {
                return;
            }

            var categories = await context.Categories.AsNoTracking().ToListAsync();

            int technologyId = categories.Single(x => x.Name == "Technology").Id;
            int pLId = categories.Single(x => x.Name == "Programming Languages").Id;
            int sSId = categories.Single(x => x.Name == "Soft Skills").Id;

            var subCategories = new List<Subcategory>
            {
                new Subcategory
                {
                    Name = "Web Development",
                    Description = "Articles related to building, designing, and deploying web applications using various frameworks and tools.",
                    CategoryId = technologyId,
                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Mobile Development",
                    Description = "Content focused on creating mobile applications for Android, iOS, and cross-platform frameworks.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Cloud Computing",
                    Description = "Topics covering cloud platforms, infrastructure, services, and architecture patterns.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "DevOps",
                    Description = "Posts about CI/CD pipelines, automation, infrastructure as code, containers, and deployment practices.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Databases",
                    Description = "Insights into SQL, NoSQL, database design, optimization, and management techniques.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Cybersecurity",
                    Description = "Everything related to system security, vulnerabilities, best practices, and threat prevention.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Data Science",
                    Description = "Articles involving data analysis, visualization, statistics, and data-driven decision-making.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "AI & Machine Learning",
                    Description = "Content related to artificial intelligence, neural networks, ML models, and intelligent systems.",
                    CategoryId = technologyId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "C#",
                    Description = "Articles covering the C# language, .NET platform, and full-stack .NET development.",
                    CategoryId = pLId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "JavaScript",
                    Description = "Content related to JavaScript, frontend development, and the overall JS ecosystem.",
                    CategoryId = pLId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Python",
                    Description = "Topics covering Python programming, scripting, automation, and data-processing applications.",
                    CategoryId = pLId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Java",
                    Description = "Articles related to Java programming, enterprise applications, and JVM technologies.",
                    CategoryId = pLId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Career Tips",
                    Description = "Helpful advice on career growth, interviews, job preparation, and professional advancement.",
                    CategoryId = sSId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Productivity",
                    Description = "Tips and techniques for improving efficiency, focus, and personal effectiveness.",
                    CategoryId = sSId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },
                new Subcategory
                {
                    Name = "Project Management",
                    Description = "Articles focused on project planning, agile methodologies, and team collaboration strategies.",
                    CategoryId = sSId,

                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                }
            };
            await context.SubCategories.AddRangeAsync(subCategories);

        }

        public async Task SeedAdminAndRoleAsync()
        {
            if (!context.Roles.Any())
            {
                var roles = new[] { "Admin", "Manager", "User" }
                    .Select(n => new Role { Name = n }).ToArray();
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var admin = new User
                {
                    UserName = "admin",
                    UserEmail = "admin.devsphere@yopmail.com",
                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                };
                admin.PasswordHash = hasher.HashPassword(admin, "Admin@123");
                context.Users.Add(admin);
                await context.SaveChangesAsync();

                var adminRole = context.Roles.Single(r => r.Name == "Admin");
                context.UserRoles.Add(new UserRole { UserId = admin.Id, RoleId = adminRole.Id });
                await context.SaveChangesAsync();
            }
        }

    }
}

public static class DefaultSeedData
{
    public static List<Category> Categories => new()
    {
        new Category
         {
                    Name = "Technology",
                    Description = "General topics related to modern technologies, innovations, tools, and trends shaping the digital world.",
                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
        },

                new Category
                {
                    Name = "Programming Languages",
                    Description = "General content about various programming languages and their ecosystems.",
                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                },

                new Category
                {
                    Name = "Soft Skills",
                    Description = "Content focused on communication, leadership, and non-technical skills essential for career success.",
                    Status = DS.Core.Utilities.Constants.RecordStatus.Active
                }
    };
}
