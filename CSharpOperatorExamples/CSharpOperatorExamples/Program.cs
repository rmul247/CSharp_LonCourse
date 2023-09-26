﻿using System;

namespace CSharpOperatorExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unary Operators

            //++

            //E1
            string line = string.Empty;
            string exampleLabel = string.Empty;

            int a = 1;
            a++;
            //a equals 2
            exampleLabel = "E1: ";
            line = $"{exampleLabel}'a' equals {a}";

            LogToScreen(line);

            //!

            //E2
            bool b = true;
            bool c = !b;
            //c equals false
            exampleLabel = "E2: ";
            line = $"{exampleLabel}'c' equals {c}";

            LogToScreen(line);

            //Multiplicative
            //*

            //E3
            int d = 5;
            int e = d * 2;
            //e equals 10
            exampleLabel = "E3: ";
            line = $"{exampleLabel}'e' equals {e}";

            LogToScreen(line);

            // /

            //E4
            int f = 10;
            int g = f / 2;
            //g equals 5
            exampleLabel = "E4: ";
            line = $"{exampleLabel}'g' equals {g}";

            LogToScreen(line);

            // %

            //E5
            int h = 10;
            int i = h % 3;
            //i equals 1
            exampleLabel = "E5: ";
            line = $"{exampleLabel}'i' equals {i}";

            LogToScreen(line);

            //Additive Operators

            //+

            //E6
            int j = 20;
            int k = j + 5;
            //k equals 25
            exampleLabel = "E6: ";

            line = $"{exampleLabel}'k' equals {k}";

            LogToScreen(line);

            //-

            //E7
            int l = 20;
            int m = l - 5;
            //l equals 15
            exampleLabel = "E7: ";
            line = $"{exampleLabel}'m' equals {m}";

            LogToScreen(line);

            //Equality Operators

            //==

            //E8
            bool n = true;
            bool o = (n == false);
            //o equals false
            exampleLabel = "E8: ";
            line = $"{exampleLabel}'o' equals {o}";

            LogToScreen(line);

            //E9
            n = false;
            o = (n == false);
            //o equals true
            exampleLabel = "E9: ";
            line = $"{exampleLabel}'o' equals {o}";

            LogToScreen(line);

            //!=

            //E10
            n = true;
            o = (n != false);
            //o equals true
            exampleLabel = "E10: ";
            line = $"{exampleLabel}'o' equals {o}";

            LogToScreen(line);

            //E11
            n = false;
            o = (n != false);
            //o equals false
            exampleLabel = "E11: ";
            line = $"{exampleLabel}'o' equals {o}";

            LogToScreen(line);

            //Relational Operators

            // >

            //E12
            int p = 4;
            bool q = (p > 2);
            //q equals true
            exampleLabel = "E12: ";
            line = $"{exampleLabel}'q' equals {q}";

            LogToScreen(line);

            // <

            //13
            q = (p < 1);
            //q equals false
            exampleLabel = "E13: ";
            line = $"{exampleLabel}'q' equals {q}";

            LogToScreen(line);

            // >=

            //E14
            q = (p >= 4);
            //q equals true
            exampleLabel = "E14: ";
            line = $"{exampleLabel}'q' equals {q}";

            LogToScreen(line);

            //E15
            q = (p >= 5);
            //q equals false
            exampleLabel = "E15: ";
            line = $"{exampleLabel}'q' equals {q}";

            LogToScreen(line);

            // <=

            //E16
            q = (p <= 4);
            //q equals true
            exampleLabel = "E16: ";
            line = $"{exampleLabel}'q' equals {q}";

            LogToScreen(line);

            //E17
            q = (p <= 5);
            //q equals true
            exampleLabel = "E17: ";
            line = $"{exampleLabel}'q' equals {q}";

            LogToScreen(line);

            // is

            //E18
            object r = 12;
            bool s = (r is int);
            //s equals true
            exampleLabel = "E18: ";
            line = $"{exampleLabel}'s' equals {s}";

            LogToScreen(line);

            //E19
            r = 10.2;
            s = (r is float);
            //s equals false
            exampleLabel = "E19: ";
            line = $"{exampleLabel}'s' equals {s}";

            LogToScreen(line);

            //E20
            s = (r is double);
            //s equals true
            exampleLabel = "E20: ";
            line = $"{exampleLabel}'s' equals {s}";

            LogToScreen(line);

            // as

            //E21
            object t = "Hello world";
            string u = t as string;
            //u equals "Hello world"
            exampleLabel = "E21: ";
            line = $"{exampleLabel}'u' equals \"{u}\"";

            LogToScreen(line);

            //Logical, Conditional, and null operators

            //Logical

            // &

            //E22
            int v = 7;
            int w = v & 3;
            //w equals 3
            exampleLabel = "E22: ";
            line = $"{exampleLabel}'w' equals {w}";

            LogToScreen(line);

            // |

            //E23
            w = v | 3;
            //w equals 7
            exampleLabel = "E23: ";
            line = $"{exampleLabel}'w' equals {w}";

            LogToScreen(line);

            //Conditional

            // ?:
            //ternary

            //E24
            int x = 6;
            string y = (x < 6) ? "'x' is less than 6" : "'x' is greater than or equal to 6";
            //y equals "'x' is greater than or equal to 6"
            exampleLabel = "E24: ";
            line = $"{exampleLabel}'y' equals {y}";

            LogToScreen(line);

            // ??

            //E25
            string z = null;
            string a1 = z ?? "Hello world";
            //a1 equals "Hello world"
            exampleLabel = "E25: ";
            line = $"{exampleLabel}'a1' equals \"{a1}\"";

            LogToScreen(line);

            //Assignment and Compound Assignment

            //Assignment

            //=

            //E26
            int b1 = 500;
            //b1 equals 500
            exampleLabel = "E26: ";
            line = $"{exampleLabel}'b1' equals {b1}";

            LogToScreen(line);

            //Compound Assignment

            //+=

            //E27
            int c1 = 2;
            int d1 = b1;
            d1 += c1;
            //d1 equals 502
            exampleLabel = "E27: ";
            line = $"{exampleLabel}'d1' equals {d1}";

            LogToScreen(line);

            // *=

            //E28
            int e1 = b1;
            e1 *= c1;
            //e1 equals 1000
            exampleLabel = "E28: ";
            line = $"{exampleLabel}'e1' equals {e1}";

            LogToScreen(line);

            //Shift Operators

            // <<

            //E29
            int f1 = 8;
            int g1 = f1 << 1;
            //g1 equals 16
            exampleLabel = "E29: ";
            line = $"{exampleLabel}'g1' equals {g1}";

            LogToScreen(line);

            // >>

            //E30
            g1 = f1 >> 1;
            // g1 equals 4
            exampleLabel = "E30: ";
            line = $"{exampleLabel}'g1' equals {g1}";

            LogToScreen(line);

            Console.ReadKey();

            


        }

        public static void LogToScreen(string line)
        {
            Console.WriteLine(line);

        }

    }
}