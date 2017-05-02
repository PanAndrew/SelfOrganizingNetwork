using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelfOrganizingNetwork;

namespace LibraryTests
{
    [TestClass]
    public class FileOperationTest
    {
        private FileOperation fileOp = new FileOperation();
           
        [TestMethod]
        public void LoadCoordinates()
        {
            fileOp.LoadCoordinates();

            Assert.AreEqual(10000, fileOp.Coordinates.Count);

            //PIERWSZE 10 LINII WCZYTANYCH Z PLIKU
            for (int i = 0; i < 10; i++)
            {
                Console.Write(fileOp.Coordinates[i].Item1 + " ");
                Console.Write(fileOp.Coordinates[i].Item2);
                Console.WriteLine("");
            }
        }
    }
}
