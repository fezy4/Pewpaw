using System.Security.Principal;
using System.Threading;
using System;
using fa;
using System.Threading.Tasks;

namespace fa
{
    public class Printer
    {
        private  SemaphoreSlim semafork = new SemaphoreSlim(10);
        private  Random random = new Random();

        public async Task PrintDocumentAsync(int rabotyaga)
        {
            await semafork.WaitAsync();
            try
            {
                Console.WriteLine($"Работяга {rabotyaga} начал ");

                int vremya = random.Next(1000, 3001);
                await Task.Delay(vremya);

                Console.WriteLine($"Работяга {rabotyaga} закончил ");
            }
            finally
            {
                semafork.Release();
            }
        }
    }
    public class Programka
    {
        public static async Task Main(string[] args)
        {
            var ks = new Printer();
            var zada4a = new List<Task>();
            for (int i = 1; i <= 20; i++)
            {
                int rabotyaga = i;

                zada4a.Add(ks.PrintDocumentAsync(rabotyaga));
            }
            await Task.WhenAll(zada4a);
        }
    }
}



 





