using System;
using System.Device.Gpio;

namespace RaspberryWiegandTestador
{
    public class LeitorWiegand
    {
        private int maxBits;
        private int pino0;
        private int pino1;
        private GpioController controller;

        public LeitorWiegand(int pino0, int pino1, int maxBits)
        {
            this.pino0 = pino0;
            this.pino1 = pino1;
            this.maxBits = maxBits;

            this.controller = new GpioController();

            controller.OpenPin(pino0, PinMode.Input);
            controller.OpenPin(pino1, PinMode.Input);

            Console.WriteLine($"GPIO DT0:{pino0} DT1:{pino1}");
        }

        public string getDado()
        {
            string IdBinario;
            int bits = 0;
            char[] s = new char[maxBits];

            while (true)
            {
                if (controller.Read(pino0) == PinValue.Low)
                {
                    s[bits++] = '0';
                    while (controller.Read(pino0) == PinValue.Low) { }
                }

                if (controller.Read(pino1) == PinValue.Low)
                {
                    s[bits++] = '1';
                    while (controller.Read(pino1) == PinValue.Low) { }
                }

                if (bits == maxBits)
                {
                    IdBinario = getBinario(s);
                    break;
                }
            }

            //Print(IdBinario);
            return getId(IdBinario);
        }

        private string getBinario(char[] s)
        {
            return new string(s);
        }

        public void Print(string IdBinario)
        {
            string cardNumber = IdBinario.Substring(0, maxBits);
            Int64 cardNumberDecimal = Convert.ToInt64(cardNumber, 2);

            Console.WriteLine($"Binary : {IdBinario}");
            Console.WriteLine($"Decimal: {cardNumberDecimal}");
            Console.WriteLine();
        }

        public string getId(string IdBinario)
        {
            string cardNumber = IdBinario.Substring(0, maxBits);
            Int64 cardNumberDecimal = Convert.ToInt64(cardNumber, 2);
            return cardNumberDecimal.ToString();
        }
    }
}
