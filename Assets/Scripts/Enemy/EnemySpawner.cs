using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //The template that defines our enemy actor
    [SerializeField] SOActorModel actorModel;
    
    [Tooltip("Spawn 1 enemy every few seconds.")]
    [SerializeField]float spawnRate;
    
    [Tooltip("Number of enemies this spawner will spawn. The min is 1 and the max is 10.")]
    [SerializeField, Range(1,10)]int enemyNumber;
    
    GameObject enemies;

    private void Awake()
    {
        enemies = GameObject.Find("_Enemies");
        StartCoroutine(SpawnEnemies());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject CreateEnemy()
    {
        GameObject enemy = GameObject.Instantiate(actorModel.actor,transform.position,transform.rotation);
        enemy.GetComponent<IActorTemplate>().ActorStats(actorModel);
        enemy.name=actorModel.name;

        return enemy;
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            GameObject enemyObject=CreateEnemy();
            enemyObject.transform.SetParent(this.transform);
            //enemyObject.transform.position = transform.position;

            yield return new WaitForSeconds(spawnRate);
        }

        yield return null;
    }
}
