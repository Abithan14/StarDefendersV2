using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public static int TechTrash;
    public int StartTechTrash = 5000;

    private void Start()
    {
        TechTrash = StartTechTrash;
    }
}