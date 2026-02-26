using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
using rnd = UnityEngine.Random;
using math = ExMath;

public class gaygayhomogay : MonoBehaviour {

   public KMBombInfo Bomb;
   public KMAudio Audio;

   public KMSelectable[] buttons;
   public TextMesh[] gayTexts;
   public TextMesh solveText;
   public TextMesh strikeText;

   private int state = 0;
   private int s1 = 0;
   private int s2 = 0;
   private int s3 = 0;
   private int s4 = 0;
   private int badIndex = 0;
   private int strike = 0;
   private int started = 0;

   string[] words = { "gay", "homosexual"};
   string[] sounds = { "clicker-single-mono", "gghg-wet", "gghg-maddy-wet", "gghg-aidan"};

   static int ModuleIdCounter = 1;
   int ModuleId;
   private bool ModuleSolved;

   void buttonPress (KMSelectable a) {
      a.AddInteractionPunch();
      Audio.PlaySoundAtTransform(sounds[0], a.transform);
      if (ModuleSolved || strike == 1 || started == 0) {
         return;
      }
      if (a == buttons[0]) {
         if  (checkState((s1 + 1) % 2, s2, s3, s4, badIndex) == 1) {
            strike = 1;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 1 pressed, anti woke state reached. smh", ModuleId);
         }
         else {
            s1 = (s1 + 1) % 2;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 1 pressed, woke o meter hasnt fallen yet, carry on", ModuleId);
         }
      }
      else if (a == buttons[1]) {
         if (checkState(s1, (s2 + 1) % 2, s3, s4, badIndex) == 1) {
            strike = 1;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 2 pressed, anti woke state reached. smh", ModuleId);
         }
         else {
           s2 = (s2 + 1) % 2;
           Debug.LogFormat("[gay gay homosexual gay #{0}] button 2 pressed, woke o meter hasnt fallen yet, carry on", ModuleId);
         }
      }
      else if (a == buttons[2]) {
         if (checkState(s1, s2, (s3 + 1) % 2, s4, badIndex) == 1) {
            strike = 1;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 3 pressed, anti woke state reached. smh", ModuleId);
         }
         else {
            s3 = (s3 + 1) % 2;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 3 pressed, woke o meter hasnt fallen yet, carry on", ModuleId);
         }
      }
      else {
         if (checkState(s1, s2, s3, (s4 + 1) % 2, badIndex) == 1) {
            strike = 1;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 4 pressed, anti woke state reached. smh", ModuleId);
         }
         else {
            s4 = (s4 + 1) % 2;
            Debug.LogFormat("[gay gay homosexual gay #{0}] button 4 pressed, woke o meter hasnt fallen yet, carry on", ModuleId);
         }
      }
      if (currentState(s1, s2, s3, s4) == 3) {
         Solve();
         Audio.PlaySoundAtTransform(sounds[rnd.Range(1, 4)], transform);
         Debug.LogFormat("[gay gay homosexual gay #{0}] gay gay homosexual gay", ModuleId);
      }
      else {
         state = state;
      }
      if (strike == 1) 
         Strike();
      }
   

   void Awake () { //Avoid doing calculations in here regarding edgework. Just use this for setting up buttons for simplicity.
      ModuleId = ModuleIdCounter++;
      GetComponent<KMBombModule>().OnActivate += Activate;
      
      foreach (KMSelectable button in buttons) {
          button.OnInteract += delegate () { buttonPress(button); return false; };
      }

   }

   void OnDestroy () { //Shit you need to do when the bomb ends
      
   }

   void Activate () { //Shit that should happen when the bomb arrives (factory)/Lights turn on
      int initTest = 1;
      int serial = Bomb.GetSerialNumberNumbers().Last();
      badIndex = tableIndex(serial);


      while (initTest == 1) {
         s1 = rnd.Range(0, 2);
         s2 = rnd.Range(0, 2);
         s3 = rnd.Range(0, 2);
         s4 = rnd.Range(0, 2);
         if (checkState(s1, s2, s3, s4, badIndex) == 1 || currentState(s1, s2, s3, s4) == 3) {
            initTest = 1;
         }
         else {
            state = currentState(s1, s2, s3, s4);
            initTest = 0;
         }
      }
      started = 1;
      Debug.LogFormat("[gay gay homosexual gay #{0}] current state is: {1}", ModuleId, words[s1] + " " + words[s2] + " " + words[s3] + " " + words[s4]);
   }

