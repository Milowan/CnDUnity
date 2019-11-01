using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;
    public GameObject startMenu;
    public GameObject floor1;
    public GameObject floor2;
    void Awake()
    {
        startMenu.SetActive(true);
        SetInstance();
    }

    void SetInstance()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
    }
}
