using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineLib
{
    //kilometer app
    public class Kilometers
    {
        public OutputData CalculateSpeed(InputData inputData)
        {
            var timeSec = (inputData.Hour * 3600) + (inputData.Min * 60) + inputData.Sec;
            var mps = inputData.Distance / timeSec;
            var kph = (inputData.Distance / 1000.0f) / (timeSec / 3600.0f);
            var mph = kph / 1.609f;
            return new OutputData(mps, kph, mph);
        }
    }
    public sealed class InputData
    {
        public float Distance { get; }
        public float Hour { get; }
        public float Min { get; }
        public float Sec{ get; }
        public InputData(float distance, float hour, float min, float sec)
        {
            Distance = distance;
            Hour = hour;
            Min = min;
            Sec = sec;
        }
    }
    public sealed class OutputData
    {

        public string MetersPerSec { get; }
        public string KilometersPerHour { get; }
        public string MilesPerHour { get; }

        public OutputData(float meterpersec, float kmpersec, float milpersec)
        {
            MetersPerSec = $"Your speed in metres/sec is {meterpersec}";
            KilometersPerHour = $"Your speed in km/h is {kmpersec}";
            MetersPerSec = $"Your speed in miles/h is {milpersec}";
        }
    }
}
