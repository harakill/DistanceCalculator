using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator
{
    /// <summary>
    /// Data converter class
    /// </summary>
    internal static class DataConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Data byte array</param>
        /// <param name="index">First index in array</param>
        /// <param name="last">Last index in array</param>
        /// <param name="coordinate">Coordinate object</param>
        /// <returns>Position object with distance from specific coordinate</returns>
        internal static Position ConvertData(byte[] data, int index, int last, Coordinate coordinate)
        {
            Stack<Position> stack = new Stack<Position>();
            while (index < last)
            {
                var position = new Position();
                position.PositionId = BitConverter.ToInt32(data, index);
                index += 4;

                //disable for more performance
                //position.VehicleRegistration = Encoding.Default.GetString(data, index, 9);
                index += 10;

                position.Latitude = BitConverter.ToSingle(data, index);
                index += 4;

                position.Longitude = BitConverter.ToSingle(data, index);
                index += 4;

                //disable for more performance
                //position.RecordedTimeUTC = BitConverter.ToUInt64(data, index);
                index += 8;

                position.Distance = GeoCalculator.GetDistance(coordinate.Latitude, coordinate.Longitude, position.Latitude, position.Longitude, 'K');

                if (stack.Count == 0)
                    stack.Push(position);
                else
                {
                    if (stack.Peek().Distance > position.Distance)
                    {
                        stack.Push(position);
                    }
                }
            }
            return stack.Peek();
        }
    }
}
