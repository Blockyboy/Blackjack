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
    bool gameover = false;
    
    int cardindex = 0;

    bool pbust = false;
    bool dbust = false;
    
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

    dealcards(2, dcards, deck);

    dealcards(2, pcards, deck);
    
    while(!gameover)
    {

       displaycards("Player", pcards);

      Console.WriteLine("");
      cardtotal(pcards, pbust);

       Console.WriteLine("");

       displaycards("Dealer", dcards);

       Console.WriteLine("");
       cardtotal(dcards, dbust);

       Console.WriteLine("");
      
       playerturn(pcards, deck);

       Console.Clear();
      
    }

    
  }
  public static void displaycards(string holdername, List<Card> card) //Displays the cads of the given list
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

  public static void dealcards(int ncards, List<Card> card, List<Card> deck) //Deals cards to given list
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

  public static void playerturn(List<Card> pcards, List<Card> deck) //Gets player input on turn
  {
    Console.WriteLine("Hit (H) or Stand (S) ?");
      string choice = Console.ReadLine().ToUpper();

      if(choice == "H")
      {
        Console.Clear();
        Console.WriteLine("Hit");
        dealcards(1, pcards, deck);
      }
      else if(choice == "S")
      {
        Console.Clear();
        Console.WriteLine("Stand");
      }
  }

  public static void cardtotal(List<Card> card, bool bust) //Calculates total value of cards in list
  {
    int total = 0;
    int total2 = 0;
    
    bool showtotal2 = false;
    
    foreach(Card a in card)
    {
      if(a.number > 10)
      {
        total += 10;
        total2 += 10;
      }
      else
      {
        total += a.number;
        if(a.number == 1)
        {
          total2 += 11;
          showtotal2 = true;
        }
        else
        {
          total2 += a.number;
        }
      }
    }

    if(total > 21)
    {
      bust = true;
    }

    if(!bust)
    {
      if(total2 > 21)
      {
        showtotal2 = false;
      } 

      Console.Write(total);

      if(showtotal2)
      {
        Console.Write(" or ");
        Console.Write(total2);
      }
    }
    else
    {
      Console.Write("Bust");
    }
    
  }
}