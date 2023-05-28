using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.tests.Repositories
{
    public class OutfitClotheRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.OutfitClothes.Add(new OutfitClothe
            {
                OutfitId = 1,
                ClotheId = 1
            }); 
            _context.OutfitClothes.Add(new OutfitClothe
            {
                OutfitId = 2,
                ClotheId = 2
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<OutfitClothe> expected = new(){
                new OutfitClothe
                {
                    Id = 1,
                    OutfitId = 1,
                    ClotheId = 1
                },
                new OutfitClothe
                {
                    Id = 2,
                    OutfitId = 2,
                    ClotheId = 2
                }
            };

            OutfitClotheRepository outfitClotheRepository = new(_context);
            List<OutfitClothe> actual = outfitClotheRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetAllByClotheId()
        {
            _context.ChangeTracker.Clear();

            List<OutfitClothe> expected = new()
            {
                new OutfitClothe
                {
                    Id = 1,
                    OutfitId = 1,
                    ClotheId = 1
                }
            };

            int clotheId = 1;
            OutfitClotheRepository outfitClotheRepository = new(_context);
            List<OutfitClothe> actual = outfitClotheRepository.GetAllByClotheId(clotheId).ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetAllByOutfitId()
        {
            _context.ChangeTracker.Clear();

            List<OutfitClothe> expected = new()
            {
                new OutfitClothe
                {
                    Id = 1,
                    OutfitId = 1,
                    ClotheId = 1
                }
            };

            int outfitId = 1;
            OutfitClotheRepository outfitClotheRepository = new(_context);
            List<OutfitClothe> actual = outfitClotheRepository.GetAllByOutfitId(outfitId).ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();

            List<OutfitClothe> expected = new(){
                new OutfitClothe
                {
                    Id = 1,
                    OutfitId = 1,
                    ClotheId = 1
                },
                new OutfitClothe
                {
                    Id = 2,
                    OutfitId = 2,
                    ClotheId = 2
                },
                new OutfitClothe
                {
                    Id = 3,
                    OutfitId = 3,
                    ClotheId = 3
                }
            };

            OutfitClothe newUser = new OutfitClothe
            {
                Id = 3,
                OutfitId = 3,
                ClotheId = 3
            };

            OutfitClotheRepository outfitClotheRepository = new(_context);
            outfitClotheRepository.AddRow(newUser);
            List<OutfitClothe> actual = _context.OutfitClothes.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<OutfitClothe> expected = new(){
                new OutfitClothe
                {
                    Id = 2,
                    OutfitId = 2,
                    ClotheId = 2
                }
            };

            OutfitClothe user = new OutfitClothe
            {
                Id = 1,
                OutfitId = 1,
                ClotheId = 1
            };

            OutfitClotheRepository outfitClotheRepository = new(_context);
            outfitClotheRepository.DeleteRow(user);
            List<OutfitClothe> actual = _context.OutfitClothes.ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}
