using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimConnector.Structures;
using System.IO;

namespace SimConnector
{
    class SimBin : DataCollector
    {
        private bool _initialized;

        private int _errorCount;
        static string _memoryFile = "";

        private SimBinData _data;

        public SimBinData Data { get { return _data; } }

        private readonly SimBinReader _simBinReader;

        public SimBin()
        {
            _initialized = false;
            _errorCount = 0;
            _simBinReader = new SimBinReader();
        }

        public override bool Initialize()
        {
            if (_initialized) return true;

            bool found = false;

            for (int i = 0; i < 3; i++)
            {
                if (!found)
                {
                    switch (i)
                    {
                        case 0:
                            _memoryFile = "Local\\$gtr2$";
                            try
                            {
                                _simBinReader.Initialize();

                                _initialized = true;

                                found = true;
                            }
                            catch (FileNotFoundException e)
                            {
                            }
                            break;
                        case 1:
                            _memoryFile = "Local\\$gtlegends$";
                            try
                            {
                                _simBinReader.Initialize();

                                _initialized = true;

                                found = true;
                            }
                            catch (FileNotFoundException e)
                            {
                            }
                            break;
                        default:
                            _memoryFile = "Local\\$Race$";
                            try
                            {
                                _simBinReader.Initialize();

                                _initialized = true;

                                found = true;
                            }
                            catch (FileNotFoundException e)
                            {
                            }

                            break;
                    }
                }
            }

            return found;
        }

        private double _prevLapTime = 0;

        public override CommonValueReturn GetData(ref CommonValues cValues)
        {
            if (!_initialized) return CommonValueReturn.NotInitialized;

            _data = _simBinReader.Read();

            if (cValues == null)
                cValues = new CommonValues();

            cValues.BestTimeSeconds = _data.lapTimeBest;
            cValues.CurrentTimeSeconds = _data.lapTimeCurrent;

            cValues.MaxFuel = _data.fuelCapacityLiters;
            cValues.FuelRemaining = _data.fuelLiters;

            cValues.MaxRPM = _data.MaxEngineRpm;
            cValues.SpeedKPH = _data.SpeedInKmPerHour;
            cValues.Gear = _data.gear + 2;
            cValues.RPM = _data.EngineRpm;

            cValues.Position = _data.position;

            if (_prevLapTime == cValues.CurrentTimeSeconds)
            {
                _errorCount++;
            }
            else
            {
                _errorCount = 0;
            }

            _prevLapTime = cValues.CurrentTimeSeconds;

            if (_errorCount > 40)
            {
                CloseFiles();
                return CommonValueReturn.FileNotBeingUpdated;

            }
            return CommonValueReturn.Success;
        }

        public override void CloseFiles()
        {
            _simBinReader.CloseFile();
            _initialized = false;
            _errorCount = 0;
            _prevLapTime = 0;
            _memoryFile = "";
        }

        internal class SimBinReader : SharedMemoryReader<SimBinData>
        {
            protected override string Filename
            {
                get { return _memoryFile; }
            }
        }
    }
}
