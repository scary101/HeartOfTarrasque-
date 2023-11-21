using ConsoleApp9;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Test
{
    [TestFixture]
    public class LeaderboardTests
    {
        private const string filePath = "C:\\Users\\user\\Desktop\\leaderboard1.json";

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void AddUserInList()
        {
            User user = new User
            {
                Name = "Вася",
                CharactersPerMinute = 120.0,
                CharactersPerSecond = 4.5
            };
            Leaderboard.AddUser(user);
            Assert.IsTrue(Leaderboard.users.Contains(user));
        }

        [Test]
        public void SaveUserInList()
        {
            Leaderboard.Save();
            Assert.IsTrue(File.Exists(filePath));
        }

        [Test]
        public void LoadUserInList()
        {
            User user = new User
            {
                Name = "Вася",
                CharactersPerMinute = 120,
                CharactersPerSecond = 4.5
            };
            Leaderboard.AddUser(user);

            Assert.IsNotEmpty(Leaderboard.users);
        }
        [Test]
        public void ShouldBeEmpty()
        {
            var value = TestPech.txt;
            Assert.IsFalse(string.IsNullOrEmpty(value), "Значение не является пустым");
        }
        [Test]
        public void Truetype()
        {
            var value = TestPech.txt;
            Assert.AreEqual(typeof(string), value.GetType());
        }
    }

}