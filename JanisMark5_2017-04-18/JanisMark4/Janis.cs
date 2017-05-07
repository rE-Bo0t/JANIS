using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.Xml;
using System.Net;

namespace JanisMark4
{
    public class Janis
    {
        public Janis()
        {

        }

        #region Properties
        static SpeechSynthesizer sSynth = new SpeechSynthesizer();
        static PromptBuilder pBuilder = new PromptBuilder();
        static SpeechRecognitionEngine sRecog = new SpeechRecognitionEngine();
        static Choices sList = new Choices();
        static string[] strArrey;
        public static string UserName="";
        public static string FavouriteFood="";
        public static string[] Questions = new string[6] { "Whats your name?", "how are you?", "How are you feeling?", "do you like talking to me?", "whats your favourite Food?", "what do you like to do on your free time?" };
        static string intro = "hi, im janis, your personal assistant. you can ask me what ever you want, just not too weird stuff";
        static Random rnd = new Random();
        #endregion

        #region MyFuncs
        public static void Intro()
        {
            Talk(intro);
        }
        public static void Talk(string str)
        {
            str = CheckDot(str);
            pBuilder.ClearContent();
            pBuilder.AppendText(str);
            sSynth.Speak(pBuilder);
        }
        public static string InputAnalysis(string str)
        {
            if (str[str.Length - 1] == '?')
            {
                str = str.Remove(str.Length - 1);
            }
            str = str.ToUpper();
            strArrey = str.Split(' ', ',', '.', '/', '!');
            switch (str)
            {
                case "EXIT":
                case "QUIT":
                case "BYE":
                case "GOODBYE":
                    Application.Exit();
                    while (true)
                    {

                    }
                case "HOW ARE YOU":
                case "WHATS UP":
                case "HOW ARE YOU DOING":
                    switch (rnd.Next(0, 4))
                    {
                        case 1:
                            return "im fine, thank you";
                        case 2:
                            return "I am OK, could be better";
                        case 3:
                            if (strArrey[0] == "WHATS")
                            {
                                return "Gas Prices";
                            }
                            else
                            {
                                goto case 2;
                            }
                        case 4:
                            return "great";
                    }
                    break;
            }
            switch (strArrey[0])
            {
                case "HEY":
                case "HELLO":
                case "HI":
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            return "hi sir";
                        case 2:
                            return "hello sir";
                        case 3:
                            return "oh hi.. i didn't see you there";
                    }
                    break;
                case "JANIS":
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            return "yes sir?";
                        case 2:
                            return "At your service";
                        case 3:
                            return "Im here";
                        case 4:
                            if (UserName != null)
                            {
                                return UserName;
                            }
                            break;
                    }
                    break;
                case "WHATS":
                    if (strArrey[1] == "YOUR" && strArrey[2] == "NAME")
                    {
                        return "Im janis. that stands for Just Another Non-human intelligent software";
                    }
                    else if (strArrey[1] == "MY" && strArrey[2] == "NAME")
                    {
                        if (UserName != null)
                        {
                            return UserName;
                        }
                        else
                        {
                            JanisQuestion j = new JanisQuestion("Whats your name?");
                            j.Activate();
                            j.ShowDialog();
                            return UserName;
                        }
                    }
                    else
                    {
                        return CheckDTD(strArrey);
                    }
                case "WHAT":
                    if (strArrey[1] == "IS")
                    {
                        goto case "WHATS";
                    }
                    else if (strArrey[1] == "ARE" && strArrey[2] == "YOU")
                    {
                        return "I am an a i software";
                    }
                    else
                    {
                        return CheckDTD(strArrey);
                    }
                case "MY":
                    if (strArrey[1] == "NAME")
                    {
                        for (int i = 3; i < strArrey.Length; i++)
                        {
                            UserName = strArrey[i] + " ";
                        }
                    }
                    return "hey   " + UserName + ".  Im janis.";
                case "IM":
                    for (int i = 1; i < strArrey.Length; i++)
                    {
                        UserName = strArrey[i] + " ";
                    }
                    if (MessageBox.Show("Is " + UserName + " your name?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        return "hey" + UserName;
                    }
                    else
                    {
                        return "OK so good for you.. i think";
                    }
                case "I":
                    if (strArrey[1] == "AM")
                    {
                        for (int i = 2; i < strArrey.Length; i++)
                        {
                            UserName = strArrey[i] + " ";
                        }
                        if (MessageBox.Show("Is " + UserName + " your name?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            return "hey" + UserName;
                        }
                        else
                        {
                            return "OK so good for you.. i think";
                        }
                    }
                    else if (strArrey[1] == "LOVE")
                    {
                        if (strArrey[2] == "YOU")
                        {
                            switch (rnd.Next(0,2))
                            {
                                case 0:
                                    return "Awww, you're so sweet";
                                case 1:
                                    return "i wish i could feel that too. but i am just a machine";
                            }
                        }
                        else
                        {
                            return "i wish i could feel that too. but i am just a machine";
                        }
                    }
                    break;

                case "CALL":
                    if (strArrey[1] == "ME")
                    {
                        for (int i = 2; i < strArrey.Length; i++)
                        {
                            UserName = strArrey[i] + " ";
                        }
                    }
                    return "Okay.  " + UserName;
                case "WHO":
                    strArrey = str.Split('"');
                    XmlDocument myxml = new XmlDocument();
                    myxml.Load("http://api.wolframalpha.com/v2/query?appid=8XGGW7-4JW48W5H3Y&input=" + StringE(strArrey, "%20") + "&format=plaintext&podtitle=Description&podtitle=Result&podtitle=WikipediaSummary");
                    System.Diagnostics.Process.Start("https://www.wolframalpha.com/input/?i=" + StringE(strArrey, "+"));
                    return xmlStringFinder(myxml, str) + "here is some more information about" + StringE(strArrey, " ");
            }
            string stt = "";
            for (int i = 0; i < strArrey.Length; i++)
            {
                stt = stt + strArrey[i] + "%20";
            }
            XmlDocument xml = new XmlDocument();
            xml.Load("http://api.wolframalpha.com/v2/query?appid=8XGGW7-4JW48W5H3Y&input=" + stt + "&format=plaintext&podtitle=Description&podtitle=Result");
            return xmlStringFinder(xml, str);
        }

