using System;
namespace jessielesbian.IKVM
{
    public static class Helper
    {
        public static int optpasses = 0;
        public static bool experimentalOptimizations
        {
            get
            {
                return (optpasses > 0);
            }
        }
    }
}