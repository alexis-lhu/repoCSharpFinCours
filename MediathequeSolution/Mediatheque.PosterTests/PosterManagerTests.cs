using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mediatheque.Poster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediatheque.Poster.Tests
{
    [TestClass()]
    public class PosterManagerTests
    {
        [TestMethod()]
        public async Task GetPosterAsyncTestAsync()
        {
            PosterManager posterManager = new PosterManager();

            var retour = await posterManager.GetPosterAsync("Matrix");

            Assert.Fail();
        }
    }
}