   void Update () { //Shit that happens at any point after initialization
      
   }

   int currentState (int a, int b, int c, int d) {
      if (a == 0) {
      gayTexts[0].text = words[0];
      }
      else {
         gayTexts[0].text = words[1];
      }
      if (b == 0) {
         gayTexts[1].text = words[0];
      }
      else {
         gayTexts[1].text = words[1];
      }
      if (c == 0) {
         gayTexts[2].text = words[0];
      }
      else {
         gayTexts[2].text = words[1];
      }
      if (d == 0) {
         gayTexts[3].text = words[0];
      }
      else {
         gayTexts[3].text = words[1];
      }

      if (a == 0) {
         if (b == 0) {
            if (c == 0) {
               if (d == 0) {
                  return 1;
               }
               else {
                  return 2;
               }
            }
            else {
               if (d == 0) {
                  return 3;
               }
               else {
                  return 4;
               }
            }
         }
         else {
            if (c == 0) {
               if (d == 0) {
                  return 5;
               }
               else {
                  return 6;
               }
            }
            else {
               if (d == 0) {
                  return 7;
               }
               else {
                  return 8;
               }
            }
         }
      }
      else {
         if (b == 0) {
            if (c == 0) {
               if (d == 0) {
                  
                  return 9;
               }
               else {
                  return 10;
               }
            }
            else {
               if (d == 0) {
                  return 11;
               }
               else {
                  return 12;
               }
            }
         }
         else {
            if (c == 0) {
               if (d == 0) {
                  return 13;
               }
               else {
                  return 14;
               }
            }
            else {
               if (d == 0) {
                  return 15;
               }
               else {
                  return 16;
               }
            }
         }
      }
   }

   int currentState2 (int a, int b, int c, int d) {
      if (a == 0) {
         if (b == 0) {
            if (c == 0) {
               if (d == 0) {
                  return 1;
               }
               else {
                  return 2;
               }
            }
            else {
               if (d == 0) {
                  return 3;
               }
               else {
                  return 4;
               }
            }
         }
         else {
            if (c == 0) {
               if (d == 0) {
                  return 5;
               }
               else {
                  return 6;
               }
            }
            else {
               if (d == 0) {
                  return 7;
               }
               else {
                  return 8;
               }
            }
         }
      }
      else {
         if (b == 0) {
            if (c == 0) {
               if (d == 0) {
                  
                  return 9;
               }
               else {
                  return 10;
               }
            }
            else {
               if (d == 0) {
                  return 11;
               }
               else {
                  return 12;
               }
            }
         }
         else {
            if (c == 0) {
               if (d == 0) {
                  return 13;
               }
               else {
                  return 14;
               }
            }
            else {
               if (d == 0) {
                  return 15;
               }
               else {
                  return 16;
               }
            }
         }
      }
   }

   int tableIndex (int a) {
      if (a % 4 == 0) {
         return 0;
      }
      else if (a % 4 == 1) {
         return 1;
      }
      else if (a % 4 == 2) {
         return 2;
      }
      else {
         return 3;
      }
   }

