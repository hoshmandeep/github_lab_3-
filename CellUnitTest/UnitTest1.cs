using Microsoft.VisualStudio.TestTools.UnitTesting;
using Psim.Particles;
using Psim.Geometry2D;
using System;
using Psim.ModelComponents;


namespace CellUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //check length and width
            Cell cell = new Cell(5, 5);
            Assert.AreEqual(5, cell.Length);
            Assert.AreEqual(5, cell.Width);

            //to addphonon and addIncphonon
            cell.AddPhonon(new Phonon(1));
            cell.AddIncPhonon(new Phonon(1));

            //check direction
            Phonon phonon = new Phonon(1);
            phonon.SetDirection(0.5, 0.5);

            //check direction after handlephonon
            BoundarySurface surface = new BoundarySurface(SurfaceLocation.left, new Cell(10, 10));
            surface.HandlePhonon(phonon);
            Assert.AreEqual(-0.5, phonon.Direction.DX);
            Assert.AreEqual(0.5, phonon.Direction.DY);
        }
    }
}
