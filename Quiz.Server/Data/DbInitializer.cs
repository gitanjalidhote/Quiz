using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Quiz.Server.Data
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
                    return;
                }


                context.SaveChanges();
            }
        }
    }
}