   int checkState(int a, int b, int c, int d, int s) {
      if (tableIndex(s) == 1) {
         if (currentState(a, b, c, d) == 6 || currentState(a, b, c, d) == 9 || currentState(a, b, c, d) == 1 || currentState(a, b, c, d) == 15) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 2) {
         if (currentState(a, b, c, d) == 2 || currentState(a, b, c, d) == 10 || currentState(a, b, c, d) == 5 || currentState(a, b, c, d) == 11) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 3) {
         if (currentState(a, b, c, d) == 12 || currentState(a, b, c, d) == 15 || currentState(a, b, c, d) == 4 || currentState(a, b, c, d) == 7) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 0) {
         if (currentState(a, b, c, d) == 13 || currentState(a, b, c, d) == 16 || currentState(a, b, c, d) == 8 || currentState(a, b, c, d) == 14) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else {
         return 0;
      }
   }

   int checkState2(int a, int b, int c, int d, int s) {
      if (tableIndex(s) == 1) {
         if (currentState2(a, b, c, d) == 6 || currentState2(a, b, c, d) == 9 || currentState2(a, b, c, d) == 1 || currentState2(a, b, c, d) == 15) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 2) {
         if (currentState2(a, b, c, d) == 2 || currentState2(a, b, c, d) == 10 || currentState2(a, b, c, d) == 5 || currentState2(a, b, c, d) == 11) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 3) {
         if (currentState2(a, b, c, d) == 12 || currentState2(a, b, c, d) == 15 || currentState2(a, b, c, d) == 4 || currentState2(a, b, c, d) == 7) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 0) {
         if (currentState2(a, b, c, d) == 13 || currentState2(a, b, c, d) == 16 || currentState2(a, b, c, d) == 8 || currentState2(a, b, c, d) == 14) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else {
         return 0;
      }
   }

   void Start () { //Shit that you calculate, usually a majority if not all of the module
      int serial = Bomb.GetSerialNumberNumbers().Last();

      int table = 0;
      if (serial % 4 == 0) {
         table = 4;
      }
      else {
         table = serial % 4;
      }

      Debug.LogFormat("[gay gay homosexual gay #{0}] last digit of the serial number is {1}, anti woke states taken from table {2}", ModuleId, serial, table);
   }


   void Solve () {
      GetComponent<KMBombModule>().HandlePass();
      ModuleSolved = true;
      solveText.text = "^w^";
   }

   void Strike () {
      Debug.Log("STRIKE CALLED - about to start coroutine");
      IEnumerator anim = StrikeAnimation();
      Debug.Log("STRIKE - coroutine created: " + anim);
      StartCoroutine(anim);
      Debug.Log("STRIKE - coroutine started, now calling HandleStrike");
      GetComponent<KMBombModule>().HandleStrike();
      Debug.Log("STRIKE - HandleStrike complete");
   }

   IEnumerator StrikeAnimation () {
      Debug.Log("gay strike animation started");
      Debug.Log("gayTexts array length: " + gayTexts.Length);
      for (int i = 0; i < gayTexts.Length; i++) {
         Debug.Log("gayTexts[" + i + "] current text: '" + gayTexts[i].text + "'");
      }

      solveText.text = "";
      strikeText.text = "3:";

      gayTexts[0].text = "ANTI";
      gayTexts[1].text = "WOKE";
      gayTexts[2].text = "STATE";
      gayTexts[3].text = "DETECTED";

      yield return new WaitForSeconds(1f);
      Debug.Log("gay text restoring");
      solveText.text = ":3";
      strikeText.text = "";
      currentState(s1, s2, s3, s4);
      strike = 0;
      Debug.Log("gay strike animation finished");
   }

#pragma warning disable 414
   private readonly string TwitchHelpMessage = @"use !{0} 1/2/3/4.";
#pragma warning restore 414

   IEnumerator ProcessTwitchCommand (string Command) {
      Command = Command.Trim().ToUpper();
      yield return null;
      string commands = Command;
      for (int i = 0; i < commands.Length; i++) {
         if ("1234".Contains(commands[i]) == false) {
            yield return "sendtochaterror whar did u type";
            yield break;
         }
      }
      for (int i = 0; i < commands.Length; i++) {
         buttons[Array.IndexOf("1234".ToCharArray(), commands[i])].OnInteract();
         yield return new WaitForSeconds(.1f);
      }
   }

   IEnumerator TwitchHandleForcedSolve () {
      while (ModuleSolved == false) {
         if (s1 != 0) {
            if (checkState2((s1 + 1) % 2, s2, s3, s4, badIndex) != 1) {
               buttons[0].OnInteract();
               yield return new WaitForSeconds(.1f);
            }
         }
         if (s2 != 0) {
            if (checkState2(s1, (s2 + 1) % 2, s3, s4, badIndex) != 1) {
               buttons[1].OnInteract();
               yield return new WaitForSeconds(.1f);
            }
         }
         if (s3 != 1) {
            if (checkState2(s1, s2, (s3 + 1) % 2, s4, badIndex) != 1) {
               buttons[2].OnInteract();
               yield return new WaitForSeconds(.1f);
            }
         }
         if (s4 != 0) {
            if (checkState2(s1, s2, s3, (s4 + 1) % 2, badIndex) != 1) {
               buttons[3].OnInteract();
               yield return new WaitForSeconds(.1f);
            }
         }
         yield return new WaitForSeconds(.1f);
      }
      yield return null;
   }

}
