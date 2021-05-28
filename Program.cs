using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            playGame();
            void playGame()
            {
                Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
                Challenge theAnswer = new Challenge(
                    "What's the answer to life, the universe and everything?", 42, 25);
                Challenge whatSecond = new Challenge(
                    "What is the current second?", DateTime.Now.Second, 50);

                int randomNumber = new Random().Next() % 10;
                Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

                Challenge favoriteBeatle = new Challenge(
                    @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                    4, 20
                );

                Challenge theDog = new Challenge(@"Who is the cutest dog in the world?
                1) Clifford
                2) Gus
                3) Beethtoven", 2, 75);

                Challenge theBank = new Challenge("How many dollars are in your bank account?", 2, 10);

                Challenge iceCream = new Challenge(@"What is better ice cream?
                1) Mint Chocolate Chip
                2) Cookie Dough
                3) Pistachio
                4) Strawberry", 3, 25);


                // "Awesomeness" is like our Adventurer's current "score"
                // A higher Awesomeness is better

                // Here we set some reasonable min and max values.
                //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
                //  If an Adventurer has an Awesomeness less than the min, they are terrible
                int minAwesomeness = 0;
                int maxAwesomeness = 100;

                Robe AdventurerRobe = new Robe();
                {
                    AdventurerRobe.Length = 45;
                    AdventurerRobe.Colors = new List<string> { "red", "black", "gold" };

                }
                Hat AdventurerHat = new Hat();
                {
                    AdventurerHat.ShininessLevel = 4;
                }
                // Make a new "Adventurer" object using the "Adventurer" class
                Console.Write($"Welcome. What is the adventurers name?");
                string adventurerName = Console.ReadLine();
                Prize winnerPrize = new Prize("75 Million Dollars");
                Adventurer theAdventurer = new Adventurer(adventurerName, AdventurerRobe, AdventurerHat);
                Console.WriteLine(theAdventurer.GetDescription());


                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                theDog,
                theBank,
                iceCream

            };
                Random r = new Random();
                List<int> indexes = new List<int>();


                while (indexes.Count < 5)
                {
                    int question = r.Next(challenges.Count - 1);
                    if (!indexes.Contains(question))
                    {
                        indexes.Add(question);
                    }
                }
                for (int i = 0; i < indexes.Count; i++)
                {
                    int index = indexes[i];
                    challenges[index].RunChallenge(theAdventurer);
                    // Console.WriteLine(challenges[index]);
                }



                // Loop through all the challenges and subject the Adventurer to them
                // foreach (Challenge challenge in challenges)
                // {

                //     challenge.RunChallenge(theAdventurer);
                // }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");

                }
                winnerPrize.ShowPrize(theAdventurer);

                Console.WriteLine("Would you like to play again?");
                Console.WriteLine("Y or N");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    playGame();
                }
                else if (answer != "y")
                {
                    return;
                }
            }
        }



    }
}

