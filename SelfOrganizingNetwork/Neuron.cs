using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfOrganizingNetwork
{
    public class Neuron
    {
        public double X { get; set; }
        public double Y { get; set; }

        private List<Neuron> neighbours;

        public double Tiredness { get; set; }

        public Neuron(double x, double y)
        {
            this.X = x;
            this.Y = y;

            neighbours = new List<Neuron>();
        }

        public Neuron(ObservablePoint obsPoint)
        {
            this.X = obsPoint.X;
            this.Y = obsPoint.Y;

            neighbours = new List<Neuron>();
        }

        public void AddNeighbour(Neuron neighbour)
        {
            neighbours.Add(neighbour);
        }

    }
}
