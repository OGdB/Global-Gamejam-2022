using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 10f;
    private GameObject currentTroop;
    [SerializeField]
    private SideManager thisSideManager;
    [SerializeField] 
    private Transform spawnPoint;
    [SerializeField]
    private Transform[] enemySpawns;
    private Transform thisLaneTarget;

    private Coroutine spawnCoroutine;

    private void Awake()
    {
        thisLaneTarget = GetClosestEnemySpawn();
        spawnCoroutine = StartCoroutine(SpawnTroopLoop());
    }

    private Transform GetClosestEnemySpawn()
    {
        // Get closest enemy spawn to send troops towards
        Transform closestEnemySpawn = null;
        float closestDistance = Mathf.Infinity;
        foreach (var spawn in enemySpawns)
        {
            float distance = Vector3.Distance(spawn.position, spawn.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemySpawn = spawn;
            }
        }
        return closestEnemySpawn;
    }

    public void SpawnTroop()
    {
        if (spawnPoint.gameObject.activeInHierarchy && thisLaneTarget.gameObject.activeInHierarchy)
        {
            GameObject newTroop = Instantiate(currentTroop, position: spawnPoint.position, Quaternion.identity);
            // Find enemy base
            if (gameObject.tag == "Dark")
            {
                newTroop.GetComponent<AI>().targetBase = thisLaneTarget.position;
            }
        }
        else
        {
            if (!spawnPoint.gameObject.activeInHierarchy) // if this spawnpoint was destroyed
            {
                Blackboard.loser = thisTag;
                if (thisTag == "Light")
                {
                    Blackboard.winner = "Dark";
                }
                else if (thisTag == "Dark")
                {
                    Blackboard.winner = "Light";
                }
            }

            StopCoroutine(spawnCoroutine);

            // GAME OVER SCREEN
            loseScreen.SetActive(true);

        }
    }

    public void OnGameOver()
    {
        StopCoroutine(spawnCoroutine);
    }

    private IEnumerator SpawnTroopLoop()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnTroop();

        }
}
