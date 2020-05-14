using System;
using System.Runtime.InteropServices;

namespace Lab4._1
{
    class Program
    {
        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(ref ProcessorInformation info);
        [DllImport("kernel32.dll")]
        public static extern bool GlobalMemoryStatusEx(ref MemoryStatus buffer);

        public struct ProcessorInformation
        {
            public ushort ProcessorArchitecture;
            public uint PageSize;
            public IntPtr MinimumApplicationAddress;
            public IntPtr MaximumApplicationAddress;
            public IntPtr ActiveProcessorMask;
            public uint NumberOfProcessors;
            public uint ProcessorType;
            public uint AllocationGranularity;
            public ushort ProcessorLevel;
            public ushort ProcessorRevision;
        }

        public struct MemoryStatus
        {
            public uint Length;
            public uint MemoryLoad;
            public ulong TotalPhys;
            public ulong AvailPhys;
            public ulong TotalPageFile;
            public ulong AvailPageFile;
            public ulong TotalVirtual;
            public ulong AvailVirtual;
            public ulong AvailExtendedVirtual;
        }
        static void Main(string[] args)
        {
            ProcessorInformation processor = new ProcessorInformation();
            GetSystemInfo(ref processor);
            String architecture = "";
            switch (processor.ProcessorArchitecture)
            {
                case 0:
                    {
                        architecture = "x86";
                        break;
                    }
                case 5:
                    {
                        architecture = "ARM";
                        break;
                    }
                case 6:
                    {
                        architecture = "Intel Itanium-based";
                        break;
                    }
                case 9:
                    {
                        architecture = "x64(AMD or Intel)";
                        break;
                    }
                case 12:
                    {
                        architecture = "ARM64";
                        break;
                    }
                default:
                    {
                        architecture = "Unknown architecture";
                        break;
                    }
            }
            Console.WriteLine("Processor architecture: {0}", architecture);
            Console.WriteLine("Processor type: {0}", processor.ProcessorType);
            Console.WriteLine("Number of CPUs: {0}", processor.NumberOfProcessors);
            Console.WriteLine("Processor level: {0}", processor.ProcessorLevel);
            Console.WriteLine("Processor revision: {0}", processor.ProcessorRevision);
            Console.WriteLine("Active processor mask: {0}", processor.ActiveProcessorMask);
            Console.WriteLine("Page size: {0}", processor.PageSize);
            Console.WriteLine("Allocation granularity: {0}", processor.AllocationGranularity);

            MemoryStatus memory = new MemoryStatus();
            memory.Length = (uint)Marshal.SizeOf(typeof(MemoryStatus));
            GlobalMemoryStatusEx(ref memory);
            Console.WriteLine($"\n\nThere is {memory.MemoryLoad}% of memory in use.");
            Console.WriteLine($"There are {memory.TotalPhys / 1024} total KB of physical memory " +
                $"({Math.Round(((double)memory.TotalPhys / Math.Pow(2, 30)), 2)} GB).");
            Console.WriteLine($"There are {memory.AvailPhys / 1024} free  KB of physical memory" + 
                $"({Math.Round(((double)memory.AvailPhys / Math.Pow(2, 30)), 2)} GB).");
            Console.WriteLine($"There are {memory.TotalPageFile / 1024} total KB of paging file" +
                $"({Math.Round(((double)memory.TotalPageFile / Math.Pow(2, 30)), 2)} GB).");
            Console.WriteLine($"There are {memory.AvailPageFile / 1024} free  KB of paging file" +
                $"({Math.Round(((double)memory.AvailPageFile / Math.Pow(2, 30)), 2)} GB).");
            Console.WriteLine($"There are {memory.TotalVirtual / 1024} total KB of virtual memory" +
                $"({Math.Round(((double)memory.TotalVirtual / Math.Pow(2, 30)), 2)} GB).");
            Console.WriteLine($"There are {memory.AvailVirtual / 1024} free  KB of virtual memory" +
                $"({Math.Round(((double)memory.AvailVirtual / Math.Pow(2, 30)), 2)} GB).");
            Console.WriteLine($"There are {memory.AvailExtendedVirtual / 1024} free  KB of extended memory.");
        }
    }
}
