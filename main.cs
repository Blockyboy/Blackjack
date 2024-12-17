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

    for(int i = 0; i < 52; i++)
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

    dealcards(2, pcards, deck);

    displaycards("Player", pcards);

    Console.WriteLine("");

    dealcards(2, dcards, deck);

    displaycards("Dealer", dcards);

    Console.WriteLine("");
    
    displaycards("Deck", deck);
    
  }

  public static void displaycards(string holdername, List<Card> card) 
  {
    Console.WriteLine(holdername + ":");
    foreach(Card a in card)
    {
      if(a.number == 11)
        {
          Console.Write("Jack");
        }
      else if(a.number == 12)
        {
          Console.Write("Queen");
        }
      else if(a.number == 13)
        {
          Console.Write("King");
        }
      else if(a.number == 1)
        {
          Console.Write("Ace");
        }
      else if(a.number < 11)
        {
          Console.Write(a.number);
        }

      Console.Write(" of ");
      
      Console.Write(a.suit);

      if (a != card.Last())
      {
        Console.Write(", ");
      }
    }
  }

  public static void dealcards(int ncards, List<Card> card, List<Card> deck)
  {
    Random rand = new Random();
    int index;
    for(int i = 0; i < ncards; i++)
      {
        index = rand.Next(deck.Count - 1);
        card.Add(deck[index]);
        deck.RemoveAt(index);
      }
  }
}