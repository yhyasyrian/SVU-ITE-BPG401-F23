using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ammar
{
    class Program
    {
        class HomeWork
        {
            const int MIN_NUMBER_ASCII = 48; // 0
            const int MAX_NUMBER_ASCII = 57; // 9
            const int MIN_CHAR_CAPITAL_ASCII = 65; // A
            const int MAX_CHAR_CAPITAL_ASCII = 90; // Z
            const int MIN_CHAR_SMALL_ASCII = 97; // a
            const int MAX_CHAR_SMALL_ASCII = 122; // z
            const int MAX_RANDOM_STRING = 2; // Min count radnom string 2
            const string SEPARATOR = "=============================";
            // Return string as lower case, can i use "String".ToLower() as function from c# but it didn't used in lessons
            // we use this way replace way if condition or switch all cases: Ignore - IGnore - IGNore - IgNore
            static string ToLower(string Command)
            {
                char CurrentChar;
                char[] result = new char[Command.Length];
                for (int IndexCharCommand = 0; IndexCharCommand < Command.Length; IndexCharCommand++)
                {
                    CurrentChar = Command[IndexCharCommand];
                    if (CurrentChar >= MIN_CHAR_CAPITAL_ASCII && CurrentChar <= MAX_CHAR_CAPITAL_ASCII)
                    {
                        result[IndexCharCommand] = (char)(CurrentChar + (MIN_CHAR_SMALL_ASCII - MIN_CHAR_CAPITAL_ASCII)); // convert char from capital to small with ASCII
                    }
                    else
                    {
                        result[IndexCharCommand] = CurrentChar;
                    }
                }
                return new string(result);
            }
            // Print random string, when user need that
            static void PrintRandomStrings(string[][] RandomStrings, int CountQuesation)
            {
                Console.WriteLine(SEPARATOR);
                for (int CurrentQuestion = 1; CurrentQuestion <= CountQuesation; CurrentQuestion++)
                {
                    Console.WriteLine("Question {0}:", CurrentQuestion);
                    for (int CurrentString = 1; CurrentString <= MAX_RANDOM_STRING; CurrentString++)
                        Console.WriteLine("{0}- {1}", CurrentString, RandomStrings[CurrentQuestion - 1][CurrentString - 1]);
                }
            }
            // Return count answers is true
            static int CountAnswersTrue(bool[] CurrentAnswers)
            {
                int CurrentResult = 0;
                for (int IndexAnswer = 0; IndexAnswer < MAX_RANDOM_STRING + 1; IndexAnswer++)
                {
                    if (CurrentAnswers[IndexAnswer]) CurrentResult++;
                }
                return CurrentResult;
            }
            // Return count answers but if true or false (by variable IfIncrement)
            static int CountAnswersIf(bool[][] Answers, bool IfIncrement, int CountQuestions)
            {
                int Count = 0;
                int Condition = IfIncrement ? MAX_RANDOM_STRING + 1 : 0;
                for (int IndexAnswer = 0; IndexAnswer < CountQuestions; IndexAnswer++)
                {
                    if (CountAnswersTrue(Answers[IndexAnswer]) == Condition) Count++;
                }
                return Count;
            }
            // Show answer count is false, when user need that
            static void PrintCountFalseAnswers(bool[][] Answers, int CountQuestions)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Count all false answers is: {0}/{1}", CountAnswersIf(Answers, false, CountQuestions), CountQuestions);
            }
            // Show answer count is true, when user need that
            static void PrintCountTrueAnswers(bool[][] Answers, int CountQuestions)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Count all true answers is: {0}/{1}", CountAnswersIf(Answers, true, CountQuestions), CountQuestions);
            }
            // Show answer count is relatively correct , when user need that
            static void PrintCountBetweenAnswers(bool[][] Answers, int CountQuestions)
            {
                Console.WriteLine(SEPARATOR);
                int Count = CountQuestions - CountAnswersIf(Answers, true, CountQuestions) - CountAnswersIf(Answers, false, CountQuestions);
                Console.WriteLine("Count all relatively correct answers is: {0}/{1}", Count, CountQuestions);
            }
            // Show random string with answer each all, when user need that
            static void PrintAnswersWithQuestions(string[][] RandomString, int[][] AnswersUser, bool[][] MarksUser, int[][] AnswersSystem, int CountQuestions)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("I will show number of questions then random string and users answer and the system answer and if it is true or false");
                for (int IndexQuestion = 0; IndexQuestion < CountQuestions; IndexQuestion++)
                {
                    Console.WriteLine("Question {0}: is true?: {1}", IndexQuestion + 1, (CountAnswersTrue(MarksUser[IndexQuestion]) == MAX_RANDOM_STRING + 1 ? "true" : "false"));
                    for (int CurrentNumberString = 1; CurrentNumberString <= MAX_RANDOM_STRING; CurrentNumberString++)
                    {
                        Console.Write("Random is: {0}\tyour answer: {1}\tsystem answer: {2}\tis true?: {3}\n",
                            RandomString[IndexQuestion][CurrentNumberString - 1], AnswersUser[IndexQuestion][CurrentNumberString - 1] == -1 ? "done ignore it" : AnswersUser[IndexQuestion][CurrentNumberString - 1].ToString(), AnswersSystem[IndexQuestion][CurrentNumberString - 1],
                            AnswersUser[IndexQuestion][CurrentNumberString - 1] == AnswersSystem[IndexQuestion][CurrentNumberString - 1] ? "true" : "false"
                            );
                    }
                    Console.Write("Answer like first and second, your answer: {0}\tsystem answer: {1}\tis true?: {2}\n", AnswersUser[IndexQuestion][MAX_RANDOM_STRING] == -1 ? "done ignore it" : AnswersUser[IndexQuestion][MAX_RANDOM_STRING].ToString(), AnswersSystem[IndexQuestion][MAX_RANDOM_STRING],
                        AnswersUser[IndexQuestion][MAX_RANDOM_STRING] == AnswersSystem[IndexQuestion][MAX_RANDOM_STRING] ? "true" : "false"
                    );
                    Console.WriteLine(SEPARATOR);
                }
            }
            static void Main(string[] args)
            {
                /**
                 The program works with these steps:
                * 1- When starting the program, It will show the information system.
                * 2- Get an input as an integer from the user, which is the number of questions
                * 3- Get inputs about the name, number (ID), and any other information. The accepted characters are ([A-Za-z]|[0-9]-(#|.|,|!|?)). This project works with these steps: create a random number, then convert it to a character.
                * *  The minimum length is 6 characters. Print it, then print it without spaces (as shown in the photo in the PDF homework) and without repetition, which means special characters.
                * 4- Print the questions:
                * 4.1 Get input from the users between 20 and 80 to create a random string. Only characters accepted are ([A-Za-z]|[0-9]-(#|.|,|!|?)).
                * 4.2 Get the input which is the count of special characters for two random strings.
                * 4.3 Get the input which is the count of similar characters from the first and second random strings.
                * 4.4 Store the results in four arrays: 
                *  - The first: similar characters between each string and the special characters.
                *  - The second: characters accepted in the current string.
                *  - The third: the answers.
                *  - The fourth: the marks [0-3].
                *  - The user can skip an answer by writing "ignore," and the mark will be 0.
                * 5- Show commands and execute them:
                * 5.1 Show random strings for all questions.
                * 5.2 Count all false answers.
                * 5.3 Count all true answers.
                * 5 .4 Count all relatively correct answers.
                * 5.5 Mix the last commands.
                * 5.6 Exit command.
                 */
                /**
                 * =======================
                 * Print information system (copt and paste from PDF)
                 * =======================
                 */
                Console.WriteLine("Windows version: {0}", Environment.OSVersion);
                Console.WriteLine("64 Bit operating system? : {0}", Environment.Is64BitOperatingSystem ? "Yes" : "No");
                Console.WriteLine("PC Name : {0}", Environment.MachineName);
                Console.WriteLine("Number of CPUS : {0}", Environment.ProcessorCount);
                Console.WriteLine("Windows folder : {0}", Environment.SystemDirectory);
                Console.WriteLine("Logical Drives Available : {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
                /**
                 * =======================
                 * When start program, it ask about questions count
                 * =======================
                 */
                int CountQuestions;
                do
                {
                    Console.Write("Pleas enter the maximum number of questions to start the game the number should be an integer > 0: ");
                    CountQuestions = Int16.Parse(Console.ReadLine());
                } while (CountQuestions <= 0);
                /**
                 * ======================
                 *  input the student is accept
                 *  =====================
                 */
                string Information;
                bool IsInformationAccept;
                do
                {
                    IsInformationAccept = true;
                    Console.Write("Please enter your full name and SVU id and other information, you can use these char [A-Za-z] and [1-9] and (# , . , ! ?):");
                    Information = Console.ReadLine();
                    if (Information.Length < 6)
                    {
                        IsInformationAccept = false;
                        continue;
                    };
                    for (int IndexChar = 0; IndexChar < Information.Length; IndexChar++)
                    {
                        // Is char accept? will be return true if char is: [A-Z] Or [a-z] Or [0-9] or (# , . , ! ?)   
                        if (
                                !(Information[IndexChar] >= MIN_NUMBER_ASCII && Information[IndexChar] <= MAX_NUMBER_ASCII) && // [0-9]
                                !(Information[IndexChar] >= MIN_CHAR_CAPITAL_ASCII && Information[IndexChar] <= MAX_CHAR_CAPITAL_ASCII) && // [A-Z]
                                !(Information[IndexChar] >= MIN_CHAR_SMALL_ASCII && Information[IndexChar] <= MAX_CHAR_SMALL_ASCII) && // [a-z]
                                !(Information[IndexChar] == '#' || Information[IndexChar] == '!' || Information[IndexChar] == ',' || Information[IndexChar] == '.' || Information[IndexChar] == '?' || Information[IndexChar] == ' ') // (! , . ? #)
                            )
                        {
                            IsInformationAccept = false;
                            break; // Because the user can not input one character isn't  be accepted
                        }
                    }
                } while (!IsInformationAccept);
                Console.WriteLine("Your full name and id and ...: {0}", Information);
                /**
                 * ==================
                 * storage in variable characters special those aren't have any repeat and any space
                 * ==================
                 */
                string SpecialCharacters = "";
                for (int IndexChar = 0; IndexChar < Information.Length; IndexChar++)
                {
                    if (SpecialCharacters.IndexOf(Information[IndexChar]) == -1 && Information[IndexChar] != ' ')
                        SpecialCharacters += Information[IndexChar];
                }
                Console.WriteLine("Special characters are: " + SpecialCharacters);
                /**
                 * ==================
                 * These arrays for storage quesation and marks and answers
                 * Arrays[CountQuestions][ResultForSubQuestions]
                 * ==================
                 */
                string[][] QuestionsRandomString = new string[CountQuestions][];
                bool[][] MarksQuestion = new bool[CountQuestions][];
                int[][] ResultsQuestion = new int[CountQuestions][];
                int[][] ResultsSystemQuestion = new int[CountQuestions][];
                for (int i = 0; i < CountQuestions; i++)
                {
                    QuestionsRandomString[i] = new string[MAX_RANDOM_STRING]; // Tow random string
                    MarksQuestion[i] = new bool[MAX_RANDOM_STRING + 1]; // Tow random string + count of similar characters from the first and second random strings
                    ResultsQuestion[i] = new int[MAX_RANDOM_STRING + 1]; // Tow random string + count of similar characters from the first and second random strings
                    ResultsSystemQuestion[i] = new int[MAX_RANDOM_STRING + 1]; // Tow random string + count of similar characters from the first and second random strings
                }
                /**
                 * ======================
                 * Start ask user about question
                 * ======================
                 */
                int CountCharactersCreate, ResultUser;
                string ResultTmpAfterFilter /* filter random string for remoave any repeat */, ResultTmp; // I use this variable in input user when user anwser any ask
                for (int currentQuestion = 1; currentQuestion <= CountQuestions; currentQuestion++)
                {
                    CountCharactersCreate = 0;
                    Console.WriteLine("Start questions {0}\n{1}", currentQuestion, SEPARATOR);
                    /*
                     * ====================
                     * Ask user about count characters for each string
                     * ====================
                     */
                    do
                    {
                        Console.Write("Pleas enter an integer value between (20-80), the number of characters in each random string:");
                        CountCharactersCreate = Int16.Parse(Console.ReadLine());
                    } while (CountCharactersCreate < 20 || CountCharactersCreate > 80);
                    /**
                     * ==============
                     * start show randomg string and ask count similar characters between these strings and special characters
                     * ==============
                     */
                    for (int currentStringRandom = 1; currentStringRandom <= MAX_RANDOM_STRING; currentStringRandom++)
                    {
                        string CurrentRandonString = "";
                        /**
                         * =====================
                         * Create random string
                         * =====================
                         */
                        for (int i = 1; i <= CountCharactersCreate; i++)
                        {
                            char[] Chars = { '#', '!', '.', ',', '?' };
                            Random RandomObject = new Random();
                            switch (RandomObject.Next(1, 5))
                            {
                                case 1:
                                    CurrentRandonString += (char)RandomObject.Next(MIN_NUMBER_ASCII, MAX_NUMBER_ASCII + 1); // Create character [0-9], increment one for function Next in object Random
                                    break;
                                case 2:
                                    CurrentRandonString += (char)RandomObject.Next(MIN_CHAR_CAPITAL_ASCII, MAX_CHAR_CAPITAL_ASCII + 1); // Create character [A-Z], increment one for function Next in object Random
                                    break;
                                case 3:
                                    CurrentRandonString += (char)RandomObject.Next(MIN_CHAR_SMALL_ASCII, MAX_CHAR_SMALL_ASCII + 1); // Create character [a-z], increment one for function Next in object Random
                                    break;
                                case 4:
                                    CurrentRandonString += Chars[RandomObject.Next(0, 5)]; // Create character (# ! . , ?), index array start from 0
                                    break;
                            }
                        }
                        Console.WriteLine("Random string {0}: {1}", currentStringRandom, CurrentRandonString);
                        /**
                         * =============
                         * Answer user
                         * =============
                         */
                        do
                        {
                            Console.Write("Enter the number of similar special characters, Enter ignore to skip, or number to answer (between 0-{0}):", CountCharactersCreate);
                            ResultTmp = Console.ReadLine();
                            ResultUser = ToLower(ResultTmp) == "ignore" ? -1 : Int16.Parse(ResultTmp);
                        } while (ToLower(ResultTmp) != "ignore" && (ResultUser < 0 || ResultUser > CountCharactersCreate));
                        /**
                         * ===================
                         * Storage results in arrays
                         * ===================
                         */
                        QuestionsRandomString[currentQuestion - 1][currentStringRandom - 1] = CurrentRandonString;
                        ResultsQuestion[currentQuestion - 1][currentStringRandom - 1] = ResultUser;
                        /**
                         * =====================
                         * Returns the number of similar characters
                         * =====================
                         */
                        int CurrentResultSystemQuestion = 0;
                        for (int IndexCharPrimaryString = 0; IndexCharPrimaryString < SpecialCharacters.Length; IndexCharPrimaryString++)
                        {
                            for (int IndexCharSecondaryString = 0; IndexCharSecondaryString < CurrentRandonString.Length; IndexCharSecondaryString++)
                            {
                                if (CurrentRandonString[IndexCharSecondaryString] == SpecialCharacters[IndexCharPrimaryString])
                                {
                                    CurrentResultSystemQuestion++;
                                    break;
                                };
                            }
                        }
                        ResultsSystemQuestion[currentQuestion - 1][currentStringRandom - 1] = CurrentResultSystemQuestion;
                        MarksQuestion[currentQuestion - 1][currentStringRandom - 1] = (ResultUser == ResultsSystemQuestion[currentQuestion - 1][currentStringRandom - 1]);
                    } // end child for
                    /**
                     * ==============
                     * ask user about count similar characters between first and secondary random string
                     * ==============
                     */
                    do
                    {
                        Console.Write("Enter the number of similar random strings (first and second), Enter ignore to skip, or number to answer (between 0-{0}):", CountCharactersCreate);
                        ResultTmp = Console.ReadLine();
                        ResultUser = ToLower(ResultTmp) == "ignore" ? -1 : Int16.Parse(ResultTmp);
                    } while (ToLower(ResultTmp) != "ignore" && (ResultUser < 0 || ResultUser > CountCharactersCreate));
                    /**
                    * ===================
                    * Storage results in arrays
                    * ===================
                    */
                    /**
                     * =====================
                     * Returns the number of similar primary and second random string
                     * =====================
                     */
                    int CurrentResultSystemQuestionSimilar = 0;
                    string PrimaryRandomString = QuestionsRandomString[currentQuestion - 1][0];
                    /**
                     * =============
                     * Start remove any repeat
                     * =============
                     */
                    ResultTmpAfterFilter = "";
                    for (int IndexChar = 0; IndexChar < PrimaryRandomString.Length; IndexChar++)
                    {
                        if (ResultTmpAfterFilter.IndexOf(PrimaryRandomString[IndexChar]) == -1)
                            ResultTmpAfterFilter += PrimaryRandomString[IndexChar];
                    }
                    /**
                     * =============
                     * End remove any repeat
                     * =============
                     */
                    string SecondaryRandomString = QuestionsRandomString[currentQuestion - 1][1];
                    for (int IndexCharPrimaryString = 0; IndexCharPrimaryString < ResultTmpAfterFilter.Length; IndexCharPrimaryString++)
                    {
                        for (int IndexCharSecondaryString = 0; IndexCharSecondaryString < SecondaryRandomString.Length; IndexCharSecondaryString++)
                        {
                            if (SecondaryRandomString[IndexCharSecondaryString] == ResultTmpAfterFilter[IndexCharPrimaryString])
                            {
                                CurrentResultSystemQuestionSimilar++;
                                break;
                            }
                        }
                    }
                    ResultsSystemQuestion[currentQuestion - 1][MAX_RANDOM_STRING] = CurrentResultSystemQuestionSimilar;
                    ResultsQuestion[currentQuestion - 1][MAX_RANDOM_STRING] = ResultUser;
                    MarksQuestion[currentQuestion - 1][MAX_RANDOM_STRING] = (ResultUser == ResultsSystemQuestion[currentQuestion - 1][MAX_RANDOM_STRING]);
                } // end parent for

                /**
                 * ==============
                 * Start part tow, and working with functions ;)
                 * ==============
                 */

                string commandUser = "";
                while (true) // To ask the user about the command to be executed and not to stop the program from working
                {
                    Console.WriteLine(SEPARATOR);
                    Console.WriteLine(">> Commands are:");
                    Console.WriteLine(">>>\t1- Show random strings for all questions");
                    Console.WriteLine(">>>\t2- Show all answers false");
                    Console.WriteLine(">>>\t3- Show all answers true");
                    Console.WriteLine(">>>\t4- Show all answers between true and false");
                    Console.WriteLine(">>>\t5- Show all answers with string (mixed last commands)");
                    Console.WriteLine(">>>\tFor exit programming enter: Exit");
                    Console.Write("Enter Command: ");
                    commandUser = Console.ReadLine();
                    if (ToLower(commandUser) == "exit")
                        break;
                    switch (Int16.Parse(commandUser))
                    {
                        case 1:
                            PrintRandomStrings(QuestionsRandomString, CountQuestions);
                            break;
                        case 2:
                            PrintCountFalseAnswers(MarksQuestion, CountQuestions);
                            break;
                        case 3:
                            PrintCountTrueAnswers(MarksQuestion, CountQuestions);
                            break;
                        case 4:
                            PrintCountBetweenAnswers(MarksQuestion, CountQuestions);
                            break;
                        case 5:
                            PrintAnswersWithQuestions(QuestionsRandomString, ResultsQuestion, MarksQuestion, ResultsSystemQuestion, CountQuestions);
                            break;
                        default:
                            Console.WriteLine("Command isn't difne");
                            break;
                    }
                }
                /**
                 * =================
                 * End programming :)
                 * =================
                 */
            } // end function Main
        }
    }
}
