
namespace DistanceCalculator
{
    /// <summary>
    /// A class that represent domain object
    /// </summary>
    internal class Position
    {
        internal int PositionId { get; set; }
        //internal string? VehicleRegistration { get; set; }
        internal double Latitude { get; set; }
        internal double Longitude { get; set; }
        //internal ulong RecordedTimeUTC { get; set; }
        internal double Distance { get; set; }
    }
}
