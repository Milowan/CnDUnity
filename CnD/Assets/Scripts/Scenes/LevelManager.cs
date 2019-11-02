using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = null;
    public GameObject startScreen;
    public GameObject floor1;
    void Awake()
    {
        startScreen.SetActive(true);
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
