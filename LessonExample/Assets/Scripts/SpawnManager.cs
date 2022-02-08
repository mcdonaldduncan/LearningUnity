using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[3];
    [SerializeField] GameObject fireballPrefab;
    [SerializeField] int fireballDelay = 1;
    
    [System.NonSerialized] public Vector3 windowLimits;
    [System.NonSerialized] public bool isFireballPresent = true;
    [System.NonSerialized] public bool isLoadingFireball = false;

    Vector3 startPosition = new Vector3(-6, -1, 0);

    float startDelay = 2f;
    float repeatRate = 2.5f;

    void Start()
    {
        FindWindowLimits();
        InvokeRepeating("SpawnEnemy", startDelay, repeatRate);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(CreateNewFireballAfterDelay(fireballDelay));
        }
    }

    void FindWindowLimits()
    {
        Camera.main.transform.position = new Vector3(0, 0, -10);
        windowLimits = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemies[0]);
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
