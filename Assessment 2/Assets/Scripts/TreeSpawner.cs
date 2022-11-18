using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public float spawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnRate, treePrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
        //GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}