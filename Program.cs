using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Deck_Of_Cards
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // App vars
            const string appName = "Deck Of Cards";
            const string appVersion = "1.0.0";
            const string appAuthor = "Cornel Stoica";

            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("{0}: Version - {1}", appName, appVersion);
            Console.WriteLine("Author: {0}", appAuthor);
            Console.WriteLine("");
           
            //Reset the colour and move on
            Console.ResetColor();

            CreateDeck();
            
            Console.WriteLine("The Deck of Cards is ready.");           
            Console.WriteLine("");
            var inputUserDecision = "";

            while ( inputUserDecision != "exit" || inputUserDecision != "e")
            {
                Console.WriteLine("What would you like to do now?");
                Console.WriteLine("");
                Console.WriteLine("[S]huffle Deck, [D]raw, or [E]xit?");
                var nonSanitizedUserInput = Console.ReadLine();

                if (nonSanitizedUserInput == null)
                {
                    Console.WriteLine("Please use an action.");
                }
                else
                {
                    Regex.Replace(inputUserDecision, @"\s+", "");
                    inputUserDecision = nonSanitizedUserInput.ToLower();
                    
                    switch (inputUserDecision)
                    {
                        case "s":
                        case "shuffle":
                        case "shuffledeck":
                            Deck.Shuffle();
                            break;
                        case "d":
                        case "draw":
                            DrawFromDeck();
                            break;
                        case "e":
                        case "exit":
                            ExitApp();
                            break;
                        default:
                            Console.WriteLine("Sorry, I don't know how to do that. Please chose one of the valid actions.");
                            break;
                    }
                }
            }
        }
        
        public static void CreateDeck()
        {            
            
        }
        

        public static void DrawFromDeck()
        {
            var nonSanitizedNumberOfCardsToDraw = "none";

            while (nonSanitizedNumberOfCardsToDraw == "none")
            {
                Console.WriteLine("How many cards would you like to draw?");

                nonSanitizedNumberOfCardsToDraw = Console.ReadLine();
                if (nonSanitizedNumberOfCardsToDraw != null)
                {
                    Regex.Replace(nonSanitizedNumberOfCardsToDraw, @"\s+", "");
                    nonSanitizedNumberOfCardsToDraw = nonSanitizedNumberOfCardsToDraw.ToLower();
                }

                int intNumberOfCards = int.TryParse(nonSanitizedNumberOfCardsToDraw, out intNumberOfCards) ? intNumberOfCards : 0;
                
                if (intNumberOfCards != 0)
                {
                    if (intNumberOfCards > 0)
                    {
                        Console.WriteLine("Would you like me to [S]ort them for you? [Y]es or [N]o?");
                        var inputUserSortingConfirmation = Console.ReadLine();
                        if (inputUserSortingConfirmation != null)
                        {
                            Regex.Replace(inputUserSortingConfirmation, @"\s+", "");
                            inputUserSortingConfirmation = inputUserSortingConfirmation.ToLower();
                        }

                        var inputSortedValid = false;

                        while (!inputSortedValid)
                        {
                            switch (inputUserSortingConfirmation)
                            {
                                case "s":
                                case "sort":
                                case "y":
                                case "yes":
                                case "please":
                                case "yesplease":
                                case "pleaseyes":
                                    inputSortedValid = true;
                                    Deck.DrawSorted(intNumberOfCards);
                                    break;
                                case "n":
                                case "no":
                                case "noplease":
                                case "pleaseno":
                                    inputSortedValid = true;
                                    Deck.Draw(intNumberOfCards);
                                    break;
                                case "e":
                                case "exit":
                                    inputSortedValid = true;
                                    ExitApp();
                                    break;
                                default:
                                    // inputSortedValid is already false
                                    Console.WriteLine("Sorry, I don't know how to do that. Please chose one of the valid actions.");
                                    break;
                            }
                        }
                        
                        nonSanitizedNumberOfCardsToDraw = intNumberOfCards.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Silly, you can't draw a negative number of cards.");
                        nonSanitizedNumberOfCardsToDraw = "none";
                    }
                }
                else
                {
                    Console.WriteLine("How am I suppose to draw " + nonSanitizedNumberOfCardsToDraw + " ?");
                    nonSanitizedNumberOfCardsToDraw = "none";
                }
            }
            
            
            
            
        }
        
        public static void ExitApp()
        {            
            
        }
    }
    
    internal class Deck
    {
        
        public static void Shuffle()
        {            
            
        }

        public static List<Card> Draw(int howMany)
        {
            
        }

        public static List<Card> DrawSorted(int howMany)
        {            
            
        }
    }
}