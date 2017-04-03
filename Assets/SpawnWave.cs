using UnityEngine;
using System.Collections;
//Script used to spawn waves of enemies in turns

public class SpawnWave : MonoBehaviour {

    public Transform EnemyAI; //The enemy prefab that is to be spawned
    public Transform SpawnPosition;//The spawn point of the AI
    public float NextWaveTimer = 2f; //The time between waves
    private float FirstWaveDelay = 1f;//The time to spawn the first wave
    private int WaveIndex = 0;

    void Update() 
    {
        if (FirstWaveDelay <= 0f) //If timer == 0 then the waves start to spawn
        {
            StartCoroutine(WaveSpawn());
            FirstWaveDelay = NextWaveTimer;
        }

        FirstWaveDelay -= Time.deltaTime;
    }

    IEnumerator WaveSpawn()//iEnumerator allows the code to be paused for a few seconds
    {
        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++) //loops through wave index 
        {
            SpawnAI();
            yield return new WaitForSeconds(0.5f); //pauses for 0.5 seconds to ensure the enemy dont spawn on one another(overlap one another)
        }
    }

    void SpawnAI()
    {
        Instantiate(EnemyAI, SpawnPosition.position, SpawnPosition.rotation);//makes an instance of enemy prefab taht is sued to then spawn ontop the map
    }
}
