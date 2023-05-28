using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.tests.Repositories
{
    public class ClotheColorRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.ClotheColors.Add(new ClotheColor
            {
                ClotheId = 1,
                ColorId = 1
            });
            _context.ClotheColors.Add(new ClotheColor
            {
                ClotheId = 2,
                ColorId = 2
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<ClotheColor> expected = new(){
                new ClotheColor
                {
                    Id = 1,
                    ClotheId = 1,
                    ColorId = 1
                },
                new ClotheColor
                {
                    Id = 2,
                    ClotheId = 2,
                    ColorId = 2
                }
            };

            ClotheColorRepository clotheColorRepository = new(_context);
            List<ClotheColor> actual = clotheColorRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetAllByClotheId()
        {
            _context.ChangeTracker.Clear();

            List<ClotheColor> expected = new(){
                new ClotheColor
                {
                    Id = 1,
                    ClotheId = 1,
                    ColorId = 1
                }
            };

            int clotheId = 1;
            ClotheColorRepository clotheColorRepository = new(_context);
            List<ClotheColor> actual = clotheColorRepository.GetAllByClotheId(clotheId).ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<ClotheColor> expected = new(){
                new ClotheColor
                {
                    Id = 1,
                    ClotheId = 1,
                    ColorId = 1
                },
                new ClotheColor
                {
                    Id = 2,
                    ClotheId = 2,
                    ColorId = 2
                },
                new ClotheColor
                {
                    Id = 3,
                    ClotheId = 3,
                    ColorId = 3
                }
            };

            ClotheColor newUser = new ClotheColor
            {
                Id = 3,
                ClotheId = 3,
                ColorId = 3
            };

            ClotheColorRepository clotheColorRepository = new(_context);
            clotheColorRepository.AddRow(newUser);
            List<ClotheColor> actual = _context.ClotheColors.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<ClotheColor> expected = new(){
                new ClotheColor
                {
                    Id = 2,
                    ClotheId = 2,
                    ColorId = 2
                }
            };

            ClotheColor user = new ClotheColor
            {
                Id = 1,
                ClotheId = 1,
                ColorId = 1
            };

            ClotheColorRepository clotheColorRepository = new(_context);
            clotheColorRepository.DeleteRow(user);
            List<ClotheColor> actual = _context.ClotheColors.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
