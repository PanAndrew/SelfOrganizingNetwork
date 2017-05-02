﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelfOrganizingNetwork;
using System.Linq;

namespace LibraryTests
{
    [TestClass]
    public class RandomPartitionTest
    {
        private static int numberOfCenters;
        private RandomPartition randPartition;

        [TestInitialize]
        public void initialization()
        {
            numberOfCenters = 6;
            randPartition = new RandomPartition(numberOfCenters);
        }

        [TestMethod]
        public void TupleToObjectsTest_RP()
        {
            randPartition.TupleToObjects();

            Assert.AreEqual(10000, randPartition.observableList.Count);

            //PIERWSZE 10 LINII Z PLIKU JUZ PO PRZEPISANU NA OBIEKTY
            for (int i = 0; i < 10; i++)
            {
                Console.Write(randPartition.observableList[i].X + " ");
                Console.Write(randPartition.observableList[i].Y);
                Console.WriteLine("");
            }
        }

        [TestMethod]
        public void RandCentersTest_RP()
        {
            randPartition.TupleToObjects();
            randPartition.RandCenters();

            Assert.AreEqual(numberOfCenters, randPartition.centerList.Count);
        }

        [TestMethod]
        public void AssignToCenterTest_RP()
        {
            randPartition.TupleToObjects();
            randPartition.RandCenters();
            randPartition.RandomAssignToCenters();
            //randPartition.AssignToCenter();

            Assert.AreEqual(numberOfCenters, randPartition.centerList.Count);

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }

        }

        [TestMethod]
        public void CentreCoordinatesCorrectionTest_RP()
        {
            randPartition.TupleToObjects();
            randPartition.RandCenters();
            randPartition.RandomAssignToCenters();
            //randPartition.AssignToCenter();

            Assert.AreEqual(numberOfCenters, randPartition.centerList.Count);

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            Console.WriteLine("Pojedyńcza korekta koordynatow centrów: ");
            randPartition.CentreCoordinatesCorrection();

            randPartition.AssignToCenter();

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Dziesięciokrotna korekta koordynatow centrów: ");
            for (int i = 0; i < 10; i++)
            {
                randPartition.CentreCoordinatesCorrection();
                randPartition.AssignToCenter();
            }

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            randPartition.fileOp.SaveCenterList(randPartition.centerList, "Centers_RP1.txt");
            randPartition.fileOp.SaveObservableList(randPartition.observableList, "Observable_RP1.txt");

            //-------------------------------------------------------------------
            Console.WriteLine("Pięćdziesięciokrotna korekta koordynatow centrów: ");
            for (int i = 0; i < 50; i++)
            {
                randPartition.CentreCoordinatesCorrection();
                randPartition.AssignToCenter();
            }

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Stukrotna korekta koordynatow centrów: ");
            for (int i = 0; i < 100; i++)
            {
                randPartition.CentreCoordinatesCorrection();
                randPartition.AssignToCenter();
            }

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            //Console.WriteLine("Tysiąckrotna korekta koordynatow centrów: ");
            //for (int i = 0; i < 1000; i++)
            //{
            //    randPartition.CentreCoordinatesCorrection();
            //    randPartition.AssignToCenter();
            //}

            //for (int i = 0; i < randPartition.centerList.Count; i++)
            //{
            //    Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            //}
            randPartition.fileOp.SaveCenterList(randPartition.centerList, "Centers_RP2.txt");
            randPartition.fileOp.SaveObservableList(randPartition.observableList, "Observable_RP2.txt");
        }

        [TestMethod]
        public void CheckTheDiffTest_RP()
        {
            int iterations = 0;
            randPartition.TupleToObjects();
            randPartition.RandCenters();
            randPartition.RandomAssignToCenters();
            //randPartition.AssignToCenter();

            Assert.AreEqual(numberOfCenters, randPartition.centerList.Count);

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Pojedyńcza korekta koordynatow centrów: ");
            randPartition.CentreCoordinatesCorrection();
            randPartition.AssignToCenter();

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            do
            {
                randPartition.CentreCoordinatesCorrection();
                randPartition.AssignToCenter();
                iterations++;

            } while (!randPartition.CheckTheDiff());

            Console.WriteLine("Po " + iterations + " korektach koordynatow centrów: ");

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");
            //-------------------------------------------------------------------
            Console.WriteLine("Dodatkowa pięćdziesięciokrotna korekta koordynatow centrów by sprawdzic czy cokolwiek sie zmieni: ");
            for (int i = 0; i < 50; i++)
            {
                randPartition.CentreCoordinatesCorrection();
                randPartition.AssignToCenter();
            }

            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            randPartition.fileOp.SaveCenterList(randPartition.centerList, "Centers_RP_DF.txt");
            randPartition.fileOp.SaveObservableList(randPartition.observableList, "Observable_RP_DF.txt");
        }
    }
}
