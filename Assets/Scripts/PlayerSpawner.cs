using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;
    GameObject playerObject;
    [SerializeField] string selectedPlayerName;

    private void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        //Define the default player
        actorModel = Object.Instantiate(Resources.Load(selectedPlayerName)) as SOActorModel;
        playerObject = GameObject.Instantiate(actorModel.actor);

        //Sets the player's spawner to be the player's parent object
        playerObject.transform.SetParent(transform);
        playerObject.name = actorModel.actorName;

        GameObject startingPosition = GameObject.Find("Starting Position");
        playerObject.transform.position = startingPosition.transform.position;
        playerObject.transform.rotation = startingPosition.transform.rotation;
        playerObject.GetComponent<IActorTemplate>().ActorStats(actorModel);
    }
}
