using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreTextP1, scoreTextP2;

    public int scoreP1, scoreP2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreTextP1.text = scoreP1.ToString();
	}
}
