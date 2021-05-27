using System;

namespace Quest
{

    public class Prize
    {
        private string _text;

        public Prize(string text)
        {
            _text = text;
        }

        public void ShowPrize(Adventurer Adventurer)
        {
            if (Adventurer.Awesomeness > 0)
            {
                for (int i = 0; i < Adventurer.Awesomeness; i++)
                    Console.WriteLine(_text);
            }
            else
            {
                Console.WriteLine("Nope. Better luck next time!");
            }


        }

    }
}