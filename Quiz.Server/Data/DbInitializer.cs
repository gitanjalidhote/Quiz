//using Microsoft.EntityFrameworkCore;

//namespace Quiz.Server.Data
//{
//    public class DbInitializer
//    {
//    }
//}


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ElearningQuizSystem.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ElearningContext(
                serviceProvider.GetRequiredService<DbContextOptions<ElearningContext>>()))
            {
                if (context.Users.Any())
                {
                    return; // Database has been seeded
                }

                // Seed initial data here
                context.SaveChanges();
            }
        }
    }
}
