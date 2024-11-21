using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Casino
{
    internal class Program
    {
        static void otherGame(string? Customer)
        {
            int GameChosen;
            Console.WriteLine("please choose what would you like to play (by pressing the number designated): ");
            Console.WriteLine(" 1.Roulette \n 2.BlackJack \n 3.Slot Machines");

            do
            {
                GameChosen = Convert.ToInt32(Console.ReadLine());
                switch (GameChosen)
                {
                    case 1:
                        Roulette(Customer);
                        break;
                    case 2:
                        BlackJack(Customer);
                        break;
                    case 3:
                        SlotMachines(Customer);
                        break;
                    default:
                        Console.Write("Mr./Ms. " + Customer + " please choose one of the games available: ");
                        break;
                }

            } while (GameChosen > 3);
        }





        static void Roulette(string? playerName)
        {
            int PlayAgain;
            Console.WriteLine("Dealer:Welcome to the Roulette game.");
            Console.WriteLine("Mr./Ms." + playerName + " these are the rules for this game: ");
            Console.WriteLine("Rules: ");
            Console.WriteLine("Your objective:Predict where the ball will land on the spinning wheel.");
            Console.WriteLine("1.the wheel has 38 slots.");
            Console.WriteLine("2.yourself will place a bet where the ball will land is it black(1) or red(2) and what number.");
            Console.WriteLine("3.if your bet was the ball's landing you win.");
            Console.WriteLine("Ps:if you would like to change the game you can after 5 rounds of playing.");
            int Credit = 1;
            do
            {
                Console.Write("Dealer:Please let us know how much money would you like to play with(max:10000): ");
                Credit = Convert.ToInt32(Console.ReadLine());
            } while (Credit > 10000);
            int Round = 1;
            do
            {
                Console.WriteLine("Your credit is:" + Credit + " $");
                Console.WriteLine("Dealer:sir/ma'am please choose where you think the ball will land at:");
                int[] bet = new int[2];
                int Accept = 1;
                do
                {
                    for (int i = 0; i < bet.Length; i++)
                    {
                        bet[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.Write("Dealer:is this your final choice(if yes press 1 and if no press 0): ");
                    Accept = Convert.ToInt32(Console.ReadLine());
                } while (Accept == 0);
                Console.WriteLine("Dealer:Goodluck");
                Random random = new Random();
                int[] ballLanding = new int[2];
                ballLanding[0] = random.Next(1, 3);
                ballLanding[1] = random.Next(1, 39);
                Console.WriteLine("\n \n");
                if (bet[0] == ballLanding[0] && bet[1] == ballLanding[1])
                {
                    Console.WriteLine("Dealer:Congratulations your guess was right.");
                    Credit += 35;
                }
                else
                {
                    Console.WriteLine("Dealer:Though luck lets try again:");
                    Credit -= 100;
                }

                Round++;
            } while (Round <= 5);
            Console.WriteLine("Would you like to play again if yes press 1 and if no press 0:");
            PlayAgain = Convert.ToInt32(Console.ReadLine());
            if (PlayAgain == 1)
            {
                Roulette(playerName);
            }
            else
            {
                otherGame(playerName);
            }
        }






        
        static void StartBlackJack(string? playerName, int numOfCredit)
        {
            int Round = 1;
            do
            {
                Console.WriteLine("\n \n");
                Console.WriteLine("this is round:" + Round);
                Console.WriteLine($"System: you have:{numOfCredit}$ Mr./Ms.{playerName}");
                Console.WriteLine("\n \n");
                Random random = new Random();
                int firstCard = random.Next(1, 13);
                int secondCard = random.Next(1, 13);
                int sum = firstCard + secondCard;
                int thirdCard=random.Next(1, 13);
                int accept;
                Console.Write("this your hand of cards: ");
                Console.WriteLine($"this your first card:{firstCard}, and this your second{secondCard}and this their sum: {sum}");
                Console.WriteLine("\n \n");
                if (sum < 21)
                {
                    Console.Write("would you like to render a new card?(yes=1 no=0):");
                    accept = Convert.ToInt32(Console.ReadLine());
                    if (accept == 1)
                    {
                        sum += thirdCard;
                        Console.WriteLine($"this your new set of card first card: {firstCard} this your second card: {secondCard} and this your last: {thirdCard} and finally this is the sum{sum}");
                        if (sum == 21)
                        {
                            Console.WriteLine("system:Congratulation you won");
                            numOfCredit += 35;
                            Round++;
                        }
                        else
                        {
                            Console.WriteLine("the last card didn't help though luck you wont lose anything");
                            Round++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("System:Bad decision Friend");
                        numOfCredit -= 200;
                        Round++;
                    }
                }
                else if (sum == 21)
                {
                    Console.WriteLine("congratulations you won");
                    Round++;
                    
                }
                else
                {
                    Console.WriteLine("TryAgain");
                    Round++;
                }
            } while (Round <= 5);
            int playAgain;
            Console.Write("Would you like to play another game yes(answer with 1) and no(answer with no): ");
            playAgain = Convert.ToInt32(Console.ReadLine());
            if(playAgain == 1)
            {
                otherGame(playerName);
            }
            else
            {
                BlackJack(playerName);
            }
        }
        static void BlackJack(string? playerName)
        {
            Console.WriteLine("Dealer:Welcome to the BlackJack game.");
            Console.WriteLine("Dealer:Mr./Ms. " + playerName + " let me read for you the rules of the game");
            Console.WriteLine("the number of cards are worth 2 - 10 the king the queen and the jack are woth 10 but the ace is worth 11");
            Console.WriteLine("you can choose another card or play your hand");
            Console.WriteLine("to win you need to have 21 sum of cards in your hands");
            Console.WriteLine("goodluck");
            Console.WriteLine("\n \n");
            Console.WriteLine("you can change the game after 5 rounds");
            int Credit;
            do
            {
                Console.Write("Dealer:Please let us know how much money would you like to play with(max:10000): ");
                Credit = Convert.ToInt32(Console.ReadLine());
            } while (Credit > 10000);
            StartBlackJack(playerName, Credit);
        }



        static void SlotMachines(string? PlayerName)
        {
            Console.WriteLine("\n \n");
            int SymbolTotal = 0;
            Console.WriteLine($"welcome Mr./Ms.{PlayerName} to the slot machine the rules are easy:");
            Console.WriteLine("this game is having 3 slots match to win a certain prize");
            Console.WriteLine("after 5 rounds you will be able to change games");
            int Credit;
            do
            {
                Console.Write($"Mr/Ms.{PlayerName} choose the amount of money you would like to play with (max:10000): ");
                Credit = Convert.ToInt32(Console.ReadLine());
            } while (Credit > 10000);
            int Round = 1;
            do
            {
                Random random = new Random();
                int[] symbols= {random.Next(1,4),random.Next(1,4),random.Next(1,4)};
                foreach (int symbol in symbols)
                {
                    Console.Write("\t" + symbol);
                    SymbolTotal += symbol;
                }
                Console.WriteLine("\n");
                if(SymbolTotal==3 || SymbolTotal==6 || SymbolTotal == 9)
                {
                    Console.WriteLine("System:Jackpot");
                    Credit += 35;
                    Round++;
                }
                else
                {
                    Console.WriteLine("System:Better luck next time");
                    Credit -= 100;
                    Round++;
                }
            } while (Round<=5);
            int playAgain;
            Console.Write($"Mr./Ms. {PlayerName}Would you like to play again yes(1)No(0)");
            playAgain = Convert.ToInt32(Console.ReadLine());
            if(playAgain==1)
            {
                SlotMachines(PlayerName);
            }
            else
            {
                otherGame(PlayerName);
            }
        }





        static void Main(string[] args)
        {
            Console.WriteLine("  *****      *    *****   ***     *   *   ***  ");
            Console.WriteLine(" *          * *   *        *      **  *  *   * ");
            Console.WriteLine("*          *****  *****    *      * * *  *   *");
            Console.WriteLine("*          *   *       *   *      *  **  *   * ");
            Console.WriteLine(" *         *   *  *****   ***     *   *   ***  ");
            Console.WriteLine("  *****                               ");
            Console.WriteLine();
            Console.WriteLine("Welcome to Casino of louize baabda");
            Console.WriteLine();
            Console.WriteLine("please insert your name and last name: ");
            string? Name = Console.ReadLine();
            string? lastName = Console.ReadLine();
            int GameChosen;
            Console.WriteLine(Name + " " + lastName + " " + "please choose what would you like to play (by pressing the number designated): ");
            Console.WriteLine(" 1.Roulette \n 2.BlackJack \n 3.Slot Machines");

            do
            {
                GameChosen = Convert.ToInt32(Console.ReadLine());
                switch (GameChosen)
                {
                    case 1:
                        Roulette(lastName);
                        break;
                    case 2:
                        BlackJack(lastName);
                        break;
                    
                    case 3:
                        SlotMachines(lastName);
                        break;
                    default:
                        Console.Write("Mr./Ms. " + lastName + " please choose one of the games available: ");
                        break;
                }

            } while (GameChosen > 3);
        }
    }
}