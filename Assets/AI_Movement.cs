using UnityEngine;

public class AI_Movement : MonoBehaviour {

    public float speed = 10f; //Public spped variable used to determine speed of enemy AI

    private Transform target;
    private int wavepointindex = 0;

    private void Start()
    {
        target = Navigate.checkpoints[0]; //Referencing the Navigate Class/script
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position; //3 driectional vector (X,Y,Z), subtracts two vectors to get the directional vector 
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        //Trsnlates moves the transform with the given directional vector
        //Direction is normalized to ensure that the speed is always the same as the given speed variable
        //Time.delta ensure speed of movement is not determined by the frame rate of the PC
     
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)//Switches to next waypoint when within a very close distance within its target
        {
            GetNextCheckPoint();
        }
    }

    private void GetNextCheckPoint()
    {
        if (wavepointindex >= Navigate.checkpoints.Length - 1) //If wavepoint index is equal to total amount of checkpoints, then EnemyAI object is destroyed
        {
            Destroy(gameObject);
            return; //Destroy Gameobject function takes some time to destroy the object, so return is used to ensure the code dont run ahead
        }

        wavepointindex++;//Adds one to the wavepoint index
        target = Navigate.checkpoints[wavepointindex]; //Takes the wavepointindex value and makes it as new target
    }
    
}
