using System;

namespace RaspberryWiegandTestador
{
    public class Controlador
    {
        private LeitorWiegand leitor;

        public Controlador(LeitorWiegand leitor)
        {
            this.leitor = leitor;
        }

        public void processa()
        {
            bool aguardando = false;

            while (true)
            {
                if (!aguardando)
                {
                    aguardando = true;

                    try
                    {
                        var id = leitor.getDado();
                        Console.WriteLine($"ID: {id}");
                    }
                    finally
                    {
                        aguardando = false;
                    }
                }

                System.Threading.Thread.Sleep(350);
            }
        }
    }
}
