using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Entities;


namespace Web.Infrastructure.EntityFrameworkCore
{
    //This class is used to intially add data to the DB. 
    //A check is done each time the app runs to see if data has already populated the DB
    public class AiimiContextSeed
    {        
        public static async Task SeedDBAsync(AiimiContext context, ILoggerFactory loggerFactory)
        {
            try
            {      
                if (!context.People.Any())
                {
                    var peopleData = File.ReadAllText("../Web/Infrastructure/EntityFrameworkCore/SeedData/people.json");
                    var people = JsonSerializer.Deserialize<List<Person>>(peopleData);
                    
                    foreach (var person in people)
                    {
                        context.People.Add(person);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AiimiContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
