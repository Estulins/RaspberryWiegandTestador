using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RaspberryWiegandTestador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RaspberryWiegandTestador v1.0");
            Console.WriteLine($"  Arquitetura {RuntimeInformation.OSArchitecture}");
            Console.WriteLine($"  Executando em {RuntimeInformation.OSDescription}");

            int maxWiegandBits = 26;

            Task.Run(() =>
            {
                int pino0 = 19;
                int pino1 = 26;
                LeitorWiegand leitor = new LeitorWiegand(pino0, pino1, maxWiegandBits);

                Controlador controlador = new Controlador(leitor);
                controlador.processa();
            });

            Console.WriteLine("Executando Controlador com Leitor Protocolo Wiegand...");

            while(true)
            {
                System.Threading.Thread.Sleep(60000);
            }
        }
    }
}
