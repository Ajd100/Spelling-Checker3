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
      //Dictionary stuff...
      string dictionary = File.ReadAllText(".\\dictionary.txt");
      String [] dicFile = dictionary.Split(' ');
      List<String> wordList = dicFile.ToList();

      //User File stuff...
      string userFile = File.ReadAllText(".\\file1.txt");
      userFile = CleanInput(userFile);
      userFile = userFile.ToLower();
      String [] userInput = userFile.Split(' ');
      List<String> userList = userInput.ToList();

      //Sending the dictionary stuffs to the hashtable
      for (int i = 0; i < wordList.Count; ++i) {
        dictHash.Add(wordList[i].ToLower(), wordList[i].ToLower().GetHashCode());
      }

      //Checking the input against the hashtable.
      for (int j = 0; j < userList.Count; ++j) {
        var hash = userList[j].ToLower().GetHashCode();
        if (!dictHash.ContainsValue(hash)) {
          if (!badWords.Contains(userList[j]) && userList[j] != "") {
            badWords.Add(userList[j]);
          }
        }
      }

      //Iterating through the bad list and printing the misspelled words
      foreach (String i in badWords){
        Console.WriteLine(i + " is misspelled");
      }
    }

      //Cleaning the text by removing all bad input
      static string CleanInput(string strIn) {
        strIn = Regex.Replace(strIn, @"\p{P}" , " ");
        strIn = Regex.Replace(strIn, @"\W", " ");
        strIn = Regex.Replace(strIn, @"^\s+", " ");
        strIn = Regex.Replace(strIn, @"\d", " ");

        return strIn;
      }
    }
  }
