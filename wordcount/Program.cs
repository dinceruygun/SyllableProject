using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyllableProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SyllableLibrary syllble=new SyllableLibrary();
            Syllables ss = syllble.GetSyllableWords("şebinkarahisarlılar");
        }
    }
}
