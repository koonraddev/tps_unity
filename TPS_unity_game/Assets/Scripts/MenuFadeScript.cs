using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;

public class MenuFadeScript : MonoBehaviour
{
    public GameObject blackScreenObject;

    public Slider loadingSlider;

    public float fadingTime;

    private Image blackImage;
    private Color blackOpaque = Color.black;
    private Color blackTransparent = Color.black;


    void Start()
    {
        blackImage = blackScreenObject.GetComponent<Image>();
        blackTransparent.a = 0f;
        Invoke(nameof(FadeOutBlackScreen), 1f);

    }

    void Update()
    {

    }

    public void FadeOutBlackScreen() //zanikanie
    {
        blackScreenObject.SetActive(true);
        blackImage.DOColor(blackTransparent, fadingTime);
        Invoke(nameof(BlackScreenChangeStatus),fadingTime);
    }

    public void FadeInBlackScreen() //pojawianie
    {
        blackScreenObject.SetActive(true);
        blackImage.DOColor(blackOpaque, fadingTime);
        Invoke(nameof(LoadMainScene), fadingTime);
    }

    public void LoadMainScene()
    {
        StartCoroutine(LoadSceneAsync());
        //loadingSlider.gameObject.SetActive(true);
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            if (blackImage.color == blackOpaque)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
        //while (!operation.isDone)
        //{
        //    float progress = Mathf.Clamp01(operation.progress / 0.9f);
        //    loadingSlider.value = progress;

        //    if (operation.progress >= 0.9f)
        //    {
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            operation.allowSceneActivation = true;
        //        }
        //    }
        //    //yield return new WaitForSeconds(0.1f);
        //    yield return new WaitForEndOfFrame();
        //}

    }

    public void BlackScreenChangeStatus()
    {
        blackScreenObject.SetActive(!blackScreenObject.activeSelf);

    }
}
