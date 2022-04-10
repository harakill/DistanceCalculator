using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator
{
    /// <summary>
    /// To calculate distance and cardinal direction between two sets of coordinates and provides the lat/long
    /// </summary>
    internal static class GeoCalculator
    {
        /// <summary>
        /// This routine calculates the distance between two points
        /// </summary>
        /// <param name="lat1">lat1 = Latitude of point 1 (in decimal degrees)</param>
        /// <param name="lon1">lon1 = Longitude of point 1 (in decimal degrees)</param>
        /// <param name="lat2">lat2 = Latitude of point 2 (in decimal degrees)</param>
        /// <param name="lon2">lon2 = Longitude of point 2 (in decimal degrees)</param>
        /// <param name="unit">unit = the unit you desire for results where: 'M' is statute miles (default), 'K' is kilometers and 'N' is nautical miles</param>
        /// <returns>Double distance between point1 and point2</returns>
        internal static double GetDistance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(Deg2rad(lat1)) * Math.Sin(Deg2rad(lat2)) + Math.Cos(Deg2rad(lat1)) * Math.Cos(Deg2rad(lat2)) * Math.Cos(Deg2rad(theta));
                dist = Math.Acos(dist);
                dist = Rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                return (dist);
            }
        }

        /// <summary>
        /// This function converts decimal degrees to radians
        /// </summary>
        /// <param name="deg">double degree</param>
        /// <returns>double radian</returns>
        private static double Deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        /// <summary>
        /// This function converts radians to decimal degrees
        /// </summary>
        /// <param name="rad">double radian</param>
        /// <returns>double degree</returns>
        private static double Rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
