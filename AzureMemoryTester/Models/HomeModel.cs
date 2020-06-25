namespace AzureMemoryTester.Models
{
    public class HomeModel
    {
        public int Allocations { get; set; }
        public long Allocated { get; set; }
        public long ProcessWS { get; set; }
        public long GCMem { get; internal set; }
        public long EnvWS { get; internal set; }
        public bool Is64Bit { get; internal set; }
        public long ProcessPM { get; internal set; }
    }
}