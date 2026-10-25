using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public Text scoreText;
    public Text multiText;


    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("HIT ON TIME");

        if(currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: X" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
    }

    public void NoteMissed()
    {
    Debug.Log("MISSED");

    currentMultiplier = 1;
    multiplierTracker = 0;

    multiText.text = "Multiplier: X" + currentMultiplier;
    }
}
