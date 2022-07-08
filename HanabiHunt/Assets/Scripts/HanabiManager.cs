using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HanabiManager : MonoBehaviour
{
    public GameObject[] Fireworks;
    private int currentNumberOfFireworks;
    public GameObject[] Crosses;
    public int Lives;
    public Transform[] GenPoints;
    public float TimeToSpawn;
    public GameObject[] Limits;

    private void Start()
    {
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
            Instantiate(Fireworks[randomFirework], GenPoints[randomPosition].position, Quaternion.identity);
            currentNumberOfFireworks++;
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