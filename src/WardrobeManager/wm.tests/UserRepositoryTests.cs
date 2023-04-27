using wm.dal.Data;
using wm.dal.Models;
using wm.dal.Repositories;

namespace wm.tests
{
    public class UserRepositoryTests
    {
        private readonly WardrobeManagerContext _context;

        public UserRepositoryTests()
        {
            _context = Utilities.Generate();
        }

        [SetUp]
        public void Setup()
        {
            _context.Users.Add(new dal.Models.User
            {
                Username = "test1",
                Password = "3805C12FC67060217558470498B9266A077B049ECC5805EBF83B933EFAD6B049",
                Salt = "8523A3548BCF736E4F98B26A26FA6DED",
                FirstName = "test",
                LastName = "test",
                Phone = "1234567890",
                Email = "test1@pass.me"
            });
            _context.Users.Add(new dal.Models.User
            {
                Username = "test2",
                Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                Salt = "B3496A6A46E4E69DD7D89566B1187905",
                FirstName = "test",
                LastName = "test",
                Phone = "1234567890",
                Email = "test2@pass.me"
            });
            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            List<User> expected = new(){
                new dal.Models.User
                {
                    Id = 1,
                    Username = "test1",
                    Password = "3805C12FC67060217558470498B9266A077B049ECC5805EBF83B933EFAD6B049",
                    Salt = "8523A3548BCF736E4F98B26A26FA6DED",
                    FirstName = "test",
                    LastName = "test",
                    Phone = "1234567890",
                    Email = "test1@pass.me"
                },
                new dal.Models.User
                {
                    Id = 2,
                    Username = "test2",
                    Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                    Salt = "B3496A6A46E4E69DD7D89566B1187905",
                    FirstName = "test",
                    LastName = "test",
                    Phone = "1234567890",
                    Email = "test2@pass.me"
                } 
            };

            UserRepository userRepository = new(_context);
            List<User> actual = userRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetUserById()
        {
            User expected = new dal.Models.User
            {
                Id = 2,
                Username = "test2",
                Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                Salt = "B3496A6A46E4E69DD7D89566B1187905",
                FirstName = "test",
                LastName = "test",
                Phone = "1234567890",
                Email = "test2@pass.me"
            };

            UserRepository userRepository = new(_context);
            User actual = userRepository.GetUserById(2);

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetUserByUsername()
        {
            User expected = new dal.Models.User
            {
                Id = 2,
                Username = "test2",
                Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                Salt = "B3496A6A46E4E69DD7D89566B1187905",
                FirstName = "test",
                LastName = "test",
                Phone = "1234567890",
                Email = "test2@pass.me"
            };

            UserRepository userRepository = new(_context);
            User actual = userRepository.GetUserByUsername("test2");

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}