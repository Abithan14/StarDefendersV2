using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTurrets : MonoBehaviour {

    public TurretBlueprint StandardTurret;
    public TurretBlueprint SpeedTurret;
    public TurretBlueprint ExtremeSpeedTurret;
    public TurretBlueprint MasterTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void Select10mmTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectSpeedTurret()
    {
        Debug.Log("Speed Turret Selected");
        buildManager.SelectTurretToBuild(SpeedTurret);
    }

    public void SelectExtremeSpeedTurret()
    {
        Debug.Log("Extreme Speed Turret Selected");
        buildManager.SelectTurretToBuild(ExtremeSpeedTurret);
    }

    public void SelectMasterTurret()
    {
        Debug.Log("Master Turret Selected");
        buildManager.SelectTurretToBuild(MasterTurret);
    }


    }

