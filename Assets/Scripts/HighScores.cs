using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HighScores : MonoBehaviour
{
    private float score1 = 100f, score2 = 100f, score3 = 100f, score4 = 100f, score5 = 100f;
    private string player1 = "anonymous", player2 = "anonymous", player3 = "anonymous", player4 = "anonymous", player5 = "anonymous";

    public class Result
    {
        public string name;
        public float score;

        public Result(string newName, float newScore)
        {
            name = newName;
            score = newScore;
        }
    }

    private List<Result> scoreList = new List<Result>();

    public Text p1Text, p2Text, p3Text, p4Text, p5Text;
    public Text s1Text, s2Text, s3Text, s4Text, s5Text;

    private RunGame runGame;

    void Start()
    {
        if (PlayerPrefs.HasKey("score1")) 
            score1 = PlayerPrefs.GetFloat("score1");
        if (PlayerPrefs.HasKey("score2"))
            score2 = PlayerPrefs.GetFloat("score2");
        if (PlayerPrefs.HasKey("score3"))
            score3 = PlayerPrefs.GetFloat("score3");
        if (PlayerPrefs.HasKey("score4"))
            score4 = PlayerPrefs.GetFloat("score4");
        if (PlayerPrefs.HasKey("score5"))
            score5 = PlayerPrefs.GetFloat("score5");
        if (PlayerPrefs.HasKey("player1"))
            player1 = PlayerPrefs.GetString("player1");
        if (PlayerPrefs.HasKey("player2"))
            player2 = PlayerPrefs.GetString("player2");
        if (PlayerPrefs.HasKey("player3"))
            player3 = PlayerPrefs.GetString("player3");
        if (PlayerPrefs.HasKey("player4"))
            player4 = PlayerPrefs.GetString("player4");
        if (PlayerPrefs.HasKey("player5"))
            player5 = PlayerPrefs.GetString("player5");
        scoreList.Add(new Result(player1, score1));
        scoreList.Add(new Result(player2, score2));
        scoreList.Add(new Result(player3, score3));
        scoreList.Add(new Result(player4, score4));
        scoreList.Add(new Result(player5, score5));
    }

    private void Update()
    {
        UpdateScreenScores();
    }

    void UpdateScreenScores()
    {
        p1Text.text = player1;
        p2Text.text = player2;
        p3Text.text = player3;
        p4Text.text = player4;
        p5Text.text = player5;

        s1Text.text = score1.ToString();
        s2Text.text = score2.ToString();
        s3Text.text = score3.ToString();
        s4Text.text = score4.ToString();
        s5Text.text = score5.ToString();
    }

    void UpdateScoresValues()
    {
        for(int i = 0; i < 5; i++)
        {
            if (runGame.player1Score < scoreList[i].score)
            {
                scoreList.Insert(0, new Result("new", runGame.player1Score));
                break;
            }
        }

    }
}
