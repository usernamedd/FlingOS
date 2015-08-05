﻿using System;

namespace Testing1
{
    public static class Kernel
    {
        static bool x = false;

        [Drivers.Compiler.Attributes.PluggedMethod(ASMFilePath = "ASM\\Kernel")]
        [Drivers.Compiler.Attributes.SequencePriority(Priority = long.MinValue)]
        public static void Boot()
        {
        }

        [Drivers.Compiler.Attributes.MainMethod]
        [Drivers.Compiler.Attributes.NoGC]
        public static unsafe void Main()
        {
            LED.Blue();
            Delay();
            LED.Red();
            Delay();

            UART.Init();

            //UART.Write("Hello, world!\r\n");
            UART.Write('H');
            UART.Write('e');
            UART.Write('l');
            UART.Write('l');
            UART.Write('o');
            UART.Write(',');
            UART.Write(' ');
            UART.Write('w');
            UART.Write('o');
            UART.Write('r');
            UART.Write('l');
            UART.Write('d');
            UART.Write('!');
            UART.Write('\r');
            UART.Write('\n');

            while (true)
            {
                char c = UART.ReadChar();

                if (c == 'r' || c == 'R')
                {
                    LED.Red();
                }
                else if (c == 'b' || c == 'B')
                {
                    LED.Blue();
                }
                else if (c == 'p' || c == 'P')
                {
                    for (int i = 0; i < 10000 * 2; i++)
                    {
                        LED.Red();
                        LED.Blue();
                    }
                }
                else
                {
                    LED.Red();
                    Delay();
                    LED.Blue();
                    Delay();
                }

                UART.Write(c);
            }
        }
        [Drivers.Compiler.Attributes.CallStaticConstructorsMethod]
        public static void CallStaticConstructors()
        {
        }

        private static void Delay()
        {
            for (int i = 0; i < 10000; i++)
            {
                ;
            }
        }

        [Drivers.Compiler.Attributes.ThrowNullReferenceExceptionMethod]
        private static void ThrowNullReferenceException(uint eip)
        {
            UART.Write('N');
            UART.Write('u');
            UART.Write('l');
            UART.Write('l');
            UART.Write(' ');
            UART.Write('r');
            UART.Write('e');
            UART.Write('f');
            UART.Write('\r');
            UART.Write('\n');
        }
    }
}
