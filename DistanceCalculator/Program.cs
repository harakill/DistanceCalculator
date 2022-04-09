// See https://aka.ms/new-console-template for more information

using DistanceCalculator;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var data = FileReader.ReadData();

stopwatch.Stop();
var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
Console.WriteLine($"Binary data file read execution time : {elapsedMilliseconds} ms");
stopwatch.Restart();

foreach (var vehicle in VehiclesList())
{
    var position = DataConverter.StackConvertData(data, FileReader.Index, FileReader.Length, vehicle);
    //Console.WriteLine(position.Count);
    Console.WriteLine($" Distance between { vehicle.Latitude } : { vehicle.Longitude } and { position.Latitude } : { position.Longitude } = { position.Distance } KM with Id { position.PositionId } ");
}

stopwatch.Stop();
Console.WriteLine($"Closest position calculation execution time : {stopwatch.ElapsedMilliseconds} ms");
Console.WriteLine($"Total execution time : {elapsedMilliseconds + stopwatch.ElapsedMilliseconds} ms");

Console.ReadKey();

List<Coordinate> VehiclesList()
{
    var coordinateList = new List<Coordinate>();

    coordinateList.Add(new Coordinate(34.544909, -102.100843));
    coordinateList.Add(new Coordinate(32.345544, -99.123124));
    coordinateList.Add(new Coordinate(33.234235, -100.214124));
    coordinateList.Add(new Coordinate(35.195739, -95.348899));
    coordinateList.Add(new Coordinate(31.895839, -97.789573));
    coordinateList.Add(new Coordinate(32.895839, -101.789573));
    coordinateList.Add(new Coordinate(34.115839, -100.225732));
    coordinateList.Add(new Coordinate(32.335839, -99.992232));
    coordinateList.Add(new Coordinate(33.535339, -94.792232));
    coordinateList.Add(new Coordinate(32.234235, -100.222222));

    return coordinateList;
}