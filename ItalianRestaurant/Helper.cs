using System.Security.AccessControl;
using System.Text;

namespace ItalianRestaurant
{
    public class Helper
    {
        /// <summary>
        /// collects user input and verifies it is valid and within the provided range
        /// </summary>
        /// <param name="message">message to show user what they are selecting</param>
        /// <param name="maxValue">max total choices available</param>
        /// <returns></returns>
        public int GetIntegerInput(string message, int maxValue)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > maxValue)
            {
                Console.WriteLine($"Please enter a valid number between {1} and {maxValue}.");
            }
            return input;
        }

        /// <summary>
        /// asks a yes/no question and returns the user's response as a boolean
        /// </summary>
        /// <param name="question">question to prompt user</param>
        /// <returns></returns>
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

        /// <summary>
        /// gets menu options and displays them to use for selection
        /// </summary>
        /// <param name="orderType">menu choice user is selecting</param>
        /// <param name="options">menu options available to select</param>
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

        /// <summary>
        /// gets selected menu options and displays in shopping cart
        /// </summary>
        /// <param name="options">selected items in cart</param>
        public void DisplayOptions(List<MenuOptions> options)
        {
            for (int i = 0; i < options.Count; i++)
            {
                var item = options[i];
                string description = item.Price == 0.00m ? "" : $"....{item.Price:c}";
                Console.WriteLine($"{item.ItemName.ToUpper()}{description}");
            }
        }

        /// <summary>
        /// gets selected menu options and displays with numbers for selecting to edit
        /// </summary>
        /// <param name="options">selected items in cart</param>
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