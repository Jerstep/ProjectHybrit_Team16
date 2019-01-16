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

    public GameObject startButton , Player1WinsText, Player2WinsText, DrawText;
    private WaveController waveCon;

    public GameObject[] enemysToDestroy;

    // Use this for initialization
    void Start () {
		player1 = GameObject.Find("Player-1").GetComponent<Player>();
        player2 = GameObject.Find("Player-2").GetComponent<Player>();
        waveCon = GameObject.Find("WaveController").GetComponent<WaveController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space"))
        {
            StartGame();
        }
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
            startButton.SetActive(true);
            waveCon.breakLoop = true;
            player1.canShoot = false;
            player2.canShoot = false;
            enemysToDestroy = GameObject.FindGameObjectsWithTag("Enemy");
            for (var i = 0; i < enemysToDestroy.Length; i++)
            {
                Destroy(enemysToDestroy[i]);
            }
                
            if (scoreP1 > scoreP2)
            {
                Player1WinsText.SetActive(true);
            }
            else if (scoreP1 < scoreP2)
            {
                Player2WinsText.SetActive(true);
            }
            else if (scoreP1 == scoreP2)
            {
                DrawText.SetActive(true);
            }
        }
    }

    public void StartGame()
    {
        time = 300;
        scoreP1 = 0;
        scoreP2 = 0;
        player1.playerHealth = 100;
        player2.playerHealth = 100;
        player1.canShoot = true;
        player2.canShoot = true;
        waveCon.canSpawn = true;
        waveCon.breakLoop = false;
        startButton.SetActive(false);
        Player1WinsText.SetActive(false);
        Player2WinsText.SetActive(false);
        DrawText.SetActive(false);
    }

}
