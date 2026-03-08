using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{

    // default angle, index, dropbox
    // get them from UI
    public UIHandler uiHandler;
    private LSystem lsys;
    public Turtle turtle;

    private int curr_generation = 0;
    private string curr_sentence;
    Rule[] ruleset = new Rule[2];
    private string letter;
    private string prev_letter;
    private int number;
    // have 4 lsystems (2D0L, and 2 extensions)
    // Start is called before the first frame update
    void Start()
    {

        int rule = uiHandler.selectedRule;
        number = Random.Range(1, 10);

        switch (rule)
        {
            case 0:
                // ---- rules i like ---- //
                ruleset[0] = new Rule('F', "FF[+FF+FF+FF+FF+FF]−FF-FF−FF-FF+FF-FF");
                if (number >= 5){
                    ruleset[1] = new Rule('F', "F");
                }
                else{
                    ruleset[1] = new Rule('F', "F-FF+F");
                }
                letter = "F";
                break;  
            case 1:
                ruleset[0] = new Rule('T', "FF[+FF[-FF[+FF[-FF[+FF]]]][-FF[+FF[-FF[+FF[-FF[+FF]]]]]][+FF[+FF[+FF[+FF[+FF]]]][-FF[-FF[-FF[-FF[-FF]]]]");
                if (number >= 5){
                    ruleset[1] = new Rule('F', "F+FF-F");
                }
                else{
                    ruleset[1] = new Rule('F', "F-FF+F");
                }
                letter = "T";
                break;
                // ---- rules i like ---- //
            case 2:
                ruleset[0] = new Rule('X', "F+[[X]-X]-F[-FX]+X");
                if (number >= 5){
                    ruleset[1] = new Rule('F', "FF");
                }
                else{
                    ruleset[1] = new Rule('F', "FF-FF+FF");
                }
                letter = "X";
                break;
            default:
                break;
        }

        lsys = new LSystem(letter, ruleset);
    }

    // Update is called once per frame
    void Update()
    {
        int totalIterations = uiHandler.iterations;
        int currentAngle = (int)uiHandler.angle;
        int rule = uiHandler.selectedRule;
        prev_letter = letter;
        int number = Random.Range(1, 10);

        number = Random.Range(1, 10);

        // the following switch statement makes it possible to switch cases while running the game
        switch (rule)
        {
            case 0:
                // ---- rules i like ---- //
                ruleset[0] = new Rule('F', "FF[+FF+FF+FF+FF+FF]−FF-FF−FF-FF+FF-FF");
                if (number >= 5){
                    ruleset[1] = new Rule('F', "F");
                }
                else{
                    ruleset[1] = new Rule('F', "F-FF+F");
                }
                letter = "F";
                break;  
            case 1:
                ruleset[0] = new Rule('T', "FF[+FF[-FF[+FF[-FF[+FF]]]][-FF[+FF[-FF[+FF[-FF[+FF]]]]]][+FF[+FF[+FF[+FF[+FF]]]][-FF[-FF[-FF[-FF[-FF]]]]");
                if (number >= 5){
                    ruleset[1] = new Rule('F', "F+FF-F");
                }
                else{
                    ruleset[1] = new Rule('F', "F-FF+FF");
                }
                letter = "T";
                break;
                // ---- rules i like ---- //
            case 2:
                ruleset[0] = new Rule('X', "F+[[X]-X]-F[-FX]+X");
                if (number >= 5){
                    ruleset[1] = new Rule('F', "FF");
                }
                else{
                    ruleset[1] = new Rule('F', "FF-FF+FF");
                }
                letter = "X";
                break;
            default:
                break;
        }

        // if our current tree isn't the same ruleset, restart
        if (prev_letter != letter){
            lsys = new LSystem(letter, ruleset);
            prev_letter = letter;
            curr_generation=0;

        }

        // keep building the generations until we reach the number the user inputted
        if (curr_generation != totalIterations){
            lsys.Generate();
            curr_sentence = lsys.GetSentence();
            turtle.Draw(curr_sentence);
            Debug.Log(lsys.GetSentence());
            curr_generation++;
        }

        // if we made too many geneartions, restart so we can build again
        if (curr_generation > totalIterations){
            lsys = new LSystem(letter, ruleset);
            curr_generation=0;
        }
        
    }
    
}
