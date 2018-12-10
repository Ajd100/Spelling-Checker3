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

      String dictionary = File.ReadAllText(".\\dictionary.txt");
      String [] dicFile = dictionary.Split(' ');



      Dictionary<string,int> dicWords = new Dictionary<string, int>();
      Dictionary<string,int> userWords = new Dictionary<string, int>();

    //  bool insert = dicWords.
    //  List<String> dicWords = new List<String>();
    //  List<String> userWords = new List<String>();
      List<String> badWords = new List<String>();

      /* WOO LETS DO THIS! */
    //  string [] dictionary = File.ReadAllLines(".\\dict2.txt");
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();


      string userFile = File.ReadAllText(".\\userFile.txt");
      userFile = CleanInput(userFile);
      userFile = userFile.ToLower();
      String [] userInput = userFile.Split(' ');

      foreach (String s in dicFile) {
      //  if (!dicWords.ContainsKey(s)) {
          dicWords.TryAdd(s, s.GetHashCode());
      //  }
      }

      foreach (String s in userInput) {
    //    if (!userWords.ContainsKey(s)) {
          userWords.TryAdd(s, s.GetHashCode());
          Console.Write(s);
      //    }
        }

      foreach (KeyValuePair<string, int> j in userWords) {
        if (!dicWords.ContainsKey((string) j.Key)) {
      //    if (((String) (j.Key)).Length > 0) {
            badWords.Add(((String) (j.Key)).Trim());
          }
        //  Console.WriteLine((String) j.Key);
        }

      foreach (string s in badWords) {
        Console.WriteLine(s + " isn't in the dictionary");
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
