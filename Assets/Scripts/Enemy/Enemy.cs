using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IActorTemplate
{
    [SerializeField]SOActorModel actorModel;

    //Actor values
    float speed;
    int health;
    int hitPower;
    int score;
    GameObject actor;
    SOActorModel.ActorType actorType;
    [SerializeField] protected NavMeshAgent agent;

    //Chase Variable
    private float distanceToPlayer;

    //Facing Variables
    Vector3 directionToPlayer;
    float angle;
    [SerializeField]float minDistanceToPlayer = 2.0f;

    protected GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;
        actor = actorModel.actor;
        actorType = actorModel.actorType;
        bullet = actorModel.actorBullet;
        score = actorModel.score;
    }

    public void Die()
    {
        GameManager.Instance.GetComponent<ScoreManager>().SetScore(score);//<====== Modify after implementing the Score Manager methods
        LevelUI.onScoreUpdate?.Invoke();

        if (actorType==SOActorModel.ActorType.BossTeddyBear)
        {
            GameManager.Instance.GetComponent<ScenesManager>().GameOver();
            //If you wanted a custom sequence this is where you write the code for it.
        }

        Destroy(gameObject);
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health-=incomingDamage;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Bullet"))
        {
            if (health >= 1) health -= collision.gameObject.GetComponent<IActorTemplate>().SendDamage();
            if (health <= 0) Die();
           

        }
    }

    public bool LookingAtPlayer()
    {
        //Calculating if we are facing the player
        directionToPlayer = transform.position - GameManager.playerPosition;
        angle = Vector3.Angle(transform.forward, directionToPlayer);
        //Calculating the distance to the player
        distanceToPlayer=Vector3.Distance(transform.position, GameManager.playerPosition);

        if (distanceToPlayer <= minDistanceToPlayer && FacingPlayer())
        {
            Debug.Log("I can see the player!");

            return true;
        }
        else return false;

    }

    bool FacingPlayer()
    {
        if (Mathf.Abs(angle) > 90.0f && Mathf.Abs(angle) < 270.0f)
        {
            return true;
        }
        else return false;

    }

    public void Chase()
    {
        agent.destination = GameManager.playerPosition;
    }
}
