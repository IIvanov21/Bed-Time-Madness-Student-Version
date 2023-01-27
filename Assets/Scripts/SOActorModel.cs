using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Create Actor",menuName ="Create Actor")]
public class SOActorModel : ScriptableObject
{
    public string description;

    //Give our actor a name
    public string actorName;

    //Create actor types
    public enum ActorType
    {
        Player, 
        SmallTeddyBear,
        BigTeddyBear,
        BossTeddyBear,
        Bullet,
    }
    public ActorType actorType;

    //Common actor attributes
    public int health;
    public float speed;
    public int hitPower;
    public int score;
    public string colourName;

    public GameObject actor;
    public GameObject actorBullet;

}
