using System;
using System.Collections.Generic;

namespace jumper
{
    public class Director
    {

        private bool isPlaying = true;
        private string chosenWord;

        private TerminalService terminalService = new TerminalService();
        public Word Word = new Word();
        private Jumper jumper = new Jumper();
        public int tries = 0;
        public int numberOfGuesses = 0;

        private bool checkInput;

        List<char> guessedLetters = new List<char>();

        public string currentGuess = "test";

        public Director()
        {
        }

        public void StartGame()
        {
            StartUp();
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }


        private void StartUp()
        {
            Console.WriteLine("\nHint: Animals");
            chosenWord = Word.pullWord();
            Word.listWord(chosenWord);
            Word.createHiddenWord();
            Word.printGuess();
        }
        private void GetInputs()
        {
            Console.WriteLine("\n");
            jumper.printJumper(tries);
            checkInput = true;
            while (checkInput){
                currentGuess = terminalService.ReadGuess("\nGuess a letter [a-z]: ");
                checkInput = jumper.checkInput(guessedLetters, currentGuess);
            }
            guessedLetters.Add(currentGuess[0]);
            

        }


        private void DoUpdates()
        {
            numberOfGuesses = guessedLetters.Count;
            int usedTries = Word.compare(guessedLetters, numberOfGuesses);
            tries = tries + usedTries;
            isPlaying = jumper.checkJumper(Word.guess, tries);
        }


        private void DoOutputs()
        {
            Console.WriteLine("\n");
            if (isPlaying){
                Word.printGuess();
            }
            else {
                jumper.printJumper(tries);
                Word.printAnswer();
                Console.WriteLine("\n");
            }
  
        }
    }
}