using Lab2Solution;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Lab4Tests {
    public class BusinessLogicTest {
        IBusinessLogic bl;

        [SetUp]
        public void Setup() {
            bl = new BusinessLogic();
        }

        [Order(0)]
        [Test]
        public void AddEntryTest() {
            //Creating test data
            string testClue = "Test clue";
            string testAnswer = "Test answer";
            int testDifficulty = 1;
            string testDate = "10/19/2022";
            //Trying to add the entry to the database
            Assert.That(bl.AddEntry(testClue, testAnswer, testDifficulty, testDate), Is.EqualTo(EntryError.NoError));
        }

        [Order(1)]
        [Test]
        public void AddEntryForEditTest() {
            //Creating test data
            string testClue = "Test clue";
            string testAnswer = "Test answer";
            int testDifficulty = 1;
            string testDate = "10/19/2022";
            //Adding an entry to the database for editing later on
            Assert.That(bl.AddEntry(testClue, testAnswer, testDifficulty, testDate), Is.EqualTo(EntryError.NoError));
        }

        [Order(2)]
        [Test]
        public void AddEntryClueShortTest() {
            //Creating test data
            string testClue = string.Empty;
            string testAnswer = "Test answer";
            int testDifficulty = 1;
            string testDate = "10/19/2022";
            //Trying to add the entry to the database
            Assert.That(bl.AddEntry(testClue, testAnswer, testDifficulty, testDate), Is.EqualTo(EntryError.InvalidClueLength));
        }

        [Order(3)]
        [Test]
        public void AddEntryClueLongTest() {
            //Creating test data
            string testClue = "Test clue Test clue Test clue Test clue Test clue Test clue Test clue Test clue Test clue " +
                              "Test clue Test clue Test clue Test clue Test clue Test clue Test clue Test clue Test clue " +
                              "Test clue Test clue Test clue Test clue Test clue Test clue Test clue test";
            string testAnswer = "Test answer";
            int testDifficulty = 1;
            string testDate = "10/19/2022";
            //Trying to add the entry to the database
            Assert.That(bl.AddEntry(testClue, testAnswer, testDifficulty, testDate), Is.EqualTo(EntryError.InvalidClueLength));

        }

        [Order(4)]
        [Test]
        public void AddEntryAnswerShortTest() {
            //Creating test data
            string testClue = "Test clue";
            string testAnswer = string.Empty;
            int testDifficulty = 1;
            string testDate = "10/19/2022";
            //Trying to add the entry to the database
            Assert.That(bl.AddEntry(testClue, testAnswer, testDifficulty, testDate), Is.EqualTo(EntryError.InvalidAnswerLength));
        }

        [Order(5)]
        [Test]
        public void AddEntryAnswerLongTest() {
            //Creating test data
            string testClue = "Test clue";
            string testAnswer = "Test answer Test answer Test answer Test answer Test answer";
            int testDifficulty = 1;
            string testDate = "10/19/2022";
            //Trying to add the entry to the database
            Assert.That(bl.AddEntry(testClue, testAnswer, testDifficulty, testDate), Is.EqualTo(EntryError.InvalidAnswerLength));
        }

        [Order(6)]
        [Test]
        public void DeleteEntryDoesNotExistTest() {
            //Need to see how many entries we have in the database. After running these tests, we should have at least one entry in the db.
            int idToDelete = bl.GetEntries().Count + 1;
            //Try removing the entry
            Assert.That(bl.DeleteEntry(idToDelete), Is.EqualTo(EntryError.EntryNotFound));
        }

        [Order(7)]
        [Test]
        public void DeleteEntryExistTest() {
            //Need to see how many entries we have in the database. After running these tests, we should have at least one entry in the db.
            int idToDelete = bl.GetEntries().Count;
            //Try removing the entry
            Assert.That(bl.DeleteEntry(idToDelete), Is.EqualTo(EntryError.NoError));
        }

        [Order(8)]
        [Test]
        public void EditEntryTest() {
            //Creating test data
            string testClue = "New test clue";
            string testAnswer = "New test answer";
            int testDifficulty = 2;
            string testDate = "10/20/2022";
            int idToEdit = bl.GetEntries().Count;
            //Try and edit that entry
            Assert.That(bl.EditEntry(testClue, testAnswer, testDifficulty, testDate, idToEdit), Is.EqualTo(EntryError.NoError));
        }

        [Order(9)]
        [Test]
        public void EditEntryLittleDifficultyTest() {
            //Creating test data
            string testClue = "New test clue";
            string testAnswer = "New test answer";
            int testDifficulty = -1;
            string testDate = "10/20/2022";
            int idToEdit = bl.GetEntries().Count;
            //Try and edit that entry
            Assert.That(bl.EditEntry(testClue, testAnswer, testDifficulty, testDate, idToEdit), Is.EqualTo(EntryError.InvalidDifficulty));
        }

        [Order(10)]
        [Test]
        public void EditEntryLargeDifficultyTest() {
            //Creating test data
            string testClue = "New test clue";
            string testAnswer = "New test answer";
            int testDifficulty = 3;
            string testDate = "10/20/2022";
            int idToEdit = bl.GetEntries().Count;
            //Try and edit that entry
            Assert.That(bl.EditEntry(testClue, testAnswer, testDifficulty, testDate, idToEdit), Is.EqualTo(EntryError.InvalidDifficulty));
        }

        [Order(11)]
        [Test]
        public void EditEntryInvalidDateTest() {
            //Creating test data
            string testClue = "New test clue";
            string testAnswer = "New test answer";
            int testDifficulty = 2;
            string testDate = "10/20/20222";
            int idToEdit = bl.GetEntries().Count;
            //Try and edit that entry
            Assert.That(bl.EditEntry(testClue, testAnswer, testDifficulty, testDate, idToEdit), Is.EqualTo(EntryError.InvalidDate));
        }

        [Order(12)]
        [Test]
        public void GetEntriesTest() {
            //As long as the list being returned is greater than 0, that means our method is returning entries
            Assert.IsTrue(bl.GetEntries().Count > 0);
        }

        [Order(13)]
        [Test]
        public void DeleteTestEntry() {
            int idToDelete = bl.GetEntries().Count;
            Assert.That(bl.DeleteEntry(idToDelete), Is.EqualTo(EntryError.NoError));
        }
    }
}
