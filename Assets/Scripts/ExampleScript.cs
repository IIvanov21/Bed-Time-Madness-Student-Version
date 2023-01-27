using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    /*
     * Start vs Awake
     * 1. They both function the same way and the code inside them gets ran only when the application starts.
     * 2. The code in Awake will always get executed before the code in the Start method.
     * 3. The code inside Awake will get executed even if the component is disabled.
     * 4. The code inside Start will get executed only when the component gets enabled.
     */


    private void Awake() //#1
    {
        Debug.Log("This is a call from the Awake method!");
    }

    // Start is called before the first frame update
    void Start()//#3
    {
        Debug.Log("This is a call from the Start method!");
    }

    // Update is called once per frame
    void Update()//#4
    {
        //Insert all the code that needs to run continously
    }

    void LateUpdate()//#5
    {
        //Insert all the code that relies on the code inside Update function to get updated.
    }

    void FixedUpdate()// order is based on the fixed frame time specified.
    {
        //Use it to calculate physics accuratly with fixed frame time.
    }

    void OnEnable()//#2
    {
        //It runs code when the object gets enabled.
        Debug.Log("This is a call from the OnEnable method!");
    }

    void OnDisable()
    {
        //It runs code when the object gets disabled.

    }

    void OnDestroy()
    {
        
    }
}

