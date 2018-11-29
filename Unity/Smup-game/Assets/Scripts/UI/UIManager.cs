using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Player player1, player2;

    public Text scoreTextP1, scoreTextP2, hpTextP1, hpTextP2;
    public int scoreP1, scoreP2;

    // Use this for initialization
    void Start () {
		player1 = GameObject.Find("Player-1").GetComponent<Player>();
        player2 = GameObject.Find("Player-2").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        scoreTextP1.text = scoreP1.ToString();
        scoreTextP2.text = scoreP2.ToString();
        hpTextP1.text = player1.hp.ToString();
        hpTextP2.text = player2.hp.ToString();
    }
}
