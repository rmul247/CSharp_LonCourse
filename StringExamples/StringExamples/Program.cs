using System;
using System.Text;

namespace StringExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ways to initialize string objects
            string string1;
            string string2 = null; // does not reference a String object, any call by method will cause null ref. exception
            string string3 = String.Empty; // instance of string that is has 0 characters
            string string4 = "C:\\ExamplePath\\ExampleFolder"; // '\' used as escape character
            string string5 = @"C:\ExamplePath\ExampleFolder"; // '@' used to force string to be interpreted verbatum
            String string6 = "Latest string";
            var string7 = "Implicit string";
            const string string8 = "This text cannot be changed at runtime";

            char[] charArray = new char[] { 'H', 'e', 'l', 'l', 'o' };
            string string9 = new string(charArray);

            Console.WriteLine(string9);
            Console.WriteLine();
            Console.WriteLine();

            //Conversion of value types to string
            int i = 12;
            decimal d = 1.12579m;
            char c = 'c';
            bool b = false;

            string iString = i.ToString();
            string dString = d.ToString();
            string cString = c.ToString();
            string bString = b.ToString();

            Console.WriteLine($"i = {iString} \nd = {dString} \nc = {cString} \nb = {bString}\n");

            //--
            //Regular and Verbatim string examples
            string regularString = "The best Superman movie is \"Superman2\"";
            string verbatumString = @"The best Superman movie is ""Superman2""";

            Console.WriteLine($"Regular string: \t{regularString}");
            Console.WriteLine($"Verbatum string: \t{verbatumString}");

            Console.WriteLine();
            Console.WriteLine();

            //Examples of using escape sequences
            string stringExample1 = "Superman has saved the day once again.\nSuperman is a hero!";
            Console.WriteLine(stringExample1);
            Console.WriteLine();

            string stringExample2 = "Superman\tWonder Woman\tThe Invisible Man";
            Console.WriteLine(stringExample2);
            Console.WriteLine();

            string stringExample3 = "Superman is an \u0041 grade super hero.";
            Console.WriteLine(stringExample3);
            Console.WriteLine();
            Console.WriteLine();

            //Strings are immutable
            string narrative = "Superman comes from the planet Krypton.";
            string narrative2 = narrative;

            narrative += "\nSuperman is an illegal alien!";

            Console.WriteLine(narrative2); //will print original/unmodified string
            Console.WriteLine(narrative); //will print modified string

            Console.WriteLine();
            Console.WriteLine();

            //String Interpolation and Composite Formatting
            int numFloors = 102;
            bool canJump = true;

            Console.WriteLine($"It is {canJump} to say that Superman can leap in a single bound over the Empire State Building which is {numFloors} stories high.");
            Console.WriteLine();

            // these next two do the exact same thing
            //Console.WriteLine(String.Format("It is {0} to say that Superman can leap in a single bound over the Empire State Building which is {1} stories high.", canJump, numFloors));
            //Console.WriteLine();

            //Console.WriteLine("It is {0} to say that Superman can leap in a single bound over the Empire State Building which is {1} stories high.", canJump, numFloors);
            //Console.WriteLine();

            Console.WriteLine();

            //Substring related methods - Substring, replace, indexOf

            string mainString = "Superman is imperviouse to gun fire.";
            string subString = mainString.Substring(12, 10);
            string subString2 = "gun";
            string subString3 = "missile";

            Console.WriteLine(subString);
            Console.WriteLine();

            Console.WriteLine(mainString.Replace(subString2, subString3));
            Console.WriteLine();

            Console.WriteLine($"The index position of '{subString}' in our main string is {mainString.IndexOf(subString)}");
            Console.WriteLine();
            Console.WriteLine();

            //Accessing individual characters of a string

            string superman = "Superman";

            for(int idx = 0; idx <= superman.Length - 1; idx++)
            {
                //Console.Write(superman[idx]);
                Console.Write(superman[superman.Length - idx - 1]);
            }

            Console.WriteLine();
            Console.WriteLine();

            //StringBuilder class
            //StringBuilder objects are mutable, can enhance performance

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Superstring theory is an attempt");
            sb.AppendLine("to explain all of the particles and");
            sb.AppendLine("fundamental forces of nature in");
            sb.AppendLine("one theory by modeling them");
            sb.AppendLine("as vibrations of tiny");
            sb.AppendLine("supersymmetric strings.");

            sb[8] = 'a';

            string txt = sb.ToString();

            Console.WriteLine(txt);
            Console.ReadKey();
        }
    }
}
