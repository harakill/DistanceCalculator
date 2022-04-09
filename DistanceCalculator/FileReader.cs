
namespace DistanceCalculator
{
    internal static class FileReader
    {
        private static int index;
        private static int length;

        internal static int Index { get => index; }
        internal static int Length { get => length; }

        public static byte[] ReadData()
        {
            using FileStream fs = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), "VehiclePositions.dat"));
            using BinaryReader reader = new BinaryReader(fs);

            index = (int)reader.BaseStream.Position;
            length = (int)reader.BaseStream.Length;

            return reader.ReadBytes(length);
        }
    }
}
