using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimConnector.Structures;

namespace SimConnector
{
    public abstract class DataCollector
    {
        public abstract bool Initialize();

        public abstract CommonValueReturn GetData(ref CommonValues cValues);

        public abstract void CloseFiles();
    }
}
