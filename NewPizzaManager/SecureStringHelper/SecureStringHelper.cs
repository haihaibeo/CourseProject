using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public static class SecureStringHelper
    {
        /// <summary>
        /// Unsecure a <see cref="SecureString"/> to a normal string by reading it's location on memory
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
                return String.Empty;

            var unsecureString = IntPtr.Zero;

            try
            {
                unsecureString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unsecureString);
            }
            finally
            {
                // clean up memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unsecureString);
            }
        }
    }
}
