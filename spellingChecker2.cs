//Trying this with lists cause fuck hashtables

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
//using System.Windows.Forms; // For text box stuff

namespace spellingChecker {
  class checkSpell {
    static void Main () {
      List<String> dicWords = new List<String>();
      List<String> userWords = new List<String>();
      List<String> badWords = new List<String>();

      /* WOO LETS DO THIS! */
    //  string [] dictionary = File.ReadAllLines(".\\dict2.txt");
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      string dictionary = File.ReadAllText(".\\dictionary.txt");
      String [] dicFile = dictionary.Split(' ');

      string userFile = File.ReadAllText(".\\userFile.txt");
      userFile = CleanInput(userFile);
      userFile = userFile.ToLower();
      String [] userInput = userFile.Split(' ');

      foreach (String s in dicFile) {
        if (!dicWords.Contains(s)) {
          dicWords.Add(s);
        }
      }

      foreach (String s in userInput) {
        if (!userWords.Contains(s)) {
          userWords.Add(s);
          Console.Write(s);
          }
        }

      stopwatch.Stop();
      TimeSpan ts = stopwatch.Elapsed;

      string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                 ts.Hours, ts.Minutes, ts.Seconds,
                 ts.Milliseconds / 10);
      Console.WriteLine("RunTime " + elapsedTime);

    }

      static string CleanInput(string strIn) {
        try {
            return Regex.Replace(strIn, @"[\p{P}]", "",
                                 RegexOptions.None, TimeSpan.FromSeconds(1.5));
            }
        catch (RegexMatchTimeoutException) {
            return String.Empty;
            }
        }
    }
}
