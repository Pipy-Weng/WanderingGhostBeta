using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    public GameObject hintPanel;
    public GameObject instructionPanel;

    public PlayerController playerController;
    
    private FirebaseDataCollect firebaseData;

    private bool isAutoHint = false;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            playerController = playerObject.GetComponent<PlayerController>();
            //log.Debug("playerController is ");
        }

        firebaseData = GameObject.Find("Firebase").GetComponent<FirebaseDataCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (panel.activeInHierarchy) {
                DisablePanel();
            } else
            {
                EnablePanel();
            }

        }
        if(firebaseData.LevelStayTime() >= 80 && !isAutoHint)
        {
            isAutoHint = true;
            EnableHintPanel();
        }
    }

    public void EnablePanel()
    {
        panel.SetActive(true);
        playerController.SetPlayerMovement(false);
    }

    public void DisablePanel()
    {
        panel.SetActive(false);
        playerController.SetPlayerMovement(true);
    }

    public void EnableHintPanel()
    {
        hintPanel.SetActive(true);
    }
    public void DisEnableHintPanel()
    {
        hintPanel.SetActive(false);
    }

    public void EnableInstructionPanel()
    {
        panel.SetActive(false);
        instructionPanel.SetActive(true);
    }

    public void DisableInstructionPanel()
    {
        panel.SetActive(true);
        instructionPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void StartLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void StartLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void StartLevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }
    
    public void StartLevelFour()
    {
        SceneManager.LoadScene("LevelFour");
    }

    public void RestartLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        firebaseData.UsedReset();
    }
}
