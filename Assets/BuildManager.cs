using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject StandardTurretPrefab;
    public GameObject SpeedTurretPrefab;
    public GameObject ExtremeSpeedTurretPrefab;
    public GameObject MasterTurretPrefab; 

    private void Awake()
    {
        //TurretChoice = StandardTurretPrefab; - Not In Use
        if (instance != null)
        {
            Debug.LogError("MoreThanOneBuildManager");
        }
        instance = this;
    }


    private TurretBlueprint TurretChoice;//turrettobuild
    
    public bool CanBuild { get { return TurretChoice != null; } }//Creates a property (Only A 'get' only constructor)
                                                                 //if we cannot build, this is used to check if TurretChoice != Null
    public bool HasPoints { get { return Stats.TechTrash >= TurretChoice.cost; } }
    //If user has enough points for selected turret, this will return true. else it will return false

    public void BuildTurretOnNode(PlaceHolder placeholder)
    {
        if (Stats.TechTrash < TurretChoice.cost)
        {
            Debug.Log("Not Enough Tech Trash");
            return;
        }
        Stats.TechTrash -= TurretChoice.cost; //Subtracts turret cost from points

        GameObject turret = (GameObject)Instantiate(TurretChoice.prefab, placeholder.GetBuildPosition(), Quaternion.identity); //Stops rotation - makes an instance of the turret prefab
        placeholder.turret = turret;
        //GameObject TurretChoice = buildManager.BuildTurret(); - Not In Use
        //turret = (GameObject)Instantiate(TurretChoice, transform.position + YPosition, transform.rotation); - Not In Use

        Debug.Log("TechTrash Left:" + Stats.TechTrash);
    }   

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        TurretChoice = turret;
    }

}
