using UnityEngine;
//Script is used to make the AI move from checpoint to checpoint on screen
public class AI : MonoBehaviour {

    public float speed = 15f; //The movement speed of the AI

    private Transform target;
    private int wavepointindex = 0;//Used to store the current wavepoint index

    void Start()
    {
        target = Waypoint.checkpoints[0]; //Sets the new target as the next stored checkpoint from the Waypoint script
    }

     void Update()
    {
        Vector3 direction = target.position - transform.position;//The direction the enmy has to go in order to get to the next checkpoint
        //direction vector is gotten by target.position - transform.position
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); 
        //Used to move with the direction vector - Translate. Translate moves the transform in the direction and distance of translation
    } 

}
