using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    public Transform FirePlace;
    public GameObject Bullet;
    public float bulletForce = 200f;
    [SerializeField] private float cooldown = 5;
    private float cooldownTimer;
    public GameObject Player;
    public float moveSpeed;
    Vector3 moveDirection;

    public void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            BulletFire();
        }
        
    }
    
    void BulletFire()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer > 0)
        {
            return;
        }
        cooldownTimer = cooldown;
        GameObject BulletReal = Instantiate(Bullet, FirePlace.position, Quaternion.Euler(0f, 0f, 90f));
        Rigidbody rigidbodyBullet = BulletReal.GetComponent<Rigidbody>();
        moveDirection = (Player.transform.position - FirePlace.position).normalized * moveSpeed;
        rigidbodyBullet.AddForce(moveDirection.x, moveDirection.y, moveDirection.z);
        Destroy(BulletReal,4f);
    }
    
}