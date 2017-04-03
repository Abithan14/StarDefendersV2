using UnityEngine;

public class Navigate : MonoBehaviour {

    public static Transform[] checkpoints; //Transform is used to allow the use of game objects (Transform Array)

    private void Awake()
    {
        checkpoints = new Transform[transform.childCount]; //The Number of children under 'Navigate'
        for (int i = 0; i < checkpoints.Length; i++) //For loop to count the number of children
        {
            checkpoints[i] = transform.GetChild(i); //iterates through every child in the 'Navigate' game object
        }
    }
}
