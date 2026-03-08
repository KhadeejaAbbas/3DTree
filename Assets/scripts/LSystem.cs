using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;   

// Based off of and with referecence to:
    // The Nature of Code
    // Daniel Shiffman
    // http://natureofcode.com
public class LSystem
{

    string sentence;     // The sentence (a String)
    Rule[] ruleset;      // The ruleset (an array of Rule objects)
    int generation;      // Keeping track of the generation #

    // Construct an LSystem with a startin sentence and a ruleset
    public LSystem(string axiom, Rule[] r) {
        sentence = axiom;
        ruleset = r;
        generation = 0;
    }

    // Generate the next generation
    public void Generate() {
        // An empty StringBuffer that we will fill
        StringBuilder nextgen = new StringBuilder();
        // For every character in the sentence
        for (int i = 0; i < sentence.Length; i++) {
            // What is the character
            char curr = sentence[i];
            // We will replace it with itself unless it matches one of our rules
            string replace = curr.ToString();

            // Check every rule
            for (int j = 0; j < ruleset.Length; j++) {
                char a = ruleset[j].GetA();
                // if we match the Rule, get the replacement String out of the Rule
                if (a == curr) {
                    replace = ruleset[j].GetB();
                    break; 
                }
            }
            // Append replacement String
            nextgen.Append(replace);
        }
        // Replace sentence
        sentence = nextgen.ToString();
        // Increment generation
        generation++;
    }

    public string GetSentence() {
        return sentence; 
    }

    public int GetGeneration() {
        return generation; 
    }
}


