using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public GameObject[] targets;
    public int numberOfTargets;
    public static int score, highScore, round;
    public int mins, secs;
    public Text scoreLabel, timerLabel, roundLabel;
    public TextAsset scoreDoc, highScoreDoc;
    int min, sec;
    float milis;
    GA ga;
    // Start is called before the first frame update
    void Start()
    {
        TargetMover[] tempPop = new TargetMover[numberOfTargets];
        targets = new GameObject[numberOfTargets];
        startGame();
        round = 1;
        for (int i = 0; i < numberOfTargets; i++)
        {
            GameObject newTarget = Instantiate(target);
            targets[i] = newTarget;
            TargetMover mover = newTarget.GetComponent<TargetMover>();
            tempPop[i] = mover;
            mover.gameManager = this.gameObject;
        }

        ga = new GA(tempPop, 0.2f, 0.95f, this);
    }

    // Update is called once per frame
    void Update()
    {
        milis += Time.deltaTime;
        if (milis >= 1)
        {
            if (sec <= 0 && min != 0)
            {
                min--;
                sec = 59;
            }
            else if (sec != 0)
            {
                sec--;
            }
            milis = 0;
            timerLabel.text = "Time: " + min + (sec < 10 ? ":0" : ":") + sec;
        }
        if (sec <= 0 && min <= 0)
        {
            if (score == 0)
            {
                SceneManager.LoadScene("Score Menu");
            } else
            {
                round++;
                roundLabel.text = "Round: " + round;
                ga.createNewPopulation();
                destroyOldTargets();
                createNewTargets();
                startGame();
            }
        }
    }

    public void addScore()
    {
        score++;
        scoreLabel.text = "Score: " + score;
    }

    void startGame()
    {
        milis = 0;
        min = mins;
        sec = secs;
        score = 0;
        timerLabel.text = "Time: " + min + (sec < 10 ? ":0" : ":") + sec;
        scoreLabel.text = "Score: " + score;
    }

    void createNewTargets()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            GameObject newTarget = Instantiate(target);
            targets[i] = newTarget;
            TargetMover mover = newTarget.GetComponent<TargetMover>();
            mover.setNewBehaviour(ga.population[i].behaviour);
            mover.mutations = ga.population[i].mutations;
            mover.gameManager = this.gameObject;
        }
    }

    void destroyOldTargets()
    {
        for (int i = 0; i < numberOfTargets; i++)
        {
            if (targets[i] != null)
            {
                Destroy(targets[i]);
            }
        }
    }
}
