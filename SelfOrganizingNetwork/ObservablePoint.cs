using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfOrganizingNetwork
{
    public class ObservablePoint
    {
        public ObservablePoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X
        {
            get;
            private set;
        }

        public double Y
        {
            get;
            private set;
        }

        public double Group
        {
            get;
            set;
        }

    }
}
