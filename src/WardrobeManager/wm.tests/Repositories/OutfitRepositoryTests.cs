using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.tests.Repositories
{
    public class OutfitRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Outfits.Add(new Outfit
            {
                Name = "Outfit1",
                Date = new DateTime(2023, 05, 30, 0, 0, 0),
                UserId = 1
            });
            _context.Outfits.Add(new Outfit
            {
                Name = "Outfit2",
                Date = new DateTime(2023, 05, 30, 0, 0, 0),
                UserId = 2
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<Outfit> expected = new(){
                new Outfit
                {
                    Id = 1,
                    Name = "Outfit1",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 1
                },
                new Outfit
                {
                    Id = 2,
                    Name = "Outfit2",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 2
                }
            };

            OutfitRepository outfitRepository = new(_context);
            List<Outfit> actual = outfitRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<Outfit> expected = new(){
                new Outfit
                {
                    Id = 1,
                    Name = "Outfit1",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 1
                },
                new Outfit
                {
                    Id = 2,
                    Name = "Outfit2",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 2
                },
                new Outfit
                {
                    Id = 3,
                    Name = "Outfit2",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 3
                }
            };

            Outfit newUser = new Outfit
            {
                Id = 3,
                Name = "Outfit2",
                Date = new DateTime(2023, 05, 30, 0, 0, 0),
                UserId = 3
            };

            OutfitRepository outfitRepository = new(_context);
            outfitRepository.AddRow(newUser);
            List<Outfit> actual = _context.Outfits.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_UpdateRow()
        {
            _context.ChangeTracker.Clear();

            List<Outfit> expected = new(){
                new Outfit
                {
                    Id = 1,
                    Name = "Outfit1",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 1
                },
                new Outfit
                {
                    Id = 2,
                    Name = "Outfit3",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 3
                }
            };

            Outfit user = new Outfit
            {
                Id = 2,
                Name = "Outfit3",
                Date = new DateTime(2023, 05, 30, 0, 0, 0),
                UserId = 3
            };

            OutfitRepository outfitRepository = new(_context);
            outfitRepository.UpdateRow(user);
            List<Outfit> actual = _context.Outfits.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<Outfit> expected = new(){
                new Outfit
                {
                    Id = 2,
                    Name = "Outfit2",
                    Date = new DateTime(2023, 05, 30, 0, 0, 0),
                    UserId = 2
                }
            };

            Outfit user = new Outfit
            {
                Id = 1,
                Name = "Outfit1",
                Date = new DateTime(2023, 05, 30, 0, 0, 0),
                UserId = 1
            };

            OutfitRepository outfitRepository = new(_context);
            outfitRepository.DeleteRow(user);
            List<Outfit> actual = _context.Outfits.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
