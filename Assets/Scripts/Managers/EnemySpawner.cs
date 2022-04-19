using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay;
    public ObjectSpawnRate[] enemies;

    private List<GameObject> enemyList;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        Vector3 newPos = transform.position;
        newPos.x = Random.Range(-7.5f, 7.5f);

        enemyList.Add(Instantiate(getEnemy(), newPos, transform.rotation));
    }

    public void clearEnemies()
    {
        foreach(GameObject go in enemyList)
        {
            Destroy(go);
        }
        enemyList.Clear();
    }

    private GameObject getEnemy()
    {
        int limit = 0;

        foreach (ObjectSpawnRate osr in enemies)
        {
            limit += osr.rate;
        }

        int random = Random.Range(0, limit);

        foreach (ObjectSpawnRate osr in enemies)
        {
            if (random < osr.rate)
            {
                return osr.prefab;
            }
            else
            {
                random -= osr.rate;
            }
        }
        return null;
    }

    private IEnumerator spawner()
    {
        while (true)
        {
            if (GameManager.GetInstance().isPlaying)
            {
                spawn();
                yield return new WaitForSeconds(delay);
            }
            else
            {
                yield return null;
            }
        }
    }
}
