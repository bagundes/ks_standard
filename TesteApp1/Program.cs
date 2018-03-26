using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestKSException();
        }


        static void TestKSException()
        {
            try
            {
                try
                {
                    string[] a = { "a", "b", "c" };
                    var b = a[3]; // Forcando excecao.
                }catch(Exception ex)
                {
                    throw new KS_Standard.KSException(ex);
                }



            }catch(Exception ex)
            {
                
                System.Console.WriteLine(ex.Message);

            }
        }
    }
}
