using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfOrganizingNetwork;

namespace Program_k_means
{
    class Program
    {
        static void Main(string[] args)
        {
            //// FORGY -------------------------------------------
            Console.WriteLine("FORGY:");
            Console.WriteLine("");

            int numberOfCenters_F = 30;
            Forgy forgy = new Forgy(numberOfCenters_F);

            int iterationsOfForgy = 0;
            forgy.TupleToObjects();
            forgy.RandCenters();
            forgy.AssignToCenter();

            Console.WriteLine("Poczatkowy przydział: ");
            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            do
            {
                forgy.CentreCoordinatesCorrection();
                forgy.AssignToCenter();
                forgy.MSECalculation();
                iterationsOfForgy++;

            } while (!forgy.CheckTheDiff());

            Console.WriteLine("Po " + iterationsOfForgy + " korektach koordynatow centrów: ");
            for (int i = 0; i < forgy.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + forgy.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            forgy.fileOp.SaveCenterList(forgy.centerList, "Centers_F_DF.txt");
            forgy.fileOp.SaveObservableList(forgy.observableList, "Observable_F_DF.txt");
            forgy.fileOp.SaveMSEList(forgy.mseValues, "MSE_F.txt");

            //// RANDOM PARTITION --------------------------------
            Console.WriteLine("RANDOM PARTITION:");
            Console.WriteLine("");

            int numberOfCenters_RP = 30;
            RandomPartition randPartition = new RandomPartition(numberOfCenters_RP);

            int iterationsOfRandomPartition = 0;
            randPartition.TupleToObjects();
            randPartition.RandomAssignToCenters();
            randPartition.CentreCoordinatesCorrection();
            randPartition.AssignToCenter();

            Console.WriteLine("Poczatkowy przydział: ");
            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            do
            {
                randPartition.CentreCoordinatesCorrection();
                randPartition.AssignToCenter();
                randPartition.MSECalculation();
                iterationsOfRandomPartition++;

            } while (!randPartition.CheckTheDiff());

            Console.WriteLine("Po " + iterationsOfRandomPartition + " korektach koordynatow centrów: ");
            for (int i = 0; i < randPartition.centerList.Count; i++)
            {
                Console.WriteLine("Do centrum " + i + " przypisano " + randPartition.centerList.ElementAt(i).listOfObsPoint.Count + " punktow obserwacji.");
            }
            Console.WriteLine("");

            randPartition.fileOp.SaveCenterList(randPartition.centerList, "Centers_RP_DF.txt");
            randPartition.fileOp.SaveObservableList(randPartition.observableList, "Observable_RP_DF.txt");
            randPartition.fileOp.SaveMSEList(randPartition.mseValues, "MSE_RP.txt");

        }
    }
}
