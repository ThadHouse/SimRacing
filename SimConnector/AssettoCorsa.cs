using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using SimConnector.Structures;

namespace SimConnector
{
    
    public class AssettoCorsa : DataCollector
    {
        private bool _initialized;

        private int _packetNumber, _errorCount;

        private readonly PhysicsReader _physicsReader;
        private readonly GraphicsReader _graphicsReader;
        private readonly StaticReader _staticReader;

        private ACStatic _staticData;
        private ACGraphics _graphicsData;
        private ACPhysics _physicsData;

        public ACStatic StaticData { get { return _staticData; } }
        public ACGraphics GraphicsData { get { return _graphicsData; } }
        public ACPhysics PhysicsData { get { return _physicsData; } }

        public AssettoCorsa()
        {
            _initialized = false;
            _packetNumber = 0;
            _errorCount = 0;
            _physicsReader = new PhysicsReader();
            _graphicsReader = new GraphicsReader();
            _staticReader = new StaticReader();
        }

        public override bool Initialize()
        {
            if (_initialized) return true;

            try
            {
                _physicsReader.Initialize();
                _graphicsReader.Initialize();
                _staticReader.Initialize();

                _initialized = true;
                return true;
            }
            catch (FileNotFoundException e)
            {
                return false;
            }
        }

        public override CommonValueReturn GetData(ref CommonValues cValues)
        {
            if (!_initialized) return CommonValueReturn.NotInitialized;
            _staticData = _staticReader.Read();
            _physicsData = _physicsReader.Read();
            _graphicsData = _graphicsReader.Read();

            if (cValues == null)
                cValues = new CommonValues();

            cValues.BestTimeSeconds = _graphicsData.BestTimeValue/1000.0;
            cValues.CurrentTimeSeconds = _graphicsData.CurrentTimeValue/1000.0;

            cValues.FuelRemaining = _physicsData.Fuel;

            cValues.MaxFuel = _staticData.MaxFuel;

            cValues.MaxRPM = _staticData.MaxRpm;

            cValues.SpeedKPH = _physicsData.SpeedKmh;

            cValues.Gear = _physicsData.Gear + 1;
            cValues.RPM = _physicsData.Rpms;

            cValues.Position = _graphicsData.Position;

            var pNum = _graphicsData.PacketId;

            if (pNum == _packetNumber)
            {
                _errorCount++;
            }
            else
            {
                _errorCount = 0;

            }

            _packetNumber = pNum;

            //Testing Multimple Computers

            if (_errorCount > 40)
            {
                //Close Files
                _physicsReader.CloseFile();
                _staticReader.CloseFile();
                _graphicsReader.CloseFile();
                _initialized = false;
                _errorCount = 0;
                _packetNumber = 0;
                return CommonValueReturn.FileNotBeingUpdated;
            }

            return CommonValueReturn.Success;

        }

        internal class PhysicsReader : SharedMemoryReader<ACPhysics>
        {
            protected override string Filename
            {
                get { return MmfFileNames.Physics; }
            }
        }

        internal class GraphicsReader : SharedMemoryReader<ACGraphics>
        {
            protected override string Filename
            {
                get { return MmfFileNames.Graphics; }
            }
        }

        internal class StaticReader : SharedMemoryReader<ACStatic>
        {
            protected override string Filename
            {
                get { return MmfFileNames.Static; }
            }
        }

        protected static class MmfFileNames
        {
            public static string Physics = "Local\\acpmf_physics";
            public static string Graphics = "Local\\acpmf_graphics";
            public static string Static = "Local\\acpmf_static";
        }
    }
}
