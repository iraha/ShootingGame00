using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect: MonoBehaviour
{

    public Button[] levelButtons;

    // Loading関連
    [SerializeField] private Text loadingText;
    public GameObject LoadingUI;



    // Start is called before the first frame update
    void Start()
    {

        LoadingUI.SetActive(false);

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }

        PlayerPrefs.DeleteAll();
        //PlayerPrefs.Save();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
        //fader.FadeTo(levelName);
        LoadingUI.SetActive(true);
    }



}






