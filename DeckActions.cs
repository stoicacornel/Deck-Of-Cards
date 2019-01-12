using System;
using System.Collections.Generic;
using System.Linq;

namespace Deck_Of_Cards
{
    public class DeckActions
    {
        public static void Shuffle()
        {
            Program.OurCardDeck.Shuffle();

//            For Testing:
//            for (int i = 0; i < Program.OurCardDeck.Count; i++)
//            {
//                Console.WriteLine("Card {0} of {1}", Program.OurCardDeck.ElementAt(i).CardName, Program.OurCardDeck.ElementAt(i).CardSuit);
//            }
        }
        
        public static void ShuffleAll()
        {
            Program.CreateDeck();
            Program.OurCardDeck.Shuffle();
        }

        // Redundant Code. Draw and DrawSorted functions should be only one function with a optional arg but
        // I am respecting the Document that states that there should be 2 functions: Draw and DrawSorted
        // Ex: public static List<Card> Draw(int howMany, bool sorted = false)
        public static List<Card> Draw(int howMany)
        {
            var cardsLeftToDraw = howMany;
            List<Card> cardsReturned = new List<Card>();
            
            while (cardsLeftToDraw > 0)
            {
                cardsReturned.Add(Program.OurCardDeck.ElementAt(Program.OurCardDeck.Count - 1));
                cardsLeftToDraw--;
                Program.OurCardDeck.RemoveAt(Program.OurCardDeck.Count - 1);
            }
            
            return cardsReturned;
        }
        
        // Redundant Code. Draw and DrawSorted functions should be only one function with a optional arg but
        // I am respecting the Document that states that there should be 2 functions: Draw and DrawSorted
        // Ex: public static List<Card> Draw(int howMany, bool sorted = false)
        public static List<Card> DrawSorted(int howMany)
        {
            var cardsLeftToDraw = howMany;
            List<Card> cardsReturned = new List<Card>();
            
            while (cardsLeftToDraw > 0)
            {
                cardsReturned.Add(Program.OurCardDeck.ElementAt(Program.OurCardDeck.Count - 1));
                cardsLeftToDraw--;
                Program.OurCardDeck.RemoveAt(Program.OurCardDeck.Count - 1);
            }

            cardsReturned = cardsReturned.OrderBy(card => card.CardSuit).ThenBy(card => -card.CardValue).ToList();
            
            return cardsReturned;
        }
    }
}