using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public int movementSpeed;
    private Rigidbody playerRigidbody;
    public int velocity;
    public GameObject explosionEffect;
    public GameObject playerCube;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(0, 0, horizontal * movementSpeed * Time.deltaTime);
        transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
        transform.position = new Vector3(transform.position.x, transform.position.y,
            Mathf.Clamp(transform.position.z, -4.5f, 4.5f));
    }

    public void Explode()
    {
        Instantiate(explosionEffect, playerCube.transform.position, transform.rotation);
        StartCoroutine(playerDestroyer());
        //StartCoroutine(GameOver());
    }

    IEnumerator playerDestroyer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(playerCube);
    }
    /*
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        gameOverScreen.Setup();
    }
    */
}
//Application load level
//Directional light,player,canvas,ground,main camera
//velocity * Time.deltaTime
//horizontal * movementSpeed * Time.deltaTime