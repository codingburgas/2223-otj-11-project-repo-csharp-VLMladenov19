using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

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
                Name = "Type1"
            });
            _context.Types.Add(new dal.Models.Type
            {
                Name = "Type2"
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
                    Name = "Type1"
                },
                new dal.Models.Type
                {
                    Id = 2,
                    Name = "Type2"
                }
            };

            TypeRepository typeRepository = new(_context);
            List<dal.Models.Type> actual = typeRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
