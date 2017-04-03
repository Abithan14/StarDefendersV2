using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script used to help make enemy move through the waypoint/route
//Script is used to calculate the number of waypoints and order them for use
public class Waypoint : MonoBehaviour
{
    public static Transform[] checkpoints; //Allows to be called without reference
                                           //A transform array, used for game objects within a scene
    void awake ()
    {
        checkpoints = new Transform[transform.childCount]; //Gets number of children under navigate Scene
        for (int i = 0; i < checkpoints.Length; i++) //i is used to count the number of children via a loop
            checkpoints[i] = transform.GetChild(i); //stores the value of i in the checkpoints array

    }



}