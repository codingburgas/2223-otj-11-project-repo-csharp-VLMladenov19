using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.tests.Repositories
{
    public class ColorRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Colors.Add(new Color
            {
                Name = "Color1"
            });
            _context.Colors.Add(new Color
            {
                Name = "Color2"
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<Color> expected = new(){
                new Color
                {
                    Id = 1,
                    Name = "Color1"
                },
                new Color
                {
                    Id = 2,
                    Name = "Color2"
                }
            };

            ColorRepository colorRepository = new(_context);
            List<Color> actual = colorRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
