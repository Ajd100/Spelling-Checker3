/* Spelling Checker */
/* Anthony Decker */
/* October 17, 2018 */

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
//using System.Windows.Forms; // For text box stuff

namespace spellingChecker {
  class checkSpell {
    static void Main () {
      Hashtable dictHash = new Hashtable();
      Hashtable userHash = new Hashtable();
      List<String> badWords = new List<String>();

      /* WOO LETS DO THIS! */
      string [] dictionary = File.ReadAllLines(".\\dict2.txt");
      string userFile = File.ReadAllText(".\\testFile.txt");

      userFile = CleanInput(userFile);
  //    Console.Write(userFile +"\n\n");
//      Console.Write(userFile);
      //Cleaning the userFile
  /*    var sb = new StringBuilder();
        foreach (char c in userFile)  {
          if (!char.IsPunctuation(c))
            sb.Append(char.ToLower(c));
          }
        userFile = sb.ToString();
        userFile.Replace(Environment.NewLine, ""); */
      //  Console.WriteLine(userFile + '\n');
        foreach (char c in userFile) {

        }

        userFile = userFile.ToLower();
        String [] userInput = userFile.Split(' ');

      //  String [] userFile1 = userFile.Split('\n');
      //  String userInpu1 = userFile.ToString();
        //Console.Write(userFile1);
        //String [] userInput = userInpu1.Split(' ');
      //  Console.Write(userInput);

        foreach (string s in userInput) {
  //        Console.Write(s);
        }

      foreach (string w in dictionary) {
        if(!dictHash.ContainsKey(w)){
          dictHash.Add(w, w.GetHashCode());
        }//Console.Write("\t" + w);
      }

    //  Console.Write(userFile);

    /*  foreach (string w in userInput) {
        Console.WriteLine(w);
      }*/

      foreach (string w in userInput) {
        if(!userHash.ContainsKey(w)){
          userHash.Add(w, w.GetHashCode());
          Console.WriteLine(w);
        }
      }

      foreach (DictionaryEntry j in dictHash) {
      //  Console.Write(j.Key + ", " + j.Value);
        }

    //  foreach (DictionaryEntry i in dictHash){
      foreach (DictionaryEntry j in userHash) {
        if (!dictHash.ContainsValue((int) j.Value)) {
          if (((String) (j.Key)).Length > 1) {
            badWords.Add(((String) (j.Key)).Trim());
          }
        //  Console.WriteLine((String) j.Key);
        }
      }

  /*      foreach (DictionaryEntry j in userHash) {
          //if (!dictHash.ContainsValue((int) j.Value)) {
            Console.Write(j.Key + ", " + j.Value);
          }*/
        //  }


      foreach (String i in badWords){
        Console.WriteLine(i + " is misspelled");
      }
      //  }
        //Console.Write((int) i.Value + ",");
      }

      static string CleanInput(string strIn) {
        try {
//          return Regex.Replace(strIn, @"[^\w\.@-]", "",
          return Regex.Replace(strIn, @"[\p{P}]", "",
                               RegexOptions.None, TimeSpan.FromSeconds(1.5));
       }
       // If we timeout when replacing invalid characters,
       // we should return Empty.
       catch (RegexMatchTimeoutException) {
          return String.Empty;
       }
      }


//      TextBox txt = new TextBox();

    }
  }
