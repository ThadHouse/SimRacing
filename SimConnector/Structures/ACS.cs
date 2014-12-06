using System;
using System.Runtime.InteropServices;
namespace SimConnector.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    [Serializable]
    public struct ACStatic
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string SmVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string AcVersion;
        public int NumberOfSessions;
        public int NumCars;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string CarModel;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string Track;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string PlayerName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string PlayerSurname;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string PlayerNick;
        public int SectorCount;
        public float MaxTorque;
        public float MaxPower;
        public int MaxRpm;
        public float MaxFuel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspensionMaxTravel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreRadius;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    [Serializable]
    public struct ACPhysics
    {
        public int PacketId;
        public float Gas;
        public float Brake;
        public float Fuel;
        public int Gear;
        public int Rpms;
        public float SteerAngle;
        public float SpeedKmh;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Velocity;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] AccG;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelSlip;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelLoad;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelsPressure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] WheelAngularSpeed;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreWear;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreDirtyLevel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] TyreCoreTemperature;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] CamberRad;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] SuspensionTravel;

        public float Drs;
        public float TC;
        public float Heading;
        public float Pitch;
        public float Roll;
        public float CgHeight;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public float[] CarDamage;

        public int NumberOfTyresOut;
        public int PitLimiterOn;
        public float Abs;
    }

    public enum AcStatus
    {
        Off = 0,
        Replay = 1,
        Live = 2,
        Pause = 3
    }

    public enum AcSessionType
    {
        Unknown = -1,
        Practice = 0,
        Qualify = 1,
        Race = 2,
        Hotlap = 3,
        TimeAttack = 4,
        Drift = 5,
        Drag = 6
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    [Serializable]
    public struct ACGraphics
    {
        public int PacketId;
        public AcStatus Status;
        public AcSessionType Session;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string CurrentTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string LastTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string BestTime;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
        public string Split;
        public int CompletedLaps;
        public int Position;
        public int CurrentTimeValue;
        public int LastTimeValue;
        public int BestTimeValue;
        public float SessionTimeLeft;
        public float DistanceTraveled;
        public int IsInPit;
        public int CurrentSectorIndex;
        public int LastSectorTime;
        public int NumberOfLaps;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string TyreCompound;
        public float ReplayTimeMultiplier;
        public float NormalizedCarPosition;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] CarCoordinates;
    }
}
