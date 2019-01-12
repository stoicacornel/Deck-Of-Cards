using System.Collections.Generic;

namespace Deck_Of_Cards
{
    public class CardDeck
    {
        public List<Card> Cards = new List<Card>();

        public List<Card> CreateCardDeck()
        {
            string[] suiteList = {"clubs", "spades", "hearts", "diamonds"};

            for (int j = 0; j < suiteList.Length; j++)
            {
                for (var i = 0; i < 16; i++)
                {
                    var currentCard = new Card();
                
                    switch (i)
                    {
                        case 0:
                        case 1:
                        case 11:
                            currentCard = null;
                            break;
                        case 12:
                            currentCard.CardName = "J";
                            break;
                        case 13:
                            currentCard.CardName = "Q";
                            break;
                        case 14:
                            currentCard.CardName = "K";
                            break;
                        case 15:
                            currentCard.CardName = "A";
                            break;
                        default:
                            currentCard.CardName = i.ToString();
                            break;
                    }

                    if (currentCard != null)
                    {
                        currentCard.CardValue = i;
                        currentCard.CardSuit = suiteList[j];
                                
                        Cards.Add(currentCard);
                    }
                }
            }

            return Cards;
        }
    }
}