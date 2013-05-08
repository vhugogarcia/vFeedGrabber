using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using UtilLogic;

namespace FeedLogic
{
    public class Grab
    {
        /// <summary>
        /// Grab the Content from the specified URL
        /// </summary>
        /// <param name="url">Feed URL</param>
        /// <returns>The Source code of the url specified once loaded</returns>
        public static string GetContent(string url)
        {
            try
            {
                int timeout = Convert.ToInt32(Configuration.GetKey("WebRequestTimeout"));
                
                HttpWebRequest myWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myWebRequest.Method = "GET";
                myWebRequest.Timeout = timeout;
                HttpWebResponse myWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
                StreamReader myWebSource = new StreamReader(myWebResponse.GetResponseStream());
                
                string myPageSource = string.Empty;
                myPageSource = myWebSource.ReadToEnd();
                myWebResponse.Close();

                return myPageSource;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Creates the file if it doesn't exist and overwrites it if it exists.
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public static string SaveContent(string xmlContent)
        {
            try
            {
                string fileSave = Configuration.GetKey("FilePath") + Configuration.GetKey("FileName");
                System.IO.File.WriteAllText(fileSave, xmlContent);
                return "COMPLETED";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message + "\nSuggestion: Check FilePath setting and check the user has permissions to read and write the folder";
            }
            
        }
    }
}
