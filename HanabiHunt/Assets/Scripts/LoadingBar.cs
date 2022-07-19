using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Image LoadingImage;
    public float FillTime = 10;
    private float elapsedTime;

    private void Start()
    {
        LoadingImage.fillAmount = 1;
    }

    public void Restart()
    {
        elapsedTime = 0;
    }

    private void Update()
    {
        if (elapsedTime < FillTime)
        {
            elapsedTime += Time.deltaTime;
            LoadingImage.fillAmount = Mathf.Lerp(1, 0, elapsedTime / FillTime);
        }
        if (LoadingImage.fillAmount == 0)
        {
            HanabiManager.Instance.GameOverScreen();
        }
    }
}