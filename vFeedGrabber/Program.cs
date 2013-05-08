using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FeedLogic;
using UtilLogic;

namespace vFeedGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Grabbing feed... STARTED");
            string xmlContent = Grab.GetContent(Configuration.GetKey("Url"));

            if (!string.IsNullOrEmpty(xmlContent))
            {
                Console.WriteLine("Saving feed... STARTED");
                string savedMessage = Grab.SaveContent(xmlContent);
                Console.WriteLine(savedMessage);
            }
            else
            {
                Console.WriteLine("Feed is empty, please try again or try a different URL");
            }
        }
    }
}
