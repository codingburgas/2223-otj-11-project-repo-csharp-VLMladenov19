using Microsoft.EntityFrameworkCore;
using wm.dal.Data;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.tests.Repositories
{
    public class TypeRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Types.Add(new dal.Models.Type
            {
                Name = "T-Shirt"
            });
            _context.Types.Add(new dal.Models.Type
            {
                Name = "Jacket"
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<dal.Models.Type> expected = new(){
                new dal.Models.Type
                {
                    Id = 1,
                    Name = "T-Shirt"
                },
                new dal.Models.Type
                {
                    Id = 2,
                    Name = "Jacket"
                }
            };

            TypeRepository typeRepository = new(_context);
            List<dal.Models.Type> actual = typeRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
