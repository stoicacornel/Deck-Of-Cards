using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Deck_Of_Cards
{
    internal class Program
    {
        public static List<Card> OurCardDeck = new List<Card>();
        public static List<Card> CardsDrawn = new List<Card>();

        public static void Main()
        {
            StartTheGame();

            CreateDeck();

            var userInputDecision = "";

            while (!(userInputDecision == "exit" || userInputDecision == "e"))
            {
                Console.WriteLine("What would you like to do now?");
                Console.WriteLine("[S]huffle Remained Cards, [R]e-shuffle All Deck, [D]raw, or [E]xit?");
                userInputDecision = Console.ReadLine();

                if (userInputDecision == null)
                {
                    Console.WriteLine("Please use an action.");
                }
                else
                {
                    userInputDecision = Regex.Replace(userInputDecision, @"\s+", "").ToLower();
                    
                    switch (userInputDecision)
                    {
                        case "s":
                        case "shuffle":
                        case "shuffleremainedcards":
                            DeckActions.Shuffle();
                            break;
                        case "r":
                        case "reshuffle":
                        case "re-shuffle":
                        case "re-shufflealldeck":
                        case "reshufflealldeck":
                            DeckActions.ShuffleAll();
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
        
        public static void StartTheGame()
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
        }
        
        public static void CreateDeck()
        {                 
            OurCardDeck = new CardDeck().CreateCardDeck();
            
            Console.WriteLine("The Deck of Cards is ready.");
        }
        
        public static void ExitApp()
        {            
            Console.WriteLine("Thank you for playing!");
            Console.Read();
        }

        public static void DrawFromDeck()
        {
            var userInputNrOfCardsToDraw = "none";

            while (userInputNrOfCardsToDraw == "none")
            {
                if (OurCardDeck.Count > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Deck currently has {0} cards left.", OurCardDeck.Count);
                    Console.WriteLine("How many cards would you like to draw?");
                }
                else
                {
                    Console.WriteLine("You ran out of Cards. We repacked the whole Deck for you");
                    DeckActions.ShuffleAll();
                    Console.WriteLine("How many cards would you like to draw?");
                }

                userInputNrOfCardsToDraw = Console.ReadLine();
                if (userInputNrOfCardsToDraw != null)
                {
                    userInputNrOfCardsToDraw = Regex.Replace(userInputNrOfCardsToDraw, @"\s+", "").ToLower();
                }

                int intNumberOfCards = int.TryParse(userInputNrOfCardsToDraw, out intNumberOfCards) ? intNumberOfCards : 0;
                
                if (intNumberOfCards != 0)
                {
                    if (OurCardDeck.Count + 1 > intNumberOfCards && intNumberOfCards > 0)
                    {
                        Console.WriteLine("Would you like me to [S]ort them for you? [Y]es or [N]o? [E]xit option available as well.");
                        var userInputSortingDecision = Console.ReadLine();
                        if (userInputSortingDecision != null)
                        {
                            userInputSortingDecision = Regex.Replace(userInputSortingDecision, @"\s+", "").ToLower();
                        }

                        var sortedDecisionMade = false;

                        while (!sortedDecisionMade)
                        {
                            switch (userInputSortingDecision)
                            {
                                case "s":
                                case "sort":
                                case "y":
                                case "yes":
                                case "please":
                                case "yesplease":
                                case "pleaseyes":
                                    sortedDecisionMade = true;
                                    CardsDrawn = DeckActions.DrawSorted(intNumberOfCards);
                                    
                                    // Redundant Code. Should be placed inside the Draw function but
                                    // I am respecting the Document that states Draw function to return a List of Cards
                                    // As such, I decided to use the List of Cards here
                                    for (int i = 0; i < CardsDrawn.Count; i++)
                                    {
                                        Console.WriteLine("Card drawn: {0} of {1}", CardsDrawn.ElementAt(i).CardName, CardsDrawn.ElementAt(i).CardSuit);
                                    }
                                    Console.WriteLine("Deck currently has {0} card{1} left.", OurCardDeck.Count, OurCardDeck.Count > 1 ? "s" : "");
                                    break;
                                case "n":
                                case "no":
                                case "noplease":
                                case "pleaseno":
                                    sortedDecisionMade = true;
                                    CardsDrawn = DeckActions.Draw(intNumberOfCards);
                                    
                                    // Redundant Code. Should be placed inside the Draw function but
                                    // I am respecting the Document that states Draw function to return a List of Cards
                                    // As such, I decided to use the List of Cards here
                                    for (int i = 0; i < CardsDrawn.Count; i++)
                                    {
                                        Console.WriteLine("Card drawn: {0} of {1}", CardsDrawn.ElementAt(i).CardName, CardsDrawn.ElementAt(i).CardSuit);
                                    }
                                    
                                    Console.WriteLine("Deck currently has {0} card{1} left.", OurCardDeck.Count, OurCardDeck.Count > 1 ? "s" : "");
                                    break;
                                case "e":
                                case "exit":
                                    sortedDecisionMade = true;
                                    ExitApp();
                                    break;
                                default:
                                    sortedDecisionMade = true;
                                    Console.WriteLine("Sorry, I don't know how to do that. Please chose one of the valid actions.");
                                    break;
                            }
                        }
                        
                        userInputNrOfCardsToDraw = intNumberOfCards.ToString();
                    }
                    else
                    {
                        if (intNumberOfCards > OurCardDeck.Count)
                        {
                            Console.WriteLine("Silly, you can't draw more cards than the whole Deck.");

                            userInputNrOfCardsToDraw = "none";
                        }
                        else
                        {
                            Console.WriteLine("Silly, you can't draw a negative number of cards.");
                            userInputNrOfCardsToDraw = "none";
                        }
                    }
                }
                else
                {
                    Console.WriteLine("How am I suppose to draw {0} ?", userInputNrOfCardsToDraw);
                    userInputNrOfCardsToDraw = "none";
                }
            }
        }
    }
}