using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator
{
    internal static class DataConverter
    {
        internal static Position StackConvertData(byte[] data, int index, int count, Coordinate coordinate)
        {
            Stack<Position> stack = new Stack<Position>();
            while (index < count)
            {
                var position = new Position();
                position.PositionId = BitConverter.ToInt32(data, index);
                index += 4;

                //position.VehicleRegistration = Encoding.Default.GetString(data, index, 9);
                index += 10;

                position.Latitude = BitConverter.ToSingle(data, index);
                index += 4;

                position.Longitude = BitConverter.ToSingle(data, index);
                index += 4;

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
