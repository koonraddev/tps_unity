using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBiomeManager : MonoBehaviour
{
    public string biomeName;
    private UIManager managerUI;

    void Start()
    {
        managerUI = FindObjectOfType<UIManager>();
    }


    private void OnTriggerEnter(Collider enterInfo)
    {
        PlayerMovement player = enterInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            PlayerPrefs.SetString("currentBiome", biomeName);
            managerUI.ChangeBiomeText();
            managerUI.BiomeTextShowUP();
        }
    }
}
