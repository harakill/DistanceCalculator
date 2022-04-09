
namespace DistanceCalculator
{
    internal class Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        internal double Latitude { get; set; }
        internal double Longitude { get; set; }
    }
}
