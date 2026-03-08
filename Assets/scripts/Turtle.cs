using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public Material Brown;
    public Material Green;
    private Material chosenMaterial;
    // private LGeom lgeom;
    public UIHandler uiHandler;

    // make a list of gameobjects
    private List<GameObject> objects = new List<GameObject>();
    Stack<(Vector3, Quaternion)> leaves = new Stack<(Vector3, Quaternion)>();

    // public float turtleRotation;
    public Vector3 up = Vector3.up;  
    private int turtleRotation;

    void Start()
    {
        // FIX: get angle AFTER uiHandler is assigned
        if (uiHandler != null)
            turtleRotation = uiHandler.angle;
        else
            Debug.LogError("UIHandler not assigned in Inspector!");
        chosenMaterial=Brown;

        // turtleRotation = 30;
    }
    // make a function that gets the turtle's current state (get the Vector3 postion and Quaternion (rotation))
    public (Vector3, Quaternion) TutrleCurrentState(){
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        return (position, rotation);
    }

    public void Clean(List<GameObject> listOfgO){
        foreach (GameObject gO in listOfgO){
            if (gO != this.gameObject){
                Destroy(gO);
            }
        }
        objects.Clear();

    }

// /*
    // make a function for drawing (input word)
    public void Draw(string lsys_word){
        // chosenMaterial = Brown;
        turtleRotation = uiHandler.angle;

        // destroy previous drawing
        Clean(objects);

        // set the turtle to 0,0,0
        transform.position = new Vector3(0f,0f,0f);
        
        // set the tutrle direction
        transform.rotation = Quaternion.Euler(0,0,0);

        // set material (brown or green)
        // to do

        // loop through all letters in word
        // for (int i = 0; i < lsys_word.Length; i++){
        //     // convert letter into char
        //     char current_chr = lsys_word[i];
        //         // this part is where ull add color psuedocode
        //     // TutrleCurrentState()
        //     // draw forward instruction
        //     // use the gameobject cylinder function from LGeom.cs
        //     // if 'X' (variable symbol), dont draw
        //     if (current_chr == 'X'){
        //         // continue; 
        //     }
        //     // if '+', rotate to the right (same rotation amount x)
        //     if (current_chr == '+'){
        //         transform.Rotate(0f,turtleRotation,0f);
        //         transform.position+=transform.forward*0.05f;
        //         // continue;
        //     }
        //     // if '-', rotate to the left (same rotation amount x)
        //     if (current_chr == '-'){
        //         transform.Rotate(0f,-turtleRotation,0f);
        //         transform.position+=transform.forward*0.05f;
        //         // continue;
        //     }
        //     // if '[', start a new branch, (use a stack push to save the old state for branching)
        //     if (current_chr == '['){
        //         leaves.Push(TutrleCurrentState());
        //         // continue;
        //     }
        //     // if ']', close the branch, (use a stack pop to return to the old state)
        //     if (current_chr == ']'){
        //         if (leaves.Count > 0)
        //         {
        //             (var pos, var rot) = leaves.Pop();
        //             transform.position = pos;
        //             transform.rotation = rot;
        //         }
        //         // continue;
        //     }
        for (int i = 0; i < lsys_word.Length; i++)
        {
            char c = lsys_word[i];

            if (c == 'F')
            {
                GameObject branch = LGeom.Cylinder(
                    p1: transform.position,
                    radius: 0.05f,
                    length: 0.05f,
                    direction: transform.up,
                    material: chosenMaterial
                );

                objects.Add(branch);

                transform.position += transform.up * 0.05f;
                transform.position += transform.forward * 0.05f;

            }
            else if (c == '+')
            {
                transform.Rotate(0f, turtleRotation, 0f);
                transform.position+=transform.forward*0.05f;
            }
            else if (c == '-')
            {
                transform.Rotate(0f, -turtleRotation, 0f);
                transform.position+=transform.forward*0.05f;
            }
            else if (c == '[')
            {
                leaves.Push((transform.position, transform.rotation));
                chosenMaterial=Green;
            }
            else if (c == ']')
            {
                if (leaves.Count > 0)
                {
                    var (pos, rot) = leaves.Pop();
                    transform.position = pos;
                    transform.rotation = rot;
                    chosenMaterial=Brown;
                }
            }
        }
            // GameObject branch = LGeom.Cylinder(transform.position, 0.2, Brown);
            // GameObject branch = LGeom.Cylinder(p1:transform.position, radius:0.05f, length:0.05f, direction:transform.up, material:Brown);
            // objects.Add(branch);
            // transform.position += transform.up * 0.05f;  // move forward

        // }

    }
// */

/*
    public void Draw(string lsys_word)
    {
        Clean(objects);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        if (uiHandler != null)
            turtleRotation = uiHandler.angle;

        for (int i = 0; i < lsys_word.Length; i++)
        {
            char c = lsys_word[i];

            switch (c)
            {
                case 'F': // move forward and draw
                    GameObject branch = LGeom.Cylinder(
                        p1: transform.position,
                        radius: 0.05f,
                        length: 0.05f,
                        direction: transform.up,
                        material: Brown
                    );
                    objects.Add(branch);

                    // move forward along the turtle’s current orientation
                    transform.position += transform.up * 0.05f;
                    break;

                case '+': // rotate right
                    transform.Rotate(0f, 0f, turtleRotation);
                    break;

                case '-': // rotate left
                    transform.Rotate(0f, 0f, -turtleRotation);
                    break;

                case '[': // push state
                    leaves.Push((transform.position, transform.rotation));
                    break;

                case ']': // pop state
                    if (leaves.Count > 0)
                    {
                        var (pos, rot) = leaves.Pop();
                        transform.position = pos;
                        transform.rotation = rot;
                    }
                    break;

                case 'X': // do nothing
                    break;
            }
        }
    }
*/
}
        // loop through all letters in word
            // convert letter into char
                // this part is where ull add color psuedocode
            // draw forward instruction
            // use the gameobject cylinder function from LGeom.cs
            // if 'X' (variable symbol), dont draw
            // if '+', rotate to the right (same rotation amount x)
            // if '-', rotate to the left (same rotation amount x)
            // if '[', start a new branch, (use a stack push to save the old state for branching)
            // if ']', close the branch, (use a stack pop to return to the old state)
    
    
    
    // Start is called before the first frame update
    // void Start()
    // {
        // ui with angle

        // have martial colours
        
    // }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
// }


