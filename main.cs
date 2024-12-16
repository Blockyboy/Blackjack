using System;
using System.Collections.Generic;
using System.Linq;

public class Card
{
  public string suit;
  public int number;
}

class Program 
{
  public static void Main (string[] args) 
  {
    int cardindex = 0;
    
    Console.WriteLine ("Blackjack");
    
    List<Card> deck = new List<Card>();
    List<Card> pcards= new List<Card>();
    List<Card> dcards= new List<Card>();

    foreach(var a in Enumerable.Range(0,52)) //Creates slots for deck
    {
      deck.Add(new Card());
    }
    
    for (int i = 1; i < 14; i++) //Creates card (11, 12 and 13 are Jack, Queen and King)
    {
      deck[cardindex].suit = "Hearts";
      deck[cardindex].number= i;
      ++cardindex;
      
      deck[cardindex].suit = "Clubs";
      deck[cardindex].number= i;
      ++cardindex;
      
      deck[cardindex].suit = "Spades";
      deck[cardindex].number= i;
      ++cardindex;
      
      deck[cardindex].suit = "Diamonds";
      deck[cardindex].number= i;
      ++cardindex;
    }

    foreach(Card a in deck)
    {
      Console.Write(a.suit);
      Console.Write(Convert.ToString(a.number));
      Console.WriteLine("");
    }
  }
}