using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mediatheque.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Mediatheque.Core.DAL;
using System.Text.RegularExpressions;

namespace Mediatheque.Core.Service.Tests
{
    [TestClass()]
    public class MediathequeServiceTests
    {
        [TestMethod()]
        public void ReturnCDWhenNirvana()
        {
            //Arrange
            var applicationDbContextMock = new Mock<IApplicationDbContext>();
            applicationDbContextMock.Setup(a => a.GetCDs()).Returns(new List<Model.CD>()
            {
                new Model.CD ("Smell like Teen Spirit", "Nirvana") ,
                new Model.CD ("titre", "Nirvana"),
                new Model.CD ("titre 2", "Nirvana"),
                new Model.CD ("toto", "ACDC"),
                new Model.CD ("toto", "Aerosmith"),
                new Model.CD ("toto", "PLK"),
                new Model.CD ("toto", "Eminem"),
                new Model.CD ("toto", "Jonhy"),
                new Model.CD ("toto", "The Mackenzie"),
                new Model.CD ("toto", "The Nirvana"),
            });
            var mediathequeService = new MediathequeService(applicationDbContextMock.Object);
            var testCD = applicationDbContextMock.Object.GetCDs();

            //Act
            var actual = mediathequeService.GetCdsByGroupe("Nirvana");

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
            Assert.IsTrue(actual.All(cd => cd.Groupe == "Nirvana"));
        }
    }
}