using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JanisMark4
{
    class QueAnalysis
    {
        #region Properties
        static Random rnd = new Random();
        public static string[] Questions = new string[5] { "Whats your name?", "how are you?", "How are you feeling?", "do you like talking to me?", "whats your favourite Food?"};
        static string[] strArrey;
        #endregion
        #region UserAnswer
        public QueAnalysis()
        {

        }
        
        public static string RandomQuestion()
        {
            return Questions[rnd.Next(0, 5)];
        }

        public static string AnswerAnalysis(string answer, string question)
        {
            switch (question)
            {
                case "Whats your name?":
                    return Name(answer);
                case "how are you?":
                case "How are you feeling?":
                    return Feel(answer);
                case "do you like talking to me?":
                    if (answer.ToUpper() == "YES")
                    {
                        return "Im glad you do. i like talking to you too";
                    }
                    return "Wow that is so rude. you are not nice";
                case "whats your favourite Food?":
                    return Food(answer);

            }
            return "";
        }
        
        public static string Food(string answer)
        {
            Janis.FavouriteFood = answer;
            return "Sounds delicious!";
        }
        
        public static string Feel(string answer)
        {
            answer = answer.ToUpper();
            strArrey = answer.Split(' ', ',', '.', '/', '!');

            for (int i = 0; i < strArrey.Length; i++)
            {
                switch (strArrey[i])
                {
                    case "OK":
                    case "FINE":
                    case "GREAT":
                    case "AWESOME":
                    case "FANTASTIC":
                    case "GOOD":
                    case "SUPER":
                        return "im glad you feel " + strArrey[i];
                    default:
                        return "I am sorry you feel that way..";
                }
            }
            return "";
        }

        public static string Name(string answer)
        {
            strArrey = answer.ToUpper().Split(' ', ',', '.', '/', '!');
            if (strArrey[0] == "MY")
            {
                for (int i = 3; i < strArrey.Length; i++)
                {
                    Janis.UserName += strArrey[i];
                }
            }
            return "Hello" + Janis.UserName + "I am Janis";
            
        }
        #endregion
    }
}
