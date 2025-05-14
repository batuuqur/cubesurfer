using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class cubeMechanic : MonoBehaviour
{
    //public GameObject[] cubes;
    public AudioSource m_ExplodeAudio;
    public AudioSource m_GameOverAudio;
    public GameObject slayer;
    public CameraFollow smartCamera;
    public playerMovement PlayerMovement;
    public ObstacleBehaviour[] ObstacleBehaviour;
    public RotatingObstacle[] RotatingObstacle;
    private cubeMechanic CubeMechanic;
    public MovingEnemySoldier[] MovingSoldier;
    public bool isFinished;
    public bool onTheLine;
    public UIManager uiManager;
    private int score = 0;

    private void Awake()
    {
        // "this"
        CubeMechanic = GetComponent<cubeMechanic>();
    }

    private void Update()
    {
        if (!isFinished)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition =
                    (new Vector3(0, i, 0) + transform.GetChild(i).localPosition * 9) / 10;
                //cubes += 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Collectible"))
        {
            
            other.gameObject.transform.parent = slayer.transform; //Bu parentın child ile gitmesini sağlıyor.
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.tag = "AfterCollection";
            other.gameObject.transform.SetSiblingIndex(0);
            smartCamera.offset.y += 0.5f;
        }
    }

    private void ExplodingVoice()
    {
        m_ExplodeAudio.Play();
    }

    private void GameOverMusic()
    {
        m_GameOverAudio.Play();
    }

    //Sıkıntı yaşamamak için chilCountuda ayarladık(out of bounds)
    public void Remove(int height)
    {
        for (int i = 0; i < height && transform.childCount > 0; i++)
        {
            transform.GetChild(0).parent = null;
            if (isFinished)
            {
                score++;
                Debug.Log(score);
            }
            //ifIsfinished int saydır.
            //Destroy();
        }

        smartCamera.offset.y -= height * 0.5f;

        if (isFinished)
        {
            uiManager.NextLevel();
        }

        if (transform.childCount <= 0)
        {
            //var gameOver=gameObject.GetComponent<UIManager>();
            if (onTheLine)
            {
                Debug.Log("Game Over");
                var playerMovement = gameObject.GetComponent<playerMovement>();
                playerMovement.Explode();
                ExplodingVoice();
                uiManager.Fail();
                StartCoroutine(playerDestroyerSound());
            }

            IEnumerator playerDestroyerSound()
            {
                yield return new WaitForSeconds(2.7f);
                GameOverMusic();
            }

            smartCamera.enabled = false;
            PlayerMovement.enabled = false;
            //MovingEnemy.enabled = false;You need to close soldiers movement
            foreach (var obs in ObstacleBehaviour)
            {
                obs.enabled = false;
            }

            foreach (var ro in RotatingObstacle)
            {
                ro.enabled = false;
            }

            foreach (var mes in MovingSoldier)
            {
                mes.enabled = false;
            }

            CubeMechanic.enabled = false;
        }
    }
}