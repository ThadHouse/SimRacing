using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimConnector.Structures
{
    public class CommonValues
    {
        public int Gear { get; set; }
        public double SpeedKPH { get; set; }

        public double MaxRPM { get; set; }
        public double RPM { get; set; }

        public double FuelRemaining { get; set; }
        public double MaxFuel { get; set; }

        public int Position { get; set; }

        public double CurrentTimeSeconds { get; set; }

        public double BestTimeSeconds { get; set; }





    }

    public enum CommonValueReturn { Success, NotInitialized, FileNotBeingUpdated }
}
