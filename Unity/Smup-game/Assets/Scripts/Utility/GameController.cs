using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject player1, player2;

	// Use this for initialization
	void Awake ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player-1");
        player2 = GameObject.FindGameObjectWithTag("Player-2");        
    }

    // Update is called once per frame
    void Update ()
    {
		if(player1.GetComponent<Player>().imActive == false)
        {
            StartCoroutine(TurnOnP1());
        }

        if (player2.GetComponent<Player>().imActive == false)
        {
            StartCoroutine(TurnOnP2());
        }
    }

    IEnumerator TurnOnP1()
    {
        yield return new WaitForSeconds(3);
        player1.SetActive(true);
        player1.GetComponent<Player>().imActive = true;
        player1.GetComponent<Player>().playerHealth = 100;
    }

    IEnumerator TurnOnP2()
    {
        yield return new WaitForSeconds(3);
        player2.SetActive(true);
        player2.GetComponent<Player>().imActive = true;
        player2.GetComponent<Player>().playerHealth = 100;
    }
}
