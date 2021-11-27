using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Author: Jamie Carmichael
/// Details: This script spawns assets after a period of time.
/// </summary>
public class SpawnEnemy : MonoBehaviour
{
    [Tooltip("This is a list of enemies to spawn. To increase the chances of one enemy coming up over other enemies add multiple of that prefab to the list.")]
    [SerializeField] List<GameObject> enemiesToSpawn;
    [Tooltip("This is a list of spawn locations where enemies will spawn.")]
    [SerializeField] List<GameObject> spawnLocations;
    [Tooltip("This is the minimum time between spawns.")]
    [SerializeField] float spawnIntervalMin = 3.0f;
    [Tooltip("This is the maximum time between spawns.")]
    [SerializeField] float spawnIntervalMax = 4.0f;
    [Tooltip("This is the minimum enemies spawned at one time.")]
    [SerializeField] int enemiesSpawnedAtOnceMin = 2;
    [Tooltip("This is the maximum emnemies spawned at one time.")]
    [SerializeField] int enemiesSpawnedAtOnceMax = 4;
    [Tooltip("This field will define when the spawner stops spawning working. Never means it will never stop. After Time means it will stop on the spawning that happens after the Time To Stop Spawning. After Number Of Spawning means it will stop after the Number Of Spawnings TO End On. The On End event will run when this stops the script.")]
    [SerializeField] WhenToStop whenToStop = WhenToStop.Never;
    [Tooltip("This is how long after starting to spawn it will stop spawning if When To Spawn is set to After Time.")]
    [SerializeField] float timeToStopSpawningAfter;
    [Tooltip("This is how many spawnings will happen before stopping spawning if When To Spawn is set to After Number Of Spawnings.")]
    [SerializeField] int numberOfSpawningsToEndOn;
    [Tooltip("This is how long after the condition is met for the end event before the end event is triggered.")]
    [SerializeField] float waitToRunEndEvent = 0.0f;
    [Tooltip("This event is called when the spawning stops due to the When To Stop variable.")]
    [SerializeField] UnityEvent OnEnd;

    private float endTime;

    private int numberOfSpawnings;

    private List<int> placesSpawned;

    private float timeWhenCanSpawn = 0.0f;

    private int numberOfEnemiesToSpawn;

    private int activeEnemies;

    private enum WhenToStop
    {
        Never, AfterTime, AfterNumberOfSpawnings, AfterAllEnemiesDie
    }

    private void OnEnable()
    {
        endTime = Time.time + timeToStopSpawningAfter;
        numberOfSpawnings = 0;
        timeWhenCanSpawn = Time.time;
    }

    void Update()
    {
        if (timeWhenCanSpawn != -1)
        {
            if (Time.time > timeWhenCanSpawn)
            {
                numberOfEnemiesToSpawn = Random.Range(enemiesSpawnedAtOnceMin, enemiesSpawnedAtOnceMax);

                for (int i = 0; i < numberOfEnemiesToSpawn; i++)
                {
                    int enemySpawned = Random.Range(0, enemiesToSpawn.Count);
                    int locationSpawned = Random.Range(0, spawnLocations.Count);
                    if (placesSpawned != null)
                    {
                        locationSpawned = CheckSpawnLocation(locationSpawned);
                        placesSpawned.Add(locationSpawned);
                    }
                    else
                    {
                        placesSpawned = new List<int> { locationSpawned };
                    }

                    GameObject newEnemy = Instantiate(enemiesToSpawn[enemySpawned], spawnLocations[locationSpawned].transform);
                    newEnemy.GetComponent<TakeDamage>().ThisSpawnEnemy = this;
                    timeWhenCanSpawn = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
                    activeEnemies++;
                        
                    if (numberOfEnemiesToSpawn > spawnLocations.Count)
                    {
                        if (i % spawnLocations.Count == 0)
                        {
                            placesSpawned.Clear();
                        }
                    }
                }
                placesSpawned.Clear();
                numberOfSpawnings++;
            }
        }
        switch (whenToStop)
        {
            case WhenToStop.Never:
                break;
            case WhenToStop.AfterTime:
                if (Time.time >= endTime)
                {
                    OnEnd?.Invoke();
                    this.enabled = false;
                }
                break;
            case WhenToStop.AfterNumberOfSpawnings:
                if (numberOfSpawnings >= numberOfSpawningsToEndOn)
                {
                    timeWhenCanSpawn = -1;
                    Invoke("OnEndEvent", waitToRunEndEvent);
                }
                break;
            case WhenToStop.AfterAllEnemiesDie:
                timeWhenCanSpawn = -1;
                if (activeEnemies <= 0)
                {
                    OnEnd?.Invoke();
                    this.enabled = false;
                }
                break;
            default:
                break;
        }
    }

    private int CheckSpawnLocation(int newLocation)
    {
        for (int x = 0; x < placesSpawned.Count; x++)
        {
            if (placesSpawned[x] == newLocation)
            {
                int tempNum = newLocation + 1;
                tempNum = tempNum % spawnLocations.Count;
                newLocation = CheckSpawnLocation(tempNum);
            }
        }
        return newLocation;
    }

    private void OnEndEvent()
    {

        OnEnd?.Invoke();
        this.enabled = false;
    }
    public void ReduceEnemyCount()
    {
        activeEnemies--;
    }
}
