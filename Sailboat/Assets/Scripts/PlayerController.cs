using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController control;

    bool jibSheetIn;
    bool jibSheetOut;
    bool mainSheetIn;
    bool mainSheetOut;
    [Range(-1f,1f)]
    public float tillerInput;
    public BoatScript boatScript;

    // Awake and check if control is created
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }

        else if (control != this)
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Check for button downs
        jibSheetIn = Input.GetButton("Headsail In");
        jibSheetOut = Input.GetButton("Headsail Out");
        mainSheetIn = Input.GetButton("Mainsail In");
        mainSheetOut = Input.GetButton("Mainsail Out");
        tillerInput = Input.GetAxis("Horizontal");

        // Jib Sheet In
        if (jibSheetIn)
        {
            Debug.Log("Headsail In Button Pressed");

            // Call boat API 
            boatScript.jibSheetIn();

        }

        // Jib Sheet Out
        if (jibSheetOut)
        {
            Debug.Log("Headsail Out Button Pressed");

            // Call boat API 
            boatScript.jibSheetOut();
        }

        // Main Sheet In
        if (mainSheetIn)
        {
            Debug.Log("Mainsail In Button Pressed");

            // Call boat API 
            boatScript.mainSheetIn();
        }

        // Main Sheet Out
        if (mainSheetOut)
        {
            Debug.Log("Mainsail Out Button Pressed");

            // Call boat API 
            boatScript.mainSheetOut();
        }

        // Send tiller state to boat API
        boatScript.setTiller(tillerInput);
    }
}
