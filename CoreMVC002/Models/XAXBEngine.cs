using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreMVC002.Models
{
    public class XAXBEngine
    {
        public string Secret { get; private set; }
        public string Guess { get; private set; }
        public string Result { get; private set; }
        public List<GuessResult> GuessHistory { get; private set; }
        public int AttemptCount { get; private set; }

        public XAXBEngine()
        {
            Random random = new Random();
            Secret = random.Next(1000, 10000).ToString(); // Generates a random 4-digit number
            Guess = null;
            Result = null;
            GuessHistory = new List<GuessResult>();
            AttemptCount = 0;
        }

        public XAXBEngine(string secretNumber)
        {
            Secret = secretNumber;
            Guess = null;
            Result = null;
            GuessHistory = new List<GuessResult>();
            AttemptCount = 0;
        }

        public int NumOfA(string guessNumber)
        {
            return guessNumber.Zip(Secret, (g, s) => g == s).Count(match => match);
        }

        public int NumOfB(string guessNumber)
        {
            return guessNumber.Count(g => Secret.Contains(g)) - NumOfA(guessNumber);
        }

        public bool IsGameOver(string guessNumber)
        {
            AttemptCount++;
            Guess = guessNumber;
            int aCount = NumOfA(guessNumber);
            int bCount = NumOfB(guessNumber);
            Result = $"{aCount}A{bCount}B";
            GuessHistory.Add(new GuessResult { Guess = guessNumber, Result = Result });

            return aCount == 4; // Game over if all 4 digits are correct
        }

        public void Reset()
        {
            Random random = new Random();
            Secret = random.Next(1000, 10000).ToString(); // Resets with a new random number
            GuessHistory.Clear();
            AttemptCount = 0;
            Guess = null;
            Result = null;
        }
    }

    public class GuessResult
    {
        public string Guess { get; set; }
        public string Result { get; set; }
    }
}
