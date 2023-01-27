using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    //Bullet properties
    [SerializeField]private GameObject shootingPoint;
    [SerializeField]private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        /*Input.GetKey(KeyCode.);//Checking if the button/key is being pressed and held down
        Input.GetKeyUp();//Checks if the button/key is being released after being pressed down
        Input.GetKeyDown();//Checks if the button/key is being pressed down

        Input.GetButton();
        Input.GetButtonUp();
        Input.GetButtonDown();*/

        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
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
}
