using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public Material Brown;
    public Material Green;
    private Material chosenMaterial;
    public UIHandler uiHandler;

    // make a list of gameobjects
    private List<GameObject> objects = new List<GameObject>();
    Stack<(Vector3, Quaternion)> leaves = new Stack<(Vector3, Quaternion)>();

    public Vector3 up = Vector3.up;  
    private int turtleRotation;

    void Start()
    {
        if (uiHandler != null)
            turtleRotation = uiHandler.angle;
        else
            Debug.LogError("UIHandler not assigned in Inspector!");
        chosenMaterial=Brown;
    }
    // a function that gets the turtle's current state (get the Vector3 postion and Quaternion (rotation))
    public (Vector3, Quaternion) TutrleCurrentState(){
        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;
        return (position, rotation);
    }

    // clear the game objects on the screen
    public void Clean(List<GameObject> listOfgO){
        foreach (GameObject gO in listOfgO){
            if (gO != this.gameObject){
                Destroy(gO);
            }
        }
        objects.Clear();

    }

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

        // loop through all letters in word
        for (int i = 0; i < lsys_word.Length; i++)
        {
            // convert letter into char
            char c = lsys_word[i];

            // draw forward instruction
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
            // if '+', rotate to the right (same rotation amount x)
            else if (c == '+')
            {
                transform.Rotate(0f, turtleRotation, 0f);
                transform.position+=transform.forward*0.05f;
            }
            // if '-', rotate to the left (same rotation amount x)
            else if (c == '-')
            {
                transform.Rotate(0f, -turtleRotation, 0f);
                transform.position+=transform.forward*0.05f;
            }
            // if '[', start a new branch, (use a stack push to save the old state for branching)
            else if (c == '[')
            {
                leaves.Push((transform.position, transform.rotation));
                chosenMaterial=Green;
            }
            // if ']', close the branch, (use a stack pop to return to the old state)
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

    }

}
       