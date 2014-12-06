using System;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace SimConnector
{
    internal abstract class SharedMemoryReader<T>
    {
        private MemoryMappedFile _mmf = null;
        public MemoryMappedFile MemoryMappedFile { get { return _mmf; } }

        protected abstract string Filename { get; }

        public void Initialize()
        {
            // Open the MMF
            _mmf = MemoryMappedFile.OpenExisting(this.Filename);
        }

        public T Read()
        {
            // Open a view stream to read the MMF
            using (var stream = _mmf.CreateViewStream())
            {
                using (var reader = new BinaryReader(stream))
                {
                    // Read a number of bytes equal to the size of the struct
                    var size = Marshal.SizeOf(typeof(T));
                    var bytes = reader.ReadBytes(size);

                    // Pin the handle 
                    var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);

                    // Copy the data to our struct
                    var data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));

                    // Free the handle
                    handle.Free();

                    return data;
                }
            }
        }

        public void CloseFile()
        {
            _mmf.Dispose();
            _mmf = null;
        }

        ~SharedMemoryReader()
        {
            _mmf.Dispose();
            _mmf = null;
        }
        
        /*
        void IDisposable.Dispose()
        {
            _mmf.Dispose();
            _mmf = null;
        }
         * */

    }
}
