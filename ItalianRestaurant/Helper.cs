using System.Security.AccessControl;
using System.Text;

namespace ItalianRestaurant
{
    public class Helper
    {
        // collects user input and verifies it is valid and within the provided range
        public int GetIntegerInput(string message, int minValue, int maxValue)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < minValue || input > maxValue)
            {
                Console.WriteLine($"Please enter a valid number between {minValue} and {maxValue}.");
            }
            return input;
        }

        // asks a yes/no question and returns the user's response as a boolean
        public bool GetYetNoResponce(string question)
        {
            string userResponse = " ";
            while (userResponse != "Y" && userResponse != "N")
            {
                Console.WriteLine($"{question}(Y/N)");
                userResponse = Console.ReadLine().Trim().ToUpper();
            }
            return userResponse == "Y";
        }

        // gets menu options and displays them to use for selection
        public void DisplayOptions(string orderType, MenuOptions[] options)
        {
            Console.WriteLine($"\n{orderType}");
            for (int i = 0; i < options.Length; i++)
            {
                var item = options[i];
                string description = item.Price == 0.00m ? "" : $"....{item.Price:c}";
                Console.WriteLine($"{i + 1}. {item.ItemName.ToUpper()}{description}");
            }
        }

        // gets selected menu options and displays in shopping cart
        public void DisplayOptions(List<MenuOptions> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                var item = options[i];
                string description = item.Price == 0.00m ? "" : $"....{item.Price:c}";
                Console.WriteLine($"{item.ItemName.ToUpper()}{description}");
            }
        }

        // gets selected menu options and displays with numbers for selecting to edit
        public void DisplayOptionsWithNumbers(List<MenuOptions> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                var item = options[i];
                string description = item.Price == 0.00m ? "" : $"....{item.Price:c}";
                Console.WriteLine($"{i + 1}. {item.ItemName.ToUpper()}{description}");
            }
        }
    }
}