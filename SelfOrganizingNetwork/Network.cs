﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfOrganizingNetwork
{
    public class Network
    {
        private double maxX;
        private double minX;
        private double maxY;
        private double minY;

        private int width;
        private int height;

        public List<List<Neuron>> NetworkOfNeurons { get; set; }

        public Network(int width, int height, List<ObservablePoint> observableList)
        {
            NetworkOfNeurons = new List<List<Neuron>>();
            CountMaxsAndMinsCoordinates(observableList);

            this.width = width;
            this.height = height;

            for (int i = 0; i < width; i++)
            {
                NetworkOfNeurons.Add(new List<Neuron>());
            }

            FillNetwork();

            SetNeighborhood();

        }

        private void CountMaxsAndMinsCoordinates(List<ObservablePoint> observableList)
        {
            maxX = observableList.First().X;
            minX = observableList.First().X;
            maxY = observableList.First().Y;
            maxY = observableList.First().Y;

            foreach (ObservablePoint obsPoint in observableList)
            {
                if (obsPoint.X > maxX) maxX = obsPoint.X;
                if (obsPoint.X < minX) minX = obsPoint.X;
                if (obsPoint.Y > maxY) maxY = obsPoint.Y;
                if (obsPoint.Y < minY) minY = obsPoint.Y;
            }
        }

        private double ArrangementOfX(int width)
        {
            return (maxX - minX) / width;
        }

        private double ArrangementOfY(int height)
        {
            return (maxY - minY) / height;
        }

        private void FillNetwork()
        {
            double portionOfX = 0;
            double portionOfY = maxY;

            for (int i = 0; i < width; i++)
            {
                portionOfX += ArrangementOfX(width);
                portionOfY = maxY;

                for (int j = 0; j < height; j++)
                {
                    NetworkOfNeurons[i].Add(new Neuron(portionOfX,portionOfY));

                    portionOfY -= ArrangementOfY(height);
                }
            }
        }

        private void SetNeighborhood()
        {
            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    NetworkOfNeurons[i][j].AddNeighbour(NetworkOfNeurons[i + 1][j]);
                    NetworkOfNeurons[i + 1][j].AddNeighbour(NetworkOfNeurons[i][j]);

                    NetworkOfNeurons[i][j].AddNeighbour(NetworkOfNeurons[i][j + 1]);
                    NetworkOfNeurons[i][j + 1].AddNeighbour(NetworkOfNeurons[i][j]);
                }
            }

        }

    }
}
