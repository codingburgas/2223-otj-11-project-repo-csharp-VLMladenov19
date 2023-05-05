using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using wm.dal.Data;
using System.Text.Json;

namespace wm.tests
{
    public class Utilities
    {
        public static WardrobeManagerContext Generate()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WardrobeManagerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging();

            return new WardrobeManagerContext(optionsBuilder.Options);
        }

        public static void AreEqualByJson(object expected, object actual)
        {
            var expectedJson = JsonSerializer.Serialize(expected);
            var actualJson = JsonSerializer.Serialize(actual);

            Assert.That(expectedJson, Is.EqualTo(actualJson));
        }
    }
}
