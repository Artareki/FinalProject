using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HanabiManager : MonoBehaviour
{
    public GameObject[] Fireworks;
    public int currentNumberOfFireworks = 0;
    public GameObject[] Crosses;

    public Transform[] GenPoints;
    public float TimeToSpawn;
    public int MaxNumberOfFireworks = 2;
    public Fireworks fireworks;

    private void Start()
    {
        fireworks = GetComponent<Fireworks>();
        fireworks.Lives = Crosses.Length;
        StartCoroutine(SpawnFireworks());
    }

    private void Update()
    {
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

    public void LoseLives()
    {
        if (fireworks.Lives == 2)
        {
            Destroy(Crosses[2].gameObject);
        }
        if (fireworks.Lives == 1)
        {
            Destroy(Crosses[1].gameObject);
        }
        if (fireworks.Lives == 0)
        {
            Destroy(Crosses[0].gameObject);
            //GameOver
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