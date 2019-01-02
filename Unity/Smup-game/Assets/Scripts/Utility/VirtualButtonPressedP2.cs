using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonPressedP2 : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject targetObjectPlayer2;

    public GameObject playerObject2;
    public Player playerController;

	// Use this for initialization
	void Start () {
        playerObject2 = GameObject.FindWithTag("Player-2");
        playerController = playerObject2.GetComponent<Player>();

        targetObjectPlayer2.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        playerController.fire = true;
        Debug.Log("pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        playerController.fire = false;
        Debug.Log("Released");
    }
}
