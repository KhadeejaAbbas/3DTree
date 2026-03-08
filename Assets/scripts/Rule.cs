using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    // Based off of and with referecence to:
        // The Nature of Code
        // Daniel Shiffman
        // http://natureofcode.com

    // LSystem Rule class

    private char a;
    private string b;

    public Rule(char a_, string b_) {
        a = a_;
        b = b_; 
    }

    public char GetA() {
        return a;
    }

    public string GetB() {
        return b;
    }
}
