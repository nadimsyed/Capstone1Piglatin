using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CapstoneProject1
{
    class Program
    {
        static void Main(string[] args)
        {


            string numberPatternDigit = @"\d+";
            string numberPatternDigitLetter = @"(\d+)([a-zA-z]+)";
            string numberPatternLetterDigit = @"([a - zA - z] +)(\d+)";
            string numberPatternLetterDigitLetter = @"([a - zA - z] +)(\d+)([a - zA - z] +)";
            string numberPatternDigitLetterDigit = @"(\d+)([a-zA-z]+)(\d+)";

            string symbolPatternSymbol = @"\W+";
            string symbolPatternSymbolLetter = @"(\W+)([a-zA-z]+)";
            string symbolPatternLetterSymbol = @"([a - zA - z] +)(\W+)";
            string symbolPatternLetterSymbolLetter = @"([a - zA - z] +)(\W+)([a - zA - z] +)";
            string symbolPatternSymbolLetterSymbol = @"(\W+)([a-zA-z]+)(\W+)";

            string emailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            //see if the punctuation mark regex works. so if period, do the work and then add period to end, if not the apostraphe do the match.success line of code
            // see if apostraphe, that it still lets contractions work like i had it working before, if not. decide what's more important to have or try to solve for both
            // if enough time
            string period = @"^[a-zA-Z]+\.?$";
            string contract = @"([\w]+['][\w]+)";

            Console.WriteLine("\t\t\t\t\tWelcome to the Pig Latin converter!");
            bool truth = true;
            while (truth)
            {
                Console.Write("Please insert what you want to be translated to Pig Latin! ");

                string data = Console.ReadLine();

                //Console.Write("\t\t\t\t\t");
                string[] stringArray = data.Split(' ');

                bool numInput = int.TryParse(data, out int numInputCheck);
                if (numInput)
                {
                    Console.WriteLine($"\n{numInputCheck} is not word(s). Please enter a word or words, not only number(s)!! We'll give you another shot.\n");
                    continue;
                }
                else
                {
                    for (int i = 0; i < stringArray.Length; i++)
                    {

                        bool revert = FullCaseTester(stringArray[i]);
                        bool revertTestCase = FirstSlotCaseTester(stringArray[i]);

                        string temp = stringArray[i].ToLower();
                        if (revert)
                        {
                            if (VowelChecker(temp, 0))
                            {
                                Match match = Regex.Match(temp, numberPatternDigit);
                                Match matchTwo = Regex.Match(temp, numberPatternDigitLetter);
                                Match matchThree = Regex.Match(temp, numberPatternLetterDigit);
                                Match matchFour = Regex.Match(temp, numberPatternLetterDigitLetter);
                                Match matchFive = Regex.Match(temp, numberPatternDigitLetterDigit);
                                Match matchSix = Regex.Match(temp, emailPattern);
                                Match matchSeven = Regex.Match(temp, symbolPatternSymbol);
                                Match matchEight = Regex.Match(temp, symbolPatternSymbolLetter);
                                Match matchNine = Regex.Match(temp, symbolPatternLetterSymbol);
                                Match matchTen = Regex.Match(temp, symbolPatternLetterSymbolLetter);
                                Match matchEleven = Regex.Match(temp, symbolPatternSymbolLetterSymbol);
                                Match matchTwelve = Regex.Match(temp, period);
                                Match matchThirteen = Regex.Match(temp, contract);


                                if (matchSix.Success)
                                {
                                    Console.Write(temp.ToLower() + " ");

                                }
                                //else if (matchTwelve.Success)
                                //{
                                //    string prePunctuation = temp.Substring(0, temp.Length - 1);
                                //    Console.Write((prePunctuation += "way").ToUpper() + temp[temp.Length - 1] + " ");
                                //}
                                else if (matchThirteen.Success)
                                {
                                    temp += "way";
                                    Console.Write(temp.ToUpper() + " ");
                                }
                                else if (/*!matchThirteen.Success && */match.Success || matchTwo.Success || matchThree.Success || matchFour.Success || matchFive.Success || matchSeven.Success || matchEight.Success || matchNine.Success || matchTen.Success || matchEleven.Success)
                                {
                                    Console.Write(temp.ToUpper() + " ");
                                }
                                else
                                {
                                    temp += "way";
                                    Console.Write(temp.ToUpper() + " ");
                                }


                            }
                            else
                            {
                                Match match = Regex.Match(temp, numberPatternDigit);
                                Match matchTwo = Regex.Match(temp, numberPatternDigitLetter);
                                Match matchThree = Regex.Match(temp, numberPatternLetterDigit);
                                Match matchFour = Regex.Match(temp, numberPatternLetterDigitLetter);
                                Match matchFive = Regex.Match(temp, numberPatternDigitLetterDigit);
                                Match matchSix = Regex.Match(temp, emailPattern);
                                Match matchSeven = Regex.Match(temp, symbolPatternSymbol);
                                Match matchEight = Regex.Match(temp, symbolPatternSymbolLetter);
                                Match matchNine = Regex.Match(temp, symbolPatternLetterSymbol);
                                Match matchTen = Regex.Match(temp, symbolPatternLetterSymbolLetter);
                                Match matchEleven = Regex.Match(temp, symbolPatternSymbolLetterSymbol);
                                Match matchTwelve = Regex.Match(temp, period);
                                Match matchThirteen = Regex.Match(temp, contract);

                                if (matchSix.Success)
                                {
                                    Console.Write(temp.ToLower() + " ");

                                }
                                //else if (matchTwelve.Success)
                                //{
                                //    string slot = stringArray[i];
                                //    int h = ConsonantChecker(slot);
                                //    int move;
                                //    if (h == 0)
                                //    {
                                //        move = h + 1;
                                //    }
                                //    else
                                //    {
                                //        move = h;
                                //    }
                                //    temp = slot.Substring(h, (slot.Length - move));
                                //    string pigLatin;
                                //    if (temp.Length == 1)
                                //    {
                                //        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                //    }
                                //    else
                                //    {
                                //        pigLatin = temp + slot.Substring(0, h) + "ay";

                                //    }
                                //    Console.Write(pigLatin.ToUpper() + " ");

                                //    //Trying to do period for consonant, prob will have to insert in the if else statement right above
                                //    //string prePunctuation = pigLatin.Substring(0, pigLatin.Length - 1);
                                //    //Console.Write((prePunctuation += "way").ToUpper() + pigLatin[pigLatin.Length - 1] + " ");
                                //}
                                else if (matchThirteen.Success)
                                {
                                    string slot = stringArray[i];
                                    int h = ConsonantChecker(slot);
                                    int move;
                                    if (h == 0)
                                    {
                                        move = h + 1;
                                    }
                                    else
                                    {
                                        move = h;
                                    }
                                    temp = slot.Substring(h, (slot.Length - move));
                                    string pigLatin;
                                    if (temp.Length == 1)
                                    {
                                        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                    }
                                    else
                                    {
                                        pigLatin = temp + slot.Substring(0, h) + "ay";

                                    }
                                    Console.Write(pigLatin.ToUpper() + " ");
                                }
                                else if (match.Success || matchTwo.Success || matchThree.Success || matchFour.Success || matchFive.Success || matchSeven.Success || matchEight.Success || matchNine.Success || matchTen.Success || matchEleven.Success)
                                {
                                    Console.Write(temp.ToUpper() + " ");
                                }
                                else
                                {
                                    string slot = stringArray[i];
                                    int h = ConsonantChecker(slot);
                                    int move;
                                    if (h == 0)
                                    {
                                        move = h + 1;
                                    }
                                    else
                                    {
                                        move = h;
                                    }
                                    temp = slot.Substring(h, (slot.Length - move));
                                    string pigLatin;
                                    if (temp.Length == 1)
                                    {
                                        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                    }
                                    else
                                    {
                                        pigLatin = temp + slot.Substring(0, h) + "ay";

                                    }
                                    Console.Write(pigLatin.ToUpper() + " ");
                                }
                            }
                        }
                        else if (revertTestCase)
                        {
                            if (VowelChecker(temp, 0))
                            {
                                Match match = Regex.Match(temp, numberPatternDigit);
                                Match matchTwo = Regex.Match(temp, numberPatternDigitLetter);
                                Match matchThree = Regex.Match(temp, numberPatternLetterDigit);
                                Match matchFour = Regex.Match(temp, numberPatternLetterDigitLetter);
                                Match matchFive = Regex.Match(temp, numberPatternDigitLetterDigit);
                                Match matchSix = Regex.Match(temp, emailPattern);
                                Match matchSeven = Regex.Match(temp, symbolPatternSymbol);
                                Match matchEight = Regex.Match(temp, symbolPatternSymbolLetter);
                                Match matchNine = Regex.Match(temp, symbolPatternLetterSymbol);
                                Match matchTen = Regex.Match(temp, symbolPatternLetterSymbolLetter);
                                Match matchEleven = Regex.Match(temp, symbolPatternSymbolLetterSymbol);
                                Match matchTwelve = Regex.Match(temp, period);
                                Match matchThirteen = Regex.Match(temp, contract);

                                if (matchSix.Success)
                                {
                                    Console.Write(temp.ToLower() + " ");

                                }
                                //else if (matchTwelve.Success)
                                //{
                                //    string prePunctuation = temp.Substring(0, temp.Length - 1);
                                //    Console.Write(UpperCaseFirstLetter((prePunctuation += "way")) + temp[temp.Length - 1] + " ");
                                //}
                                else if (matchThirteen.Success)
                                {
                                    temp += "way";
                                    Console.Write(UpperCaseFirstLetter(temp + " "));
                                }
                                else if (match.Success || matchTwo.Success || matchThree.Success || matchFour.Success || matchFive.Success || matchSeven.Success || matchEight.Success || matchNine.Success || matchTen.Success || matchEleven.Success)
                                {
                                    Console.Write(UpperCaseFirstLetter(temp) + " ");
                                }
                                else
                                {
                                    temp += "way";
                                    Console.Write(UpperCaseFirstLetter(temp + " "));
                                }
                            }
                            else
                            {
                                Match match = Regex.Match(temp, numberPatternDigit);
                                Match matchTwo = Regex.Match(temp, numberPatternDigitLetter);
                                Match matchThree = Regex.Match(temp, numberPatternLetterDigit);
                                Match matchFour = Regex.Match(temp, numberPatternLetterDigitLetter);
                                Match matchFive = Regex.Match(temp, numberPatternDigitLetterDigit);
                                Match matchSix = Regex.Match(temp, emailPattern);
                                Match matchSeven = Regex.Match(temp, symbolPatternSymbol);
                                Match matchEight = Regex.Match(temp, symbolPatternSymbolLetter);
                                Match matchNine = Regex.Match(temp, symbolPatternLetterSymbol);
                                Match matchTen = Regex.Match(temp, symbolPatternLetterSymbolLetter);
                                Match matchEleven = Regex.Match(temp, symbolPatternSymbolLetterSymbol);
                                Match matchTwelve = Regex.Match(temp, period);
                                Match matchThirteen = Regex.Match(temp, contract);

                                if (matchSix.Success)
                                {
                                    Console.Write(temp.ToLower() + " ");

                                }
                                else if (matchThirteen.Success)
                                {
                                    string slot = stringArray[i];
                                    int h = ConsonantChecker(slot);
                                    int move;
                                    if (h == 0)
                                    {
                                        move = h + 1;
                                    }
                                    else
                                    {
                                        move = h;
                                    }
                                    temp = slot.Substring(h, (slot.Length - move));
                                    string pigLatin;
                                    if (temp.Length == 1)
                                    {
                                        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                    }
                                    else
                                    {
                                        pigLatin = temp + slot.Substring(0, h) + "ay";

                                    }
                                    Console.Write(pigLatin + " ");
                                }
                                else if (match.Success || matchTwo.Success || matchThree.Success || matchFour.Success || matchFive.Success || matchSeven.Success || matchEight.Success || matchNine.Success || matchTen.Success || matchEleven.Success)
                                {
                                    Console.Write(UpperCaseFirstLetter(temp) + " ");
                                }
                                else
                                {
                                    string slot = stringArray[i];
                                    int h = ConsonantChecker(slot);
                                    int move;
                                    if (h == 0)
                                    {
                                        move = h + 1;
                                    }
                                    else
                                    {
                                        move = h;
                                    }
                                    temp = slot.Substring(h, (slot.Length - move));
                                    string pigLatin;
                                    if (temp.Length == 1)
                                    {
                                        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                    }
                                    else
                                    {
                                        pigLatin = temp + slot.Substring(0, h) + "ay";

                                    }
                                    Console.Write(pigLatin + " ");
                                }
                            }
                        }
                        else if (!revert)
                        {
                            if (VowelChecker(temp, 0))
                            {
                                Match match = Regex.Match(temp, numberPatternDigit);
                                Match matchTwo = Regex.Match(temp, numberPatternDigitLetter);
                                Match matchThree = Regex.Match(temp, numberPatternLetterDigit);
                                Match matchFour = Regex.Match(temp, numberPatternLetterDigitLetter);
                                Match matchFive = Regex.Match(temp, numberPatternDigitLetterDigit);
                                Match matchSix = Regex.Match(temp, emailPattern);
                                Match matchSeven = Regex.Match(temp, symbolPatternSymbol);
                                Match matchEight = Regex.Match(temp, symbolPatternSymbolLetter);
                                Match matchNine = Regex.Match(temp, symbolPatternLetterSymbol);
                                Match matchTen = Regex.Match(temp, symbolPatternLetterSymbolLetter);
                                Match matchEleven = Regex.Match(temp, symbolPatternSymbolLetterSymbol);
                                Match matchTwelve = Regex.Match(temp, period);
                                Match matchThirteen = Regex.Match(temp, contract);

                                if (matchSix.Success)
                                {
                                    Console.Write(temp.ToLower() + " ");

                                }
                                //else if (matchTwelve.Success)
                                //{
                                //    string prePunctuation = temp.Substring(0, temp.Length - 1);
                                //    //int tempLength = temp.Length - 1;
                                //    //temp += "way";
                                //    Console.Write((prePunctuation += "way") + temp[temp.Length - 1] + " ");
                                //    //What im doing above is grab the punctuation at end, seperate it from rest of string, manipulate the string, add punctuation back, add space
                                //}
                                else if (matchThirteen.Success)
                                {
                                    temp += "way";
                                    Console.Write(temp + " ");
                                }
                                else if (match.Success || matchTwo.Success || matchThree.Success || matchFour.Success || matchFive.Success || matchSeven.Success || matchEight.Success || matchNine.Success || matchTen.Success || matchEleven.Success)
                                {
                                    Console.Write(temp + " ");
                                }
                                else
                                {
                                    temp += "way";
                                    Console.Write(temp + " ");
                                }
                            }
                            else
                            {
                                Match match = Regex.Match(temp, numberPatternDigit);
                                Match matchTwo = Regex.Match(temp, numberPatternDigitLetter);
                                Match matchThree = Regex.Match(temp, numberPatternLetterDigit);
                                Match matchFour = Regex.Match(temp, numberPatternLetterDigitLetter);
                                Match matchFive = Regex.Match(temp, numberPatternDigitLetterDigit);
                                Match matchSix = Regex.Match(temp, emailPattern);
                                Match matchSeven = Regex.Match(temp, symbolPatternSymbol);
                                Match matchEight = Regex.Match(temp, symbolPatternSymbolLetter);
                                Match matchNine = Regex.Match(temp, symbolPatternLetterSymbol);
                                Match matchTen = Regex.Match(temp, symbolPatternLetterSymbolLetter);
                                Match matchEleven = Regex.Match(temp, symbolPatternSymbolLetterSymbol);
                                Match matchTwelve = Regex.Match(temp, period);
                                Match matchThirteen = Regex.Match(temp, contract);

                                if (matchSix.Success)
                                {
                                    Console.Write(temp.ToLower() + " ");

                                }
                                else if (matchThirteen.Success)
                                {
                                    string slot = stringArray[i];
                                    int h = ConsonantChecker(slot);
                                    int move;
                                    if (h == 0)
                                    {
                                        move = h + 1;
                                    }
                                    else
                                    {
                                        move = h;
                                    }
                                    temp = slot.Substring(h, (slot.Length - move));
                                    string pigLatin;
                                    if (temp.Length == 1)
                                    {
                                        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                    }
                                    else
                                    {
                                        pigLatin = temp + slot.Substring(0, h) + "ay";

                                    }
                                    Console.Write(pigLatin + " ");
                                }
                                else if (match.Success || matchTwo.Success || matchThree.Success || matchFour.Success || matchFive.Success || matchSeven.Success || matchEight.Success || matchNine.Success || matchTen.Success || matchEleven.Success)
                                {
                                    Console.Write(temp + " ");
                                }
                                else
                                {
                                    string slot = stringArray[i];
                                    int h = ConsonantChecker(slot);
                                    int move;
                                    if (h == 0)
                                    {
                                        move = h + 1;
                                    }
                                    else
                                    {
                                        move = h;
                                    }
                                    temp = slot.Substring(h, (slot.Length - move));
                                    string pigLatin;
                                    if (temp.Length == 1)
                                    {
                                        pigLatin = slot.Substring(1, 1) + temp + "ay";
                                    }
                                    else
                                    {
                                        pigLatin = temp + slot.Substring(0, h) + "ay";

                                    }
                                    Console.Write(pigLatin + " ");
                                }
                            }
                        }
                    }
                    Console.WriteLine();
                    truth = Continue();
                }
            }

        }



        public static string UpperCaseFirstLetter(string x)
        {
            return char.ToUpper(x[0]) + x.Substring(1);
        }

        public static string PigLatinMaker()
        {
            Console.Write("Please insert the word you want to check: ");

            string x = Console.ReadLine().ToLower();

            string temp = x.Substring(1, x.Length - 1);

            string pigLatin = temp + x.Substring(0, 1) + "ay";

            Console.Write(pigLatin);
            return pigLatin;
        }

        public static string FirstSlotCaseUpperer(string slot, bool firstSlotCaseTester)
        {
            if (firstSlotCaseTester)
            {
                string a = slot.Substring(1, slot.Length - 1);
                char b = Char.ToUpper(slot[0]);
                string answer = b + a;
                return answer;
            }
            return slot;
        }

        public static bool FirstSlotCaseTester(string slot)
        {
            return Char.IsUpper(slot, 0);
        }

        public static bool FullCaseTester(string slot)
        {
            Match matchNine = Regex.Match(slot, @"([a-zA-z]+)(\W+)");

            int i;
            for (i = 0; i < slot.Length; i++)
            {
                if (Char.IsUpper(slot, i) || slot[i] == '\'' || matchNine.Success)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public static bool VowelChecker(string first, int x)
        {
            if (x < first.Length - 1)
            {
                if (first.Substring(x, 1) == "a" || first.Substring(x, 1) == "e" || first.Substring(x, 1) == "i" || first.Substring(x, 1) == "o" || first.Substring(x, 1) == "u" || first.Substring(x, 1) == "A" || first.Substring(x, 1) == "E" || first.Substring(x, 1) == "I" || first.Substring(x, 1) == "O" || first.Substring(x, 1) == "U")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static int ConsonantChecker(string array)
        {
            int i;
            int x;
            for (i = 0; i < array.Length; i++)
            {
                if (!VowelChecker(array, 0) && array.Length == 2)
                {
                    return i = 0;
                }
                else if (!VowelChecker(array, i))
                {
                    x = i;
                }
                else
                {
                    return i;
                } //if the substring that i make for consonant takes one letter too much subtract i with 1 before returning, but that might cause an issue with 0
            }
            return i;

        }

        public static bool Continue()
        {
            while (true)
            {
                Console.Write("\t\t\t\t\t\tContinue? (y/n): ");

                string jump = Console.ReadLine().ToUpper();

                if (jump == "N")
                {
                    return false;
                }
                else if (jump == "Y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Input was not \"y\" or \"n\"! Please try again!");
                    continue;
                }
            }
        }
        /*public static bool VowelCheckerSentence(string[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                string temp = x[i];
                if (VowelChecker(temp))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }*/
    }
}
