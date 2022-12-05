using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScene : MonoBehaviour
{
    public GameObject doorsTrigger;

    public GameObject mainCamera;
    public Transform startCameraPos;
    public Transform endCameraPos;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public Transform leftDoorPosClose;
    public Transform rightDoorPosClose;


    public GameObject blackScreenObject;
    public GameObject playerObject;

    public float fadingTime;
    public float speed;

    private Image blackImage;
    private Color blackOpaque = Color.black;
    private Color blackTransparent = Color.black;

    public TMP_Text distanceText;
    public TMP_Text numberObjectText;
    public TMP_Text biomeText;

    public GameObject statusMenu;

    
    void Start()
    {
        blackImage = blackScreenObject.GetComponent<Image>();
        blackTransparent.a = 0f;
        Invoke(nameof(FadeOutBlackScreen), 1f);
        Invoke(nameof(MovePlayer), 1.3f);
        mainCamera.transform.position = startCameraPos.position;
        mainCamera.transform.rotation = startCameraPos.rotation;
        PlayerPrefs.SetInt("playerDead", 1);
        PlayerPrefs.SetInt("runON", 0);
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (playerObject.transform.position.z >= doorsTrigger.transform.position.z)
        {
            leftDoor.transform.rotation = Quaternion.Slerp(leftDoor.transform.rotation, leftDoorPosClose.rotation, step);
            rightDoor.transform.rotation = Quaternion.Slerp(rightDoor.transform.rotation, rightDoorPosClose.rotation, step);
        }

        if (leftDoor.transform.rotation.eulerAngles.y < 95f)
        {
            mainCamera.transform.SetPositionAndRotation(Vector3.MoveTowards(mainCamera.transform.position, endCameraPos.position,step), Quaternion.Slerp(mainCamera.transform.rotation, endCameraPos.rotation, step / 2));

        }

        if (mainCamera.transform.position == endCameraPos.position)
        {
            ActiveStatusMenu();
        }
    }

    public void MainMenuButton()
    {
        FadeInBlackScreen();
        Invoke(nameof(LoadMainScene), fadingTime);
        PlayerPrefs.SetInt("playAgain", 0);
    }
    
    public void PlayAgainButton()
    {
        FadeInBlackScreen();
        Invoke(nameof(LoadMainScene), fadingTime);
        PlayerPrefs.SetInt("playAgain", 1);
    }
    public void FadeOutBlackScreen() //zanikanie
    {

        blackScreenObject.SetActive(true);
        blackImage.DOColor(blackTransparent, fadingTime);
        Invoke(nameof(BlackScreenChangeStatus), fadingTime);


    }

    public void ActiveStatusMenu()
    {
        statusMenu.SetActive(true);
        distanceText.text = PlayerPrefs.GetInt("distanceTraveled").ToString() + " m";
        numberObjectText.text = PlayerPrefs.GetInt("numberObject").ToString();
        biomeText.text = PlayerPrefs.GetString("currentBiome");
    }

    public void FadeInBlackScreen() //pojawianie
    {
        blackScreenObject.SetActive(true);
        blackImage.DOColor(blackOpaque, fadingTime);
    }

    public void BlackScreenChangeStatus()
    {
        blackScreenObject.SetActive(!blackScreenObject.activeSelf);

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
    }

    public void MovePlayer()
    {
        playerObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 200, 1000));
    }

}
