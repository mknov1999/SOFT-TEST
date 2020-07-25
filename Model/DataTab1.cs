using AV_Soft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AV_Soft.Model
{
    public class DataTab1
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AVSContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AVSContext>>()))
            {
                if (!context.Tab1.Any())
                {
                    context.Tab1.AddRange(
                        new Tab1 { KEY = 1, VALUE = 1 },
                        new Tab1 { KEY = 1, VALUE = 2 },
                        new Tab1 { KEY = 1, VALUE = 3 },
                        new Tab1 { KEY = 2, VALUE = 1 },
                        new Tab1 { KEY = 2, VALUE = 3 },
                        new Tab1 { KEY = 2, VALUE = 1 },
                        new Tab1 { KEY = 2, VALUE = 1 }
                        );
                    context.SaveChanges();
                }
                return;
            }
        }
    }
}
