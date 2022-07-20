using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HanabiManager : MonoBehaviour
{
    public static HanabiManager Instance;

    public GameObject[] Fireworks;
    [SerializeField] private int Lives;
    public GameObject[] Crosses;
    public Transform[] GenPoints;
    [SerializeField] private float TimeToSpawn;
    private Collider2D MyCollider;
    [SerializeField] private Text ScoreText, TotalShotsText, HitShotsText, GameOverScore, GameOverTotalShots, GameOverHitShots, GameOverMaxScore, HighScoreText;
    [SerializeField] private int TotalScore, TotalShots, HitShots;
    public Fireworks fireworks;
    [SerializeField] private GameObject GameOver;
    private string highScoreId = "High Score";

    private void Start()
    {
        Instance = this;
        fireworks = GetComponent<Fireworks>();
        Lives = Crosses.Length;
        StartCoroutine(SpawnFireworks());
        HighScoreText.text = PlayerPrefs.GetInt(highScoreId).ToString();

        for (int i = 0; i < Fireworks.Length; i++)
        {
            Fireworks[i].gameObject.SetActive(true);
        }

        int randomPosition = Random.Range(0, GenPoints.Length);
        int randomFirework = Random.Range(0, Fireworks.Length);
        Instantiate(Fireworks[randomFirework], GenPoints[randomPosition].position, GenPoints[randomPosition].rotation = Quaternion.Euler(Random.Range(0, 0), Random.Range(0, 0), Random.Range(-90, 90)));
    }

    private void Update()
    {
        OnMouseDown();
    }

    public void AddScore()
    {
        TotalScore += 10;

        ScoreText.text = TotalScore.ToString("000");
    }

    public void Shots()
    {
        HitShots++;
        HitShotsText.text = HitShots.ToString("0");
    }

    private void OnMouseDown()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.timeScale == 1)
            {
                TotalShots++;
                TotalShotsText.text = TotalShots.ToString("/0");
            }
        }
    }

    public IEnumerator SpawnFireworks()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToSpawn);
            int randomPosition = Random.Range(0, GenPoints.Length);
            int randomFirework = Random.Range(0, Fireworks.Length);

            Instantiate(Fireworks[randomFirework], GenPoints[randomPosition].position, GenPoints[randomPosition].rotation = Quaternion.Euler(Random.Range(0, 0), Random.Range(0, 0), Random.Range(-90, 90)));
        }
    }

    public void GameOverScreen()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
        DestroyObjects();
        StopAllCoroutines();
        CheckHighScore();
        GameOverScore.text = TotalScore.ToString("000");
        GameOverHitShots.text = HitShots.ToString("0");
        GameOverTotalShots.text = TotalShots.ToString("/0");
        GameOverMaxScore.text = HighScoreText.text;
    }

    public void CheckHighScore()
    {
        int CurrentHighScore = PlayerPrefs.GetInt(highScoreId);
        if (CurrentHighScore < TotalScore)
        {
            PlayerPrefs.SetInt(highScoreId, TotalScore);
        }
    }

    public void LivesLost()
    {
        Lives -= 1;

        if (Lives == 2)
        {
            Destroy(Crosses[0].gameObject);
        }
        else if (Lives == 1)
        {
            Destroy(Crosses[1].gameObject);
        }
        else if (Lives == 0)
        {
            Destroy(Crosses[2].gameObject);

            GameOverScreen();
        }
    }

    public void DestroyObjects()
    {
        for (int i = 0; i < Fireworks.Length; i++)
        {
            Fireworks[i].gameObject.SetActive(false);
        }
    }
}