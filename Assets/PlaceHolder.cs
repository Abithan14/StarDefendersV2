using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolder : MonoBehaviour {

    BuildManager buildManager;

    public GameObject turret;
    public Color Rollover;
    public Color NoPointsColour;
    private Renderer Rend;
    public Material StartMaterial;
    public Vector3 YPosition;



    void Start()
    {
         
        Rend = GetComponent < Renderer > ();
        StartMaterial = Rend.material;

        buildManager = BuildManager.instance;

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + YPosition;
    }

    private void OnMouseEnter()
    {
       // if (EventSystem.current.ispointeroverGameObject())
         //   return;

        if (!buildManager.CanBuild)
            return;
        
        if (buildManager.HasPoints)//If boolean for has points is true then the rollover colour is applied to the placeholders when hovered over
        {
            Rend.material.color = Rollover;    
        }
        else
        {
            Rend.material.color = NoPointsColour;
        }

    }

    private void OnMouseExit()
    {
        Rend.material = StartMaterial; 
    }

    private void OnMouseDown()
    {
        if(!buildManager.CanBuild) //if user is unable to build...
            return;
        

        if (turret != null)
        {
            Debug.Log("Can't Build");
            return;
        }
        buildManager.BuildTurretOnNode(this);
    }

}
