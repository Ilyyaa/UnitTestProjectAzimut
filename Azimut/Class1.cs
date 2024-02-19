using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azimut
{
    public class Point
    {
        double latitude;
        double longitude;
        public Point(double latitude_, double longitude_)
        {
            if(latitude_ < -90 || latitude_ > 90 ||
                longitude_ < -180 || Longitude > 180)
            throw new ArgumentOutOfRangeException();
            this.Latitude = latitude_;
            this.Longitude = longitude_;
        }

        public double Longitude { 
            get => longitude; 
            set {
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException();
                longitude = value; 
            }  
        }
        public double Latitude { 
            get => latitude;
            set {
                if (value < -180 || value > 180)
                    throw new ArgumentOutOfRangeException();
                latitude = value; 
            }
        }

    }
    public class DistanceAzimuth
    {
        Point a;
        Point b;
        public DistanceAzimuth(Point a_, Point b_) { 
           this.A = a_; this.B = b_;    
        }

        public Point A { get => a; set => a = value; }
        public Point B { get => b; set => b = value; }
    }
}
