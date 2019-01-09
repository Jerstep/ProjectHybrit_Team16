using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    private Player player1, player2;
    private string player1Wins = "P1Wins";
    private string player2Wins = "P2Wins";
    private string draw = "Draw";
    private float time = 300;

    public Text timeTextRight, timeTextLeft;
    public Text scoreTextP1, scoreTextP2, hpTextP1, hpTextP2;
    public int scoreP1, scoreP2;

    // Use this for initialization
    void Start () {
		player1 = GameObject.Find("Player-1").GetComponent<Player>();
        player2 = GameObject.Find("Player-2").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        string timemin = ((int)time / 60).ToString();

        string timeSeconds = ((int)time % 60).ToString();

        time -= Time.deltaTime;

        timeTextRight.text = timemin + ":" + timeSeconds;
        timeTextLeft.text = timemin + ":" + timeSeconds;
        scoreTextP1.text = scoreP1.ToString();
        scoreTextP2.text = scoreP2.ToString();
        hpTextP1.text = player1.playerHealth.ToString();
        hpTextP2.text = player2.playerHealth.ToString();


        if (time <= 0)
        {
            if(scoreP1 > scoreP2)
            {
                SceneManager.LoadScene(player1Wins);
            }
            else if (scoreP1 < scoreP2)
            {
                SceneManager.LoadScene(player2Wins);
            }
            else if (scoreP1 == scoreP2)
            {
                SceneManager.LoadScene(draw);
            }
        }
    }
}
