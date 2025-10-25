using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace day2
{
    public class Q10
    {
        /// <summary>
        /// Input a character from console and display the sports name corresponding to it
        /// <code>
        ///     +-----------+-----------+
        ///     | character |  Sports   |
        ///     +-----------+-----------+
        ///     | c         | Cricket   |
        ///     | f         | Football  |
        ///     | h         | Hockey    |
        ///     | t         | Tennis    |
        ///     | b         | Badminton |
        ///     +-----------+-----------+
        ///   </code>
        /// </summary>
        public void Answer()
        {
            char character;
            Console.Write("Enter the Character ");
            char.TryParse(Console.ReadLine(), out character);
            FindSports(character);
        }

        public void FindSports(char character)
        {
            string sport;
            switch (character)
            {
                case 'c':
                    sport = "Cricket";
                    break;
                case 'f':
                    sport = "Football";
                    break;
                case 'h':
                    sport = "Hockey";
                    break;
                case 't':
                    sport = "Tennis";
                    break;
                case 'b':
                    sport = "Badminton";
                    break;
                default:
                    sport = "invalid character";
                    break ;
            }
            Console.WriteLine(sport);
        }

    }
    
}
