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

   private int state = 0;
   private int s1 = 0;
   private int s2 = 0;
   private int s3 = 0;
   private int s4 = 0;
   private int badIndex = 0;

   string[] words = { "gay", "homosexual"};

   static int ModuleIdCounter = 1;
   int ModuleId;
   private bool ModuleSolved;

   void buttonPress (KMSelectable a) {
      a.AddInteractionPunch();
      if (ModuleSolved) {
         return;
      }
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, a.transform);
      if (a == buttons[0]) {
         if  (checkState((s1 + 1) % 2, s2, s3, s4, badIndex) == 1) {
            Strike();
            Debug.LogFormat("button 1 pressed, illegal state reached. level 1 woke smh");
         }
         else {
            s1 = (s1 + 1) % 2;
            Debug.LogFormat("button 1 pressed, state is legal");
         }
      }
      else if (a == buttons[1]) {
         if (checkState(s1, (s2 + 1) % 2, s3, s4, badIndex) == 1) {
            Strike();
            Debug.LogFormat("button 2 pressed, illegal state reached. level 1 woke smh");
         }
         else {
           s2 = (s2 + 1) % 2;
           Debug.LogFormat("button 2 pressed, state is legal");
         }
      }
      else if (a == buttons[2]) {
         if (checkState(s1, s2, (s3 + 1) % 2, s4, badIndex) == 1) {
            Strike();
            Debug.LogFormat("button 3 pressed, illegal state reached. level 1 woke smh");
         }
         else {
            s3 = (s3 + 1) % 2;
            Debug.LogFormat("button 3 pressed, state is legal");
         }
      }
      else {
         if (checkState(s1, s2, s3, (s4 + 1) % 2, badIndex) == 1) {
            Strike();
            Debug.LogFormat("button 4 pressed, illegal state reached. level 1 woke smh");
         }
         else {
            s4 = (s4 + 1) % 2;
            Debug.LogFormat("button 4 pressed, state is legal");
         }
      }
      if (currentState(s1, s2, s3, s4) == 3) {
         Solve();
         Debug.LogFormat("gay gay homosexual gay");
      }
      else {
         state = state;
      }
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
         if (currentState(a, b, c, d) == 12 || currentState(a, b, c, d) == 6 || currentState(a, b, c, d) == 4 || currentState(a, b, c, d) == 7) {
            return 1;
         }
         else {
            return 0;
         }
      }
      else if (tableIndex(s) == 0) {
         if (currentState(a, b, c, d) == 13 || currentState(a, b, c, d) == 16 || currentState(a, b, c, d) == 8 || currentState(a, b, c, d) == 4) {
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

      Debug.LogFormat("[gay gay homosexual gay #{0}] current state is: {1}", ModuleId, words[s1] + " " + words[s2] + " " + words[s3] + " " + words[s4]);

      int table = 0;
      if (serial == 4) {
         table = 4;
      }
      else {
         table = serial % 4;
      }

      Debug.LogFormat("[gay gay homosexual gay #{0}] last digit of the serial number is {1}, illegal states taken from table {2}", ModuleId, serial, table);
   }


   void Solve () {
      GetComponent<KMBombModule>().HandlePass();
      ModuleSolved = true;
      solveText.text = "^w^";
   }

   void Strike () {
      StartCoroutine(StrikeAnimation());
      GetComponent<KMBombModule>().HandleStrike();
   }

   IEnumerator StrikeAnimation () {
   solveText.text = "3:";
   solveText.transform.eulerAngles = new Vector3(90, 246, 0);
   for (int i = 0; i < 4; i++) {
      gayTexts[i].text = "";
   }
   yield return new WaitForSeconds(1f);
   solveText.text = ":3";
   currentState(s1, s2, s3, s4);
   solveText.transform.eulerAngles = new Vector3(90, 34, 0);
   }

#pragma warning disable 414
   private readonly string TwitchHelpMessage = @"Use !{0} to do something.";
#pragma warning restore 414

   IEnumerator ProcessTwitchCommand (string Command) {
      yield return null;
   }

   IEnumerator TwitchHandleForcedSolve () {
      yield return null;
   }
}
