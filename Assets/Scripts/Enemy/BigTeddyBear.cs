using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BigTeddyBear : Enemy
{
    //Patrol variables
    float distanceToPatrolPoint = 0.0f;
    Vector3 startingPos = Vector3.zero;
    bool isSeeking = false;
    bool patrolSwitch = true;

    //Patrol access points
    GameObject[] patrolPoints;//Store multiple patrol point
    GameObject patrolPoint;//Store a reference to a random chosen patrol point

    // Start is called before the first frame update
    void Start()
    {
        //Capture patrol point A
        startingPos = transform.position;

        //Capture all the patrol points in game
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint");

        //Get a reference to patrol point B
        patrolPoint = patrolPoints[Random.Range(0, patrolPoints.Length )];// TODO: Get rid of the minus 1
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.gameState== GameManager.GameStates.Play)
        {
            isSeeking = LookingAtPlayer();

            if (isSeeking) Chase();
            else Patrol();

        }
    }

    public void Patrol()
    {
        if(patrolSwitch)
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, patrolPoint.transform.position);
            agent.destination = patrolPoint.transform.position;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = false;
        }
        else 
        {
            distanceToPatrolPoint = Vector3.Distance(transform.position, startingPos);
            agent.destination = startingPos;
            if (distanceToPatrolPoint < agent.stoppingDistance) patrolSwitch = true;
        }

    }
}
