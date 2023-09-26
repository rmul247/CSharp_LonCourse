using System;

namespace SwitchStatementExample
{
    class Program
    {
        static int maxScore = 3;

        static void Main(string[] args)
        {

            Console.WriteLine("What is the best country in the world?");
            string answer = Console.ReadLine();

            int score = Question1(answer);

            DisplayScore(score);

            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();

            //Run test code
            //testScoreSwitch();

            Console.ReadKey();
        }

        public static void testScoreSwitch()
        {
            for (int i = -2; i < 5; i++)
            {
                Console.WriteLine($"Test No.: {i}");
                DisplayScore(i);
                Console.WriteLine();
            }

        }

        private static int Question1(string answer)
        {
            int score = 0;
            const int correctAnswerPoint = 1;
            const int bonusPoints = 2;

            switch (answer.ToUpper())
            {
                case "IRELAND":
                    Console.WriteLine("Correct answer");
                    score += correctAnswerPoint;

                    Console.WriteLine("For bonus points, what is the best county?");
                    var bonusAnswer = Console.ReadLine();

                    switch (bonusAnswer.ToUpper())
                    {
                        case "KERRY":
                            Console.WriteLine("Correct answer!");
                            score += bonusPoints;
                            break;
                        case "DUBLIN":
                            Console.WriteLine("No way Jose");
                            break;
                        case "GALWAY":
                            Console.WriteLine("Close, thats the second best.");
                            break;
                        default:
                            Console.WriteLine("Incorrect answer");
                            break;
                    }

                    break;
                case "ITALY":
                    Console.WriteLine("Close, that is the second best!");
                    break;
                case "UK":
                case "ENGLAND":
                case "WALES":
                case "SCOTLAND":
                    Console.WriteLine("Wouldn't be the worst, but one of the worst!");
                    break;
                default:
                    Console.WriteLine("Incorrect answer");
                    break;
            }

            return score;
        }

        private static void DisplayScore(int score)
        {
            switch (score)
            {
                case 0:
                    Console.WriteLine("You scored no points.");
                    break;
                case 1:
                    Console.WriteLine($"You scored '{score}/{maxScore}' points available. Better luck next time");
                    break;
                case 3:
                    Console.WriteLine($"Full score, '{score}/{maxScore}'. You are a genius, probably.");
                    break;
                default:
                    Console.WriteLine("Invalid Score.");
                    break;
            }
        }
    }
}
