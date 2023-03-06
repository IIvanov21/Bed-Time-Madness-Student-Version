using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IActorTemplate
{
    float speed;
    int health;
    int hitPower;
    GameObject actor;
    string colourName;

    [SerializeField] SOActorModel actorModel;
    void Awake()
    {
        ActorStats(actorModel);
        ChangeColour();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed=actorModel.speed;
        health=actorModel.health;
        hitPower=actorModel.hitPower;
        actor=actorModel.actor;
        colourName=actorModel.colourName;
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health-=incomingDamage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void ChangeColour()
    {
        if (colourName == "red")
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            if (health >= 1) health -= collision.gameObject.GetComponent<IActorTemplate>().SendDamage();
            if (health <= 0) Die();
        }
    }

    /*void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }*/

    void OnTriggerStay(Collider collider)
    {
        
    }

    void OnTriggerExit(Collider collider)
    {
        
    }
}
