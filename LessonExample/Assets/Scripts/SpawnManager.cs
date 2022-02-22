using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[3];
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] int fireballDelay = 1;
    
    [System.NonSerialized] public bool isFireballPresent = true;
    [System.NonSerialized] public bool isLoadingFireball = false;

    Vector3 startPosition;
    Vector3 windowLimits;

    float startDelay = 2f;
    float repeatRate = 2.5f;

    void Start()
    {
        startPosition = fireballPrefab.transform.position;
        windowLimits = FindWindowLimits();
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CreateNewFireballAfterDelay(fireballDelay));
        }
    }


    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, 3);
        GameObject enemy = Instantiate(enemies[enemyIndex]);
        enemy.transform.position = new Vector3(windowLimits.x + 1, Random.Range(-windowLimits.y, windowLimits.y), 0);
    }

    IEnumerator CreateNewFireballAfterDelay(int seconds)
    {
        if (isFireballPresent || isLoadingFireball)
        {
            yield return null;
        }
        if (!isLoadingFireball)
        {
            isLoadingFireball = true;
            yield return new WaitForSeconds(seconds);
            GameObject fireball = Instantiate(fireballPrefab);
            fireball.transform.position = startPosition;
            isFireballPresent = true;
            isLoadingFireball = false;
        }
        
    }
}
