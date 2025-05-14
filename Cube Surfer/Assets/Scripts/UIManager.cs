using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject nextlevel;
    public GameObject RetryButton;
    public GameObject playButtonDestroy;
    public Animator UiAnimator;
    public GameObject[] levelObjects;
    public Text levelText;
    public int levelCount;
    public int currentLevel;
    public GameObject player;

    private void Start()
    {
        levelCount = levelObjects.Length;
        currentLevel = PlayerPrefs.GetInt("Level");
        levelText.text = "Level " + (currentLevel + 1);
        currentLevel %= levelCount;
        levelObjects[currentLevel].SetActive(true);
        levelText.enabled = true;
    }
#if UNITY_EDITOR
    [MenuItem("PlayerPrefs/Clear")]
    private static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        playButtonDestroy.SetActive(false);
        Debug.Log(playButtonDestroy.name);
        nextlevel.SetActive(true);
        UiAnimator.SetTrigger("NLB");
    }

    public void NextLevelStarted()
    {
        //playButtonDestroy.SetActive(true);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1 );
        levelObjects[currentLevel].SetActive(false);
        currentLevel++;
        levelObjects[currentLevel].SetActive(true);
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void GameStart()
    {
        player.GetComponent<playerMovement>().enabled = true;
        levelText.enabled = false;
        UiAnimator.SetTrigger("PB");
        //levelObjects[currentLevel].SetActive(true);
        //Application.targetFrameRate = 60;
        //levelObjects[currentLevel].SetActive(true);
        //Application.LoadLevel(0);
        //SceneManager.LoadScene("Level1");
        //SceneManager yerine resources loadda kullanılabilir.
    }

    public void Fail()
    {
        playButtonDestroy.SetActive(false);
        RetryButton.SetActive(true);
        UiAnimator.SetTrigger("RB");
        //player.transform.position(0, 0, 0);
        //levelObjects[currentLevel].SetActive(true);
        //levelObjects[currentLevel].SetActive(false);
        //levelObjects[currentLevel].SetActive(true);
        //Application.LoadLevel(0);
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
