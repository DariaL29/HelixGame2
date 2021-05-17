using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    public bool levelCompleted;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public int currentLevel;
    public Slider gameProgressSlider;

    public int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI NextLevelText;
    public int numberOfPassedRings;
    public int progress;

    // Start is called before the first frame update
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex",1);
    }




    void Start()
    {
     
        numberOfPassedRings = 0;
        Time.timeScale = 1;

      //  gameOver = levelCompleted = false;
       
    }

    // Update is called once per frame
    void Update()
    {
   


        currentLevelText.text = currentLevelIndex.ToString();
        NextLevelText.text = (currentLevelIndex+1).ToString();

        progress = numberOfPassedRings * 100 / FindObjectOfType<Manager>().numberRings;
        gameProgressSlider.value = progress;

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(0);
                currentLevelIndex = 0;
              currentLevelText.text = currentLevelIndex.ToString();
              currentLevel = 0;
            }
        }
        if(levelCompleted == true)
        {
            levelCompletedPanel.SetActive(true);
            Time.timeScale = 0;
            

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
                SceneManager.LoadScene(0);
            }
        }
    }
}
