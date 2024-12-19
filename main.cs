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
    bool playagain = true;
    
    while(playagain)
    {
      bool pbust = false;
      bool pturnend= false;
      bool dbust = false;
      bool dealerhide = true;

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

      dealcards(2, dcards, deck);

      dealcards(2, pcards, deck);

      while(!gameover)
      {

         displaycards("Player", pcards, false);

        Console.WriteLine("");
        cardtotal(pcards, ref pbust, true);

        if(pbust)
        {
          pturnend = true;
        }

         Console.WriteLine("");

         displaycards("Dealer", dcards, dealerhide);

         Console.WriteLine("");

        if(pturnend)
        {
          dealerturn(dcards, deck,dbust,ref gameover);
          dealerhide = false;
          cardtotal(dcards, ref dbust, true);
        }
        else
        {
           playerturn(pcards, deck, ref pturnend);
        }

        if(gameover)
        {
          Console.ReadLine();
        } 

         Console.Clear();
      }

      if(pbust && dbust)
      {
        Console.WriteLine("Draw");
      }
      if(pbust && !dbust)
      {
        Console.WriteLine("Dealer Wins");
      }
      if(!pbust && dbust)
      {
        Console.WriteLine("Player Wins");
      }
      if(!pbust && !dbust)
      {
        if(cardtotal(pcards, ref pbust, false) > cardtotal(dcards, ref dbust, false))
        {
          Console.WriteLine("Player Wins");
        }
        if(cardtotal(pcards, ref pbust, false) < cardtotal(dcards, ref dbust, false))
        {
          Console.WriteLine("Dealer Wins");
        }
        if(cardtotal(pcards, ref pbust, false) == cardtotal(dcards, ref dbust, false))
        {
          Console.WriteLine("Draw");
        }
      }

      Console.WriteLine("Play Again Y/N?");
      string playchoice = Console.ReadLine().ToUpper();

      if(playchoice == "Y")
      {
        playagain = true;
        gameover = false;
      }
      else
      {
        playagain = false;
      }
      Console.Clear();
    }
  }
  public static void displaycards(string holdername, List<Card> card, bool dealerhide) //Displays the cads of the given list
  {
    List<Card> temp = new List<Card>(card);
    if(dealerhide)
    {
      temp.RemoveAt(0);
    }
    Console.WriteLine(holdername + ":");
    foreach(Card a in temp)
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
      if(dealerhide)
      {
        Console.Write(", ?");
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

  public static void playerturn(List<Card> pcards, List<Card> deck, ref bool pturnend) //Gets player input on turn
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
        pturnend = true;
      }
  }

  public static void dealerturn(List<Card> card, List<Card> deck, bool dbust, ref bool gameover) //Begins dealer turn
  {
     if(cardtotal(card, ref dbust, false) < 17)
    {
      dealcards(1, card, deck);
    }
    else
    {
      gameover = true;
    }
  }

  public static int cardtotal(List<Card> card, ref bool bust, bool displaycards) //Calculates total value of cards in list
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

    if(total2 > 21)
    {
      showtotal2 = false;
    } 
    
    if(displaycards)
    {
      if(!bust)
      {
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
      return 0;
    }
    else
    {
      if(showtotal2)
      {
        return total2;
      }
      return total;
    }
    
  }
}