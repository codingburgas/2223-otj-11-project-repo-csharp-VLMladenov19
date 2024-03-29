using wm.dal.Repositories;
using wm.dal.Models;
using wm.dal.Data;

namespace wm.tests.Repositories
{
    public class UserRepositoryTests
    {
        private WardrobeManagerContext _context { get; set; }

        [SetUp]
        public void Setup()
        {
            _context = Utilities.Generate();

            _context.Users.Add(new User
            {
                Username = "test1",
                Password = "3805C12FC67060217558470498B9266A077B049ECC5805EBF83B933EFAD6B049",
                Salt = "8523A3548BCF736E4F98B26A26FA6DED",
                FirstName = "test",
                LastName = "test",
                Email = "test1@pass.me"
            });
            _context.Users.Add(new User
            {
                Username = "test2",
                Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                Salt = "B3496A6A46E4E69DD7D89566B1187905",
                FirstName = "test",
                LastName = "test",
                Email = "test2@pass.me"
            });

            _context.SaveChanges();
        }

        [Test]
        public void Test_GetAll()
        {
            _context.ChangeTracker.Clear();

            List<User> expected = new(){
                new User
                {
                    Id = 1,
                    Username = "test1",
                    Password = "3805C12FC67060217558470498B9266A077B049ECC5805EBF83B933EFAD6B049",
                    Salt = "8523A3548BCF736E4F98B26A26FA6DED",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test1@pass.me"
                },
                new User
                {
                    Id = 2,
                    Username = "test2",
                    Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                    Salt = "B3496A6A46E4E69DD7D89566B1187905",
                    FirstName = "test",
                    LastName = "test",
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
            _context.ChangeTracker.Clear();

            User expected = new User
            {
                Id = 2,
                Username = "test2",
                Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                Salt = "B3496A6A46E4E69DD7D89566B1187905",
                FirstName = "test",
                LastName = "test",
                Email = "test2@pass.me"
            };

            UserRepository userRepository = new(_context);
            User actual = userRepository.GetUserById(2);

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_GetUserByUsername()
        {
            _context.ChangeTracker.Clear();

            User expected = new User
            {
                Id = 2,
                Username = "test2",
                Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                Salt = "B3496A6A46E4E69DD7D89566B1187905",
                FirstName = "test",
                LastName = "test",
                Email = "test2@pass.me"
            };

            UserRepository userRepository = new(_context);
            User actual = userRepository.GetUserByUsername("test2");

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_AddRow()
        {
            _context.ChangeTracker.Clear();
            
            List<User> expected = new(){
                new User
                {
                    Id = 1,
                    Username = "test1",
                    Password = "3805C12FC67060217558470498B9266A077B049ECC5805EBF83B933EFAD6B049",
                    Salt = "8523A3548BCF736E4F98B26A26FA6DED",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test1@pass.me"
                },
                new User
                {
                    Id = 2,
                    Username = "test2",
                    Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                    Salt = "B3496A6A46E4E69DD7D89566B1187905",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test2@pass.me"
                },
                new User
                {
                    Id = 3,
                    Username = "test3",
                    Password = "01F4D2ACFF5BBEC1FD02066ED306989D7BF086D1D2701EF4AFB3A615264A3611",
                    Salt = "E45CB102EFA7A799F06325615255DACB",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test3@pass.me"
                }
            };

            User newUser = new User
            {
                Username = "test3",
                Password = "01F4D2ACFF5BBEC1FD02066ED306989D7BF086D1D2701EF4AFB3A615264A3611",
                Salt = "E45CB102EFA7A799F06325615255DACB",
                FirstName = "test",
                LastName = "test",
                Email = "test3@pass.me"
            };

            UserRepository userRepository = new(_context);
            userRepository.AddRow(newUser);
            List<User> actual = userRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_DeleteRow()
        {
            _context.ChangeTracker.Clear();

            List<User> expected = new()
            {
                new User
                {
                    Id = 2,
                    Username = "test2",
                    Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                    Salt = "B3496A6A46E4E69DD7D89566B1187905",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test2@pass.me"
                }
            };

            User user = new User
            {
                Id = 1,
                Username = "test1",
                Password = "3805C12FC67060217558470498B9266A077B049ECC5805EBF83B933EFAD6B049",
                Salt = "8523A3548BCF736E4F98B26A26FA6DED",
                FirstName = "test",
                LastName = "test",
                Email = "test1@pass.me"
            };

            UserRepository userRepository = new(_context);
            userRepository.DeleteRow(user);
            List<User> actual = userRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }

        [Test]
        public void Test_UpdateRow()
        {
            _context.ChangeTracker.Clear();

            List<User> expected = new(){
                new User
                {
                    Id = 1,
                    Username = "test3",
                    Password = "01F4D2ACFF5BBEC1FD02066ED306989D7BF086D1D2701EF4AFB3A615264A3611",
                    Salt = "E45CB102EFA7A799F06325615255DACB",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test3@pass.me"
                },
                new User
                {
                    Id = 2,
                    Username = "test2",
                    Password = "529E0269FA4AFCCB7388CDAA1534B5A30A3653D47D05E6334AF442823FDDEE93",
                    Salt = "B3496A6A46E4E69DD7D89566B1187905",
                    FirstName = "test",
                    LastName = "test",
                    Email = "test2@pass.me"
                }
            };

            User user = new User
            {
                Id = 1,
                Username = "test3",
                Password = "01F4D2ACFF5BBEC1FD02066ED306989D7BF086D1D2701EF4AFB3A615264A3611",
                Salt = "E45CB102EFA7A799F06325615255DACB",
                FirstName = "test",
                LastName = "test",
                Email = "test3@pass.me"
            };

            UserRepository userRepository = new(_context);
            userRepository.UpdateRow(user);
            List<User> actual = userRepository.GetAll().ToList();

            Utilities.AreEqualByJson(actual, expected);
        }
    }
}