using System;

namespace ITD.Monitor.Common
{
    public class StringHelper
    {
        public static string ChangeWords(string s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            string result = "";
            string strOne = "";
            string strTwo = "";
            //lấy danh sách các từ

            string[] words = s.Split(' ');

            try
            {
                for (int i = 0; i <= words.Length; i++)
                {
                    // từ nào là các khoảng trắng thừa thì bỏ
                    if (words[i].Trim() != "")
                    {
                        if (words[i].Length > 1)
                        {
                            string str = words[i].Substring(0, 2).ToUpper();
                            if (str == "MT")
                            {
                                result += words[i].Substring(0, 2).ToUpper() + words[i].Substring(2).ToLower() + " ";
                                break;
                            }
                            else
                            {
                                if (words.Length > 1)
                                {
                                    if (i == 0)
                                    {
                                        strOne += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower() + " ";
                                    }
                                    else
                                    {
                                        strTwo += words[i].Substring(0, 1).ToLower() + words[i].Substring(1).ToLower() + " ";
                                        result = strOne + strTwo;
                                        break;
                                    }
                                }
                                else
                                {
                                    result = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            result += words[i].Substring(0, 1).ToUpper();
                            break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                NLogHelper.NLogHelper.Error(ex);
            }
            return result.Trim();
        }
    }
}