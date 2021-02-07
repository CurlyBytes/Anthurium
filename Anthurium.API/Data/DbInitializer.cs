using Anthurium.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anthurium.API.Data
{
    public class DbInitializer
    {
        public static void Initialize(AnthuriumContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Contacts.
            if (context.ClientInformations.Any())
            {
                return;   // DB has been seeded
            }

            var clientInformations = new ClientInformation[]
            {
                new ClientInformation { 
                    CompanyName = "RAFI",  
                    CompanyAddress = "eduardo aboitiz street",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation { 
                    CompanyName = "CurlyBytes",  
                    CompanyAddress = "107 v. raman st. calamba cc",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                },
                new ClientInformation {
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    }

            };
            
            var jobOrders = new JobOrder[]
            {
                new JobOrder { 
                    CompanyName = "RAFI",  
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "Rafinian",
                    ContactNumber = "+0639207082",
                    TimeStarted = DateTime.UtcNow,
                    TimeEnded = DateTime.UtcNow,
                    TotalHours = 2,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "RAFI",
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "Rafinian",
                    ContactNumber = "+0639207082",
                    TimeStarted = DateTime.UtcNow.AddHours(12),
                    TimeEnded = DateTime.UtcNow.AddHours(35),
                    TotalHours = 31,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "RAFI",
                    CompanyAddress = "eduardo aboitiz street",
                    ClientInformationId = 1,
                    ContactPerson = "Rafinian",
                    ContactNumber = "+0639207082",
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(2),
                    TotalHours = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ClientInformationId = 2,
                    ContactPerson = "Cocoy",
                    ContactNumber = "4177214",
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(2),
                    TotalHours = 1,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "CurlyBytes",
                    CompanyAddress = "107 v. raman st. calamba cc",
                    ClientInformationId = 2,
                    ContactPerson = "Cacay",
                    ContactNumber = "4177214",
                    TimeStarted = DateTime.UtcNow.AddHours(11),
                    TimeEnded = DateTime.UtcNow.AddHours(42),
                    TotalHours = 3,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    },
                new JobOrder {
                    CompanyName = "Microsoft",
                    CompanyAddress = "United States America",
                    ClientInformationId = 3,
                    ContactPerson = "Trump",
                    ContactNumber = "21141",
                    TimeStarted = DateTime.UtcNow.AddHours(1),
                    TimeEnded = DateTime.UtcNow.AddHours(12),
                    TotalHours = 8,
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                    }

            };

            context.ClientInformations.AddRange(clientInformations);
            context.JobOrders.AddRange(jobOrders);
            context.SaveChanges();
        }
    }
}
