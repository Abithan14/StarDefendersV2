using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpdatePoints : MonoBehaviour {

    public Text PointsDisplayText;
   // public string A;

	// Update is called once per frame
	void Update () {
        //A = Stats.TechTrash.ToString();
        PointsDisplayText.text = Stats.TechTrash.ToString(); 
	}
}
