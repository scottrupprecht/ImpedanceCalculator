using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DataAccess.Test
{
    [TestFixture]
    public class SpeakerDaoTest
    {
        private SpeakerDao _speakerDao;

        [SetUp]
        public void SetUp()
        {
            _speakerDao = new SpeakerDao();
        }

        [Test]
        public void GetAllSpeakers_excecute()
        {
           Console.WriteLine(JsonConvert.SerializeObject(_speakerDao.GetAllSpeakers()));
        }
    }
}
