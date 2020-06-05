using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyClassLibraryBuild.MyClass
{
     class MyLibraryHandler
    {
         public static int RndGen(int min, int max)
         {
             Thread.Sleep(1);
             Random rnd = new Random(DateTime.Now.Millisecond);
             return rnd.Next(min, max);
         }
    }
}
