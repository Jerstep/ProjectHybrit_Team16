using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonPressed : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject targetObjectPlayer1;

    public GameObject playerObject1;
    public Player playerController;

	// Use this for initialization
	void Start () {
        playerObject1 = GameObject.FindWithTag("Player-1");
        playerController = playerObject1.GetComponent<Player>();

        targetObjectPlayer1.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
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
