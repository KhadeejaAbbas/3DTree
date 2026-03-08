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
    // have 4 lsystems (2D0L, and 2 extensions)
    // Start is called before the first frame update
    void Start()
    {

        // int currentIterations = uiHandler.iterations;
        // int currentAngle = (int)uiHandler.angle;
        // int rule = uiHandler.selectedRule;
        // Rule[] ruleset = new Rule[2];
        // initalize your 4 Lsystems here
        // ruleset[0] = new Rule('F', "F=F+F--F+F");
        int rule = uiHandler.selectedRule;

        switch (rule)
        {
            case 0:
                // ---- rules i like ---- //
                ruleset[0] = new Rule('F', "FF[+FF+FF+FF+FF+FF]−FF-FF−FF-FF+FF-FF");
                ruleset[1] = new Rule('F', "F");
                letter = "F";
                break;  
            case 1:
                ruleset[0] = new Rule('T', "FF[+FF[-FF[+FF[-FF[+FF]]]][-FF[+FF[-FF[+FF[-FF[+FF]]]]]]");
                ruleset[1] = new Rule('F', "F");
                letter = "T";
                break;
                // ---- rules i like ---- //
            case 2:
                ruleset[0] = new Rule('X', "F+[[X]-X]-F[-FX]+X");
                ruleset[1] = new Rule('F', "FF");
                letter = "X";
                break;
            default:
                break;
        }

        // ruleset[2] = new Rule('A', "F+[[X]-X]-F[-FX]+X), (F → FF)");
        // ruleset[0] = new Rule('X', "F+[[X]-X]-F[-FX]+X");
        // ruleset[1] = new Rule('F', "FF");
        lsys = new LSystem(letter, ruleset);
        // int totalIterations = uiHandler.iterations;
        // int currentAngle = (int)uiHandler.angle;
        // int rule = uiHandler.selectedRule;
        // Debug.Log("HI");

        // // if (curr_generation != totalIterations){
        // for (int i = 0; i < 2; i++){
        //     lsys.Generate();
        //     curr_sentence = lsys.GetSentence();
        //     turtle.Draw(curr_sentence);
        //     Debug.Log(lsys.GetSentence());
        // }

    }

    // Update is called once per frame
    void Update()
    {
        int totalIterations = uiHandler.iterations;
        int currentAngle = (int)uiHandler.angle;
        int rule = uiHandler.selectedRule;
        prev_letter = letter;
        // Debug.Log("HI");
        switch (rule)
        {
            case 0:
                // ---- rules i like ---- //
                ruleset[0] = new Rule('F', "FF[+FF+FF+FF+FF+FF]−FF-FF−FF-FF+FF-FF");
                ruleset[1] = new Rule('F', "F");
                letter = "F";
                break;  
            case 1:
                ruleset[0] = new Rule('T', "FF[+FF[-FF[+FF[-FF[+FF]]]][−FF[+FF[−FF[+FF[-FF[+FF]]]]]]");
                ruleset[1] = new Rule('F', "F");
                letter = "T";
                break;
                // ---- rules i like ---- //
            case 2:
                ruleset[0] = new Rule('X', "F+[[X]-X]-F[-FX]+X");
                ruleset[1] = new Rule('F', "FF");
                letter = "X";
                break;
            default:
                break;
        }

        if (prev_letter != letter){
            lsys = new LSystem(letter, ruleset);
            prev_letter = letter;
            curr_generation=0;

        }

        // if (curr_generation != totalIterations){
        // for (int i = 0; i < 2; i++){
        if (curr_generation != totalIterations){
            lsys.Generate();
            curr_sentence = lsys.GetSentence();
            turtle.Draw(curr_sentence);
            Debug.Log(lsys.GetSentence());
            curr_generation++;
        }
        if (curr_generation > totalIterations){
            lsys = new LSystem(letter, ruleset);
            curr_generation=0;
            // lsys.Generate();
            // curr_sentence = lsys.GetSentence();
            // turtle.Draw(curr_sentence);
            // Debug.Log(lsys.GetSentence());
            // curr_generation++;
        }
        // }
        
        // int totalIterations = uiHandler.iterations;
        // int currentAngle = (int)uiHandler.angle;
        // int rule = uiHandler.selectedRule;
        // // if (curr_generation != totalIterations){
        // for (int i = 0; i < 1; i++){
        //     lsys.Generate();
        //     curr_sentence = lsys.GetSentence();
        //     turtle.Draw(curr_sentence);
        //     Debug.Log(lsys.GetSentence());
        // }
        // if (curr_generation != totalIterations){
        //     lsys.Generate();
        //     curr_sentence = lsys.GetSentence();
        //     turtle.Draw(curr_sentence);
        //     Debug.Log(lsys.GetSentence());
        // }
        // generate Lsystem
        // use turtle to draw 
    }
    // public void Generate()
    // {
        // generate Lsystem
        // use turtle to draw   
    // }
}
