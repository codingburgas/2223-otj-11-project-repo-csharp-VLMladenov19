using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.tests.Repositories
{
    public class ClotheRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Clothes.Add(new Clothe
            {
                Name = "Clothe1",
                UserId = 1,
                TypeId = 1
            });
            _context.Clothes.Add(new Clothe
            {
                Name = "Clothe2",
                UserId = 2,
                TypeId = 2
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<Clothe> expected = new(){
                new Clothe
                {
                    Id = 1,
                    Name = "Clothe1",
                    UserId = 1,
                    TypeId = 1
                },
                new Clothe
                {
                    Id = 2,
                    Name = "Clothe2",
                    UserId = 2,
                    TypeId = 2
                }
            };

            ClotheRepository clotheRepository = new(_context);
            List<Clothe> actual = clotheRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<Clothe> expected = new(){
                new Clothe
                {
                    Id = 1,
                    Name = "Clothe1",
                    UserId = 1,
                    TypeId = 1
                },
                new Clothe
                {
                    Id = 2,
                    Name = "Clothe2",
                    UserId = 2,
                    TypeId = 2
                },
                new Clothe
                {
                    Id = 3,
                    Name = "Clothe3",
                    UserId = 3,
                    TypeId = 3
                }
            };

            Clothe newUser = new Clothe
            {
                Id = 3,
                Name = "Clothe3",
                UserId = 3,
                TypeId = 3
            };

            ClotheRepository clotheRepository = new(_context);
            clotheRepository.AddRow(newUser);
            List<Clothe> actual = _context.Clothes.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_UpdateRow()
        {
            _context.ChangeTracker.Clear();

            List<Clothe> expected = new(){
                new Clothe
                {
                    Id = 1,
                    Name = "Clothe1",
                    UserId = 1,
                    TypeId = 1
                },
                new Clothe
                {
                    Id = 2,
                    Name = "Clothe3",
                    UserId = 3,
                    TypeId = 3
                }
            };

            Clothe user = new Clothe
            {
                Id = 2,
                Name = "Clothe3",
                UserId = 3,
                TypeId = 3
            };

            ClotheRepository clotheRepository = new(_context);
            clotheRepository.UpdateRow(user);
            List<Clothe> actual = _context.Clothes.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<Clothe> expected = new(){
                new Clothe
                {
                    Id = 2,
                    Name = "Clothe2",
                    UserId = 2,
                    TypeId = 2
                }
            };

            Clothe user = new Clothe
            {
                Id = 1,
                Name = "Clothe1",
                UserId = 1,
                TypeId = 1
            };

            ClotheRepository clotheRepository = new(_context);
            clotheRepository.DeleteRow(user);
            List<Clothe> actual = _context.Clothes.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
