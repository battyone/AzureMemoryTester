using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AzureMemoryTester
{
    public class MemoryService
    {
        public int Allocations => buffers.Count;
        public long Allocated => buffers.Sum(b => b.LongLength);

        private static readonly List<byte[]> buffers = new List<byte[]>();

        public void Allocate(int mb = 100)
        {
            var buffer = new byte[mb * 1024 * 1024];

            byte b = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                b += buffer[i];
            }

            buffers.Add(buffer);

            var ri = new Random().Next(buffers.Count);

            buffer = buffers[ri];

            for (int i = 0; i < buffer.Length; i++)
            {
                b += buffer[i];
            }
        }

        public long GetGCMem()
        {
            return GC.GetTotalMemory(true);
        }

        public long GetProcessWS()
        {
            var p = Process.GetCurrentProcess();
            return p.WorkingSet64;
        }

        public long GetProcessPM()
        {
            var p = Process.GetCurrentProcess();
            return p.PrivateMemorySize64;
        }

        public long GetEnvWS()
        {
            return Environment.WorkingSet;
        }

        public bool Is64Bit()
        {
            return Environment.Is64BitProcess;
        }

    }
}
