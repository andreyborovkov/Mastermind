using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGeneratedArray = RandomGenerator.GetRandomGeneratedNumber(1,7,4);
            int attempt = 0; //# of the attempt
            var previousGuess = ""; //used to display different symbols depending on the user's guess

            Console.WriteLine("Guess a 4 Digit Number \n (+) - correct number, correct order; \n (-) - correct number, wrong order; \n ( ) - wrong number, wrong order");

            Console.WriteLine("Enter \"1\" to see the answer right away or anything else to continue.");
            string userResponse = Console.ReadLine();
            if (userResponse == "1")
            {
                PrintRandomGeneratedNumber(randomGeneratedArray);
            }

            //Exits the loop after attempt #10
            while (attempt < 10){
                previousGuess = "";
                attempt += 1;

                Console.WriteLine("Attempt " + attempt + ":");

                var userInput = Console.ReadLine();
                var userGuessIntArray = ConvertStringToIntArray(userInput, randomGeneratedArray);//Uses a method to convert user input to an int array

                PrintResultOfTheAttempt(previousGuess, randomGeneratedArray, userGuessIntArray);//displays the result of the guess in symbols
            }

            PrintRandomGeneratedNumber(randomGeneratedArray);
            Console.WriteLine("Game Over.");
            Thread.Sleep(4000);
        }

        private static int[] ConvertStringToIntArray(string userInput, int[] randomGeneratedArray)
        {
            //Validation
            if (userInput.Length < randomGeneratedArray.Length){
                Console.WriteLine("Not a " + randomGeneratedArray.Length + " digit value");
                userInput = "    ";
            }

            //Convertion
            var userGuessCharArray = userInput.ToCharArray();
            var userGuessIntArray = new int[userGuessCharArray.Length]; //every symbol after index 4 is ignored
            for (int i = 0; i < userGuessIntArray.Length; i++){
                // converts values of every member of the array from ASCII to regular value type. 
                userGuessIntArray[i] = userGuessCharArray[i] - '0';
            }

            return userGuessIntArray;
        }



        private static void PrintResultOfTheAttempt(string previousGuess, int[] randomGeneratedArray, int[] userGuessIntArray)
        {
            for (int i = 0; i < randomGeneratedArray.Length; i++)
            {
                if (randomGeneratedArray[i] == userGuessIntArray[i]){
                    previousGuess += "+";//adds a symbol to a string

                }
                else if (randomGeneratedArray.Contains(userGuessIntArray[i])){
                    previousGuess += "-";
                }
                else{
                    previousGuess += " ";
                }
            }
            Console.WriteLine(previousGuess);

            // Ends the game if the number is gueesed correctly
            if (previousGuess == "++++"){
                PrintRandomGeneratedNumber(randomGeneratedArray);
                Console.WriteLine("You've Won!");
                Thread.Sleep(4000);
                Environment.Exit(0);
            }
        }

        private static void PrintRandomGeneratedNumber(int[] randomGeneratedArray)//Outputs the Answer
        {
            Console.Write("The random generated number is ");

            for (int i = 0; i < randomGeneratedArray.Length; i++){
                Console.Write(randomGeneratedArray[i]);
            }

                Console.WriteLine();
        }
    }
}
