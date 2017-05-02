using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelfOrganizingNetwork;
using System.Linq;
using System.Collections.Generic;

namespace LibraryTests
{
    [TestClass]
    public class ForgyTest
    {
        private static int numberOfCenters = 6;
        private Forgy forgy;

        [TestInitialize]
        public void initialization()
        {
            numberOfCenters = 6;
            forgy = new Forgy(numberOfCenters);
        }

        [TestMethod]
        public void TupleToObjectsTest_F()
        {
            forgy.TupleToObjects();

            Assert.AreEqual(10000, forgy.observableList.Count);

            //PIERWSZE 10 LINII Z PLIKU JUZ PO PRZEPISANU NA OBIEKTY
            for (int i = 0; i < 10; i++)
            {
                Console.Write(forgy.observableList[i].X + " ");
                Console.Write(forgy.observableList[i].Y);
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void RandCentersTest_F()
        {
            forgy.TupleToObjects();
            forgy.RandCenters();

            Assert.AreEqual(numberOfCenters, forgy.centerList.Count);
        }

        [TestMethod]
        public void AssignToCenterTest_F()
        {
            forgy.TupleToObjects();
            forgy.RandCenters();
            forgy.AssignToCenter();

            Assert.AreEqual(numberOfCenters, forgy.centerList.Count);

            for(int i =0; i<forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            
        }

        [TestMethod]
        public void CentreCoordinatesCorrectionTest_F()
        {
            forgy.TupleToObjects();
            forgy.RandCenters();
            forgy.AssignToCenter();

            Assert.AreEqual(numberOfCenters, forgy.centerList.Count);

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            Console.WriteLine("Pojedyńcza korekta koordynatow centrów: ");
            forgy.CentreCoordinatesCorrection();
            forgy.AssignToCenter();

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Dziesięciokrotna korekta koordynatow centrów: ");
            for (int i = 0; i < 10; i++)
            {
                forgy.CentreCoordinatesCorrection();
                forgy.AssignToCenter();
            }
            
            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Pięćdziesięciokrotna korekta koordynatow centrów: ");
            for (int i = 0; i < 50; i++)
            {
                forgy.CentreCoordinatesCorrection();
                forgy.AssignToCenter();
            }

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Stukrotna korekta koordynatow centrów: ");
            for (int i = 0; i < 100; i++)
            {
                forgy.CentreCoordinatesCorrection();
                forgy.AssignToCenter();
            }

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            //Console.WriteLine("Tysiąckrotna korekta koordynatow centrów: ");
            //for (int i = 0; i < 1000; i++)
            //{
            //    forgy.CentreCoordinatesCorrection();
            //    forgy.AssignToCenter();
            //}

            //for (int i = 0; i < forgy.centerList.Count; i++)
            //{
            //    Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            //}
        }

        [TestMethod]
        public void CheckTheDiffTest_F()
        {
            int iterations = 0;
            forgy.TupleToObjects();
            forgy.RandCenters();
            forgy.AssignToCenter();

            Assert.AreEqual(numberOfCenters, forgy.centerList.Count);

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Pojedyńcza korekta koordynatow centrów: ");
            forgy.CentreCoordinatesCorrection();
            forgy.AssignToCenter();

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            do
            {
                forgy.CentreCoordinatesCorrection();
                forgy.AssignToCenter();
                iterations++;

            } while (!forgy.CheckTheDiff());

            Console.WriteLine("Po " + iterations + " korektach koordynatow centrów: ");

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Dodatkowa pięćdziesięciokrotna korekta koordynatow centrów by sprawdzic czy cokolwiek sie zmieni: ");
            for (int i = 0; i < 50; i++)
            {
                forgy.CentreCoordinatesCorrection();
                forgy.AssignToCenter();
            }

            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");


            forgy.fileOp.SaveCenterList(forgy.centerList, "Centers_F_DF.txt");
            forgy.fileOp.SaveObservableList(forgy.observableList, "Observable_F_DF.txt");
        }

    }
}
