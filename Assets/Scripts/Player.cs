using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IActorTemplate
{
    float speed;
    int health;
    int hitPower;
    GameObject actor;
    GameObject bullet;
    
    Rigidbody rb;
    //Jump values
    [SerializeField]float jumpForce = 1000.0f;
    [SerializeField]float drawDistance = 2.0f;
    [SerializeField] bool isJump=true;
    //Bullet properties
    [SerializeField]private GameObject shootingPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameStates.Play)
        {
            Move();

            /*Input.GetKey(KeyCode.);//Checking if the button/key is being pressed and held down
            Input.GetKeyUp();//Checks if the button/key is being released after being pressed down
            Input.GetKeyDown();//Checks if the button/key is being pressed down

            Input.GetButton();
            Input.GetButtonUp();
            Input.GetButtonDown();*/

            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isJump)
            {
                Jump();
            }


        }
    }

    void FixedUpdate()
    {
        //Vector3 fwd = transform.TransformDirection(Vector3.forward);//Direction of the ray
        Vector3 down = transform.TransformDirection(Vector3.down);//Direction of the ray
        Debug.DrawRay(transform.position, down * drawDistance, Color.red);//Only a visual gizmo to see what the ray is hitting
        RaycastHit hit;//To store information for the object that is being currently hit by our ray

        LayerMask layerMask = LayerMask.GetMask("Environment");
        //int layerMask = 0<<7;
        if (Physics.Raycast(transform.position, down,out hit, drawDistance,layerMask))
        {
            Debug.Log("We have hit: " + hit.collider.name);
            Debug.DrawRay(transform.position, down * hit.distance, Color.green);
            isJump = true;
        }

    }

    void Move()
    {
        /* 
         * horizontal (-1 - 0) we are moving left A
         * horizontal (0 - 1) we are moving right D
         * vertical ( -1 - 0 ) we are moving backwards S
         * vertical (0 - 1) we are moving forwards W
         */
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");


        /*
         * There are multiple ways you can move in Unity:
         * 1. Add a Character controller to your Player and use the intergrated Move() function
         * 2. Rigid Body also have an integrated Move function
         * 3. Transform component provides a Translate function which just simply adds your movement calculation
         * to the Position value
         */

        //Left Right moving
        transform.Translate(horizontal*speed*Vector3.right*Time.deltaTime);

        

        //Forwards Backwards
        transform.Translate(vertical * speed * Vector3.forward * Time.deltaTime);

       

    }

    void Attack()
    {
        Instantiate(bullet, shootingPoint.transform.position,shootingPoint.transform.rotation);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        speed = actorModel.speed;
        health = actorModel.health;
        hitPower = actorModel.hitPower;

        actor = actorModel.actor;
        bullet = actorModel.actorBullet;
    }

    public int SendDamage()
    {
        return hitPower;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Jump()
    {
        Vector3 force=Vector3.up*jumpForce;
        rb.AddForce(force, ForceMode.Impulse);
        isJump = false;
    }
}