        public static string CheckDTD(string[] strArrey)
        {
            if (strArrey.Contains<string>("DAY"))
            {
                return DateTime.Today.DayOfWeek.ToString();
            }
            else if (strArrey.Contains<string>("TIME"))
            {
                return DateTime.Today.ToShortTimeString();
            }
            else if (strArrey.Contains<string>("DATE"))
            {
                return DateTime.Today.ToShortDateString();
            }
            return "";
        }
        public static string StringE(string[] strArrey, string Char)
        {
            string s = "";
            for (int i = 0; i < strArrey.Length; i++)
            {
                s = s + strArrey[i] + Char;
            }
            return s;

        }
        public static string Edit(string FullStr)
        {
            string NewString = FullStr.Split(new string[] { "],[" }, StringSplitOptions.None)[1];
            NewString = NewString.Replace(')', '(');
            string[] t = NewString.Split('(');
            try
            {
                NewString = t[0] + "" + t[2];
                NewString = NewString.Remove(0, 1);
                NewString = NewString.Remove(NewString.Length - 1);
            }
            catch
            {

            }
            
            return NewString;

        }
        public static string xmlStringFinder(XmlDocument myxml, string str)
        {
            return TryWiki(str);
            string[] arr = myxml.OuterXml.Split('<', '>');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == "plaintext")
                {
                    return arr[i + 1];
                }
            }
            
            
        }
        public static string TryWiki(string str)
        {
            WebClient client = new WebClient();
            string FullString = client.DownloadString("https://en.wikipedia.org/w/api.php?action=opensearch&search=" + StringE(str.Split(' '), "%20") + "&limit=1&format=json");
            string s = Edit(FullString);
            if (s == "" || s == " ")
            {
                return IDUS(str);
            }
            return s;
            
        }

        public static string CheckDot(string str)
        {
            foreach (char item in str)
            {
                if (item == '.')
                {
                    str = str.Replace(item, ' ');
                }
             
            }
            return str;
        }

        public static string IDUS(string sttr)
        {
            Talk("i dont understand.. Would you like me to search that in google?");
            if (MessageBox.Show("Search in google?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string link = "https://www.google.co.il/?gfe_rd=cr&ei=F0_xVuv5AcOg8weat7LgCA#q=";
                strArrey = sttr.Split(' ', ',', '/', '!');
                for (int i = 0; i < strArrey.Length; i++)
                {
                    link = link + strArrey[i] + "+";
                }
                System.Diagnostics.Process.Start(link);
                return "this is what my friend google found about" + sttr;
            }
            else
            {
                return "OK then";
            }
        }
        #endregion
    }
}
