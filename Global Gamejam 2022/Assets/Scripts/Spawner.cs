using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 10f;
    [SerializeField]
    private SideManager thisSideManager;
    [SerializeField]
    private Transform spawnPoint;
    public List<Spawner> enemySpawns = new List<Spawner>();

    private Transform thisLaneTarget;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        if (gameObject.tag == "Light")
        {
            thisSideManager = GameObject.Find("LightManager").GetComponent<SideManager>();
            enemySpawns = SideManager.darkSideSpawns;
        }
        else if (gameObject.tag == "Dark")
        {
            thisSideManager = GameObject.Find("DarkManager").GetComponent<SideManager>();
            enemySpawns = SideManager.lightSideSpawns;
        }

        thisLaneTarget = GetClosestEnemySpawn();
        spawnCoroutine = StartCoroutine(SpawnTroopLoop());
    }

    private Transform GetClosestEnemySpawn()
    {
        // Get closest enemy spawn to send troops towards
        Transform closestEnemySpawn = null;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < enemySpawns.Count; i++)
        {
            Spawner spawn = enemySpawns[i];
            float distance = Vector3.Distance(spawn.transform.position, spawn.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemySpawn = spawn.transform;
            }
        }
        return closestEnemySpawn;
    }

    public void SpawnTroop()
    {
        if (spawnPoint.gameObject.activeInHierarchy && thisLaneTarget.gameObject.activeInHierarchy)
        {
            GameObject newTroop = Instantiate(thisSideManager.GetCurrentTroop(), position: spawnPoint.position, Quaternion.identity);
            // Find enemy base
            if (gameObject.tag == "Dark")
            {
                newTroop.GetComponent<AI>().targetBase = thisLaneTarget.position;
            }
        }
    }

    private IEnumerator SpawnTroopLoop()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnTroop();
        }
    }

    private void OnDestroy()
    {
        if (gameObject.tag == "Light")
        {
            SideManager.lightSideSpawns.Remove(this);
        }
        else if (gameObject.tag == "Dark")
        {
            SideManager.darkSideSpawns.Remove(this);
        }

        if (SideManager.darkSideSpawns.Count == 0)
        {
            // Light wins
            Blackboard.winner = "Light";
            Spawner[] allSpawners = FindObjectsOfType<Spawner>();
            foreach (Spawner spawner in allSpawners)
            {
                spawner.StopAllCoroutines();
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScreen");
        }
        else if (SideManager.lightSideSpawns.Count == 0)
        {
            // Dark wins
            Blackboard.winner = "Dark";
            Spawner[] allSpawners = FindObjectsOfType<Spawner>();
            foreach (Spawner spawner in allSpawners)
            {
                spawner.StopAllCoroutines();
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScreen");
        }
    }
}
