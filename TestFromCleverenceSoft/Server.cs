using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestFromCleverenceSoft
{
    public static class Server
    {
        private static int Count;
        private static readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            Locker.EnterReadLock();
            try
            {
                return Count;
            }
            finally
            {
                Locker.ExitReadLock();
            }
        }
        public static void AddCount(int value)
        {
            Locker.EnterWriteLock();
            try
            {
                Count += value;
            }
            finally
            {
                Locker.ExitWriteLock();
            }
        }
    }
}