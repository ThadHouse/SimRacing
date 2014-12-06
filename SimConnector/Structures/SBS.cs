using System;
using System.Runtime.InteropServices;

namespace SimConnector.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    [Serializable]
    public struct SimBinData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public float[] userInput;
        public float engineRPS;
        public float maxEngineRPS;
        public float fuelPressure;               // KPa
        public float fuelLiters;                 // Current liters of fuel in the tank(s).      
        public float fuelCapacityLiters;         // Maximum capacity of fuel tank(s).                     
        public float engineWaterTemp;            //                                                       
        public float engineOilTemp;              //                                                       
        public float engineOilPressure;          //                                                       

        public float carSpeed;                   // meters per second                                                    	
        public Int32 numberOfLaps;               // # of laps in race, or -1 if player is not in          
        // race mode (player is in practice or test mode).       

        public Int32 completedLaps;              // How many laps the player has completed.  If this      
        // value is 6, the player is on his 7th lap. -1 = n/a    

        public float lapTimeBest;                // Seconds.  -1.0 = none                                           
        public float lapTimePrevious;            // Seconds.  -1.0 = none                                           
        public float lapTimeCurrent;             // Seconds.  -1.0 = none                                           

        public Int32 position;                   // Current position.  1 = first place.                   
        public Int32 numCars;                    // Number of cars (including the player) in the race.    

        public Int32 gear;                       // -2 = no data available, -1 = reverse, 0 = neutral,          
        // 1 = first gear... (valid range -1 to 7).                

        /*
        public float tireTemp1;// = new float[ 3, 4 ];  // Temperature of three points  
         * */
        // across the tread of each tire.     

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] tireTempFrontLeft;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] tireTempFrontRight;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] tireTempRearLeft;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] tireTempRearRight;

        public Int32 numPenalties;               // Number of penalties pending for the player.           

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] carCGLoc;
        //public float carCGLoc1;
        //public float carCGLoc2;// = new float[3];                // Physical location of car's Center of Gravity in world space, X,Y,Z... Y=up.
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] carOri;// = new float[ 3 ];      // Pitch, Yaw, Roll. Electronic compass, perhaps?           
        //public float carOri1;
        //public float carOri2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] localAcceleration;// = new float[3];       // Acceleration in three axes (X, Y, Z) of car body (divide by 
        //public float localAcceleration1;
        //public float localAcceleration2;// 9.81 to get G-force).  From car center, +X=left, +Y=up, 
        // +Z=back.
        //End of SimBin Data
        public float SpeedInKmPerHour
        {
            get { return carSpeed * 3.60f; }
        }
        public float EngineRpm
        {
            get { return engineRPS * 9.549296f; }
        }
        public float MaxEngineRpm
        {
            get { return maxEngineRPS * 9.549296f; }
        }
    }
}
