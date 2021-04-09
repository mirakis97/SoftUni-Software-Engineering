// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StageTests
    {
        private Performer performer;
        private Stage stage;
        private Song song;

        [SetUp]
        public void SetUp()
        {
            performer = new Performer("Azis", "Ivanov", 19);
            stage = new Stage();
            song = new Song("Sen Trope", new TimeSpan(0, 3, 30));
        }
        [Test]
        public void TestConstructor()
        {
            var stage1 = new Stage();

            Assert.AreEqual(0, stage1.Performers.Count);
        }

        [Test]
        public void AddPerformerShouldTrowsException()
        {
            var invalidPerformer = new Performer("Azis", "Stoqnov", 17);
            var ex = Assert.Throws<ArgumentException>(() => { stage.AddPerformer(invalidPerformer); });

            Assert.AreEqual("You can only add performers that are at least 18.",ex.Message);
        }
        [Test]
        public void AddPerformer()
        {
            stage.AddPerformer(performer);
            int count = 1;
            Assert.AreEqual(count, stage.Performers.Count);
        }
        [Test]
        public void AddSongShouldTrowsException()
        {
            var invalidSong = new Song("Sen Trope", new TimeSpan(0, 0, 30));
            var ex = Assert.Throws<ArgumentException>(() => { stage.AddSong(invalidSong); });

            Assert.AreEqual("You can only add songs that are longer than 1 minute.", ex.Message);
        }
        [Test]
        public void AddSong()
        {
            stage.AddSong(song);

        }
        [Test]
        public void AddSongToPerformerTest()
        {
            stage.AddSong(song);
            stage.AddPerformer(performer);

            var message = stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual($"{song} will be performed by {performer}",message);

        }
        [Test]
        public void Test_Play()
        {
            var performer2 = new Performer("Toni", "Storaro", 30);

            stage.AddPerformer(performer);
            stage.AddPerformer(performer2);

            var song2 = new Song("Ako edna zvezda si", new TimeSpan(0, 3, 40));

            stage.AddSong(song);
            stage.AddSong(song2);


            stage.AddSongToPerformer(song.Name, performer.FullName);
            stage.AddSongToPerformer(song2.Name, performer2.FullName);

            var message = stage.Play();

            Assert.AreEqual($"2 performers played 2 songs", message);

        }
        [Test]
        public void GetPerformer_ThrowsExeption()
        {
            var invalidPerformer = new Performer("Toni", "Storaro", 16);

            stage.AddPerformer(performer);
            stage.AddSong(song);

            var ex = Assert.Throws<ArgumentException>(() => { stage.AddSongToPerformer(song.Name,invalidPerformer.FullName); });

            Assert.AreEqual("There is no performer with this name.", ex.Message);
        }
        [Test]
        public void GetSong_ThrowsExeption()
        {
            var invalidSong = new Song("Ako edna zvezda si", new TimeSpan(0, 3, 40));

            stage.AddPerformer(performer);
            stage.AddSong(song);

            var ex = Assert.Throws<ArgumentException>(() => { stage.AddSongToPerformer(invalidSong.Name, performer.FullName); });

            Assert.AreEqual("There is no song with this name.", ex.Message);
        }
        [Test]
        public void Song_ThrowsExeptionWhenIsNull ()
        {

            stage.AddPerformer(performer);

            var ex = Assert.Throws<ArgumentNullException>(() => { stage.AddSong(null); });

            Assert.AreEqual("Can not be null! (Parameter 'song')", ex.Message);
        }
        [Test]
        public void Performe_ThrowsExeptionWhenIsNull()
        {

            stage.AddSong(song);

            var ex = Assert.Throws<ArgumentNullException>(() => { stage.AddPerformer(null); });

            Assert.AreEqual("Can not be null! (Parameter 'performer')", ex.Message);
        }
    }
}
