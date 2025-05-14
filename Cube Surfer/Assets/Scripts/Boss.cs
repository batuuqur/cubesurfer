using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    public Transform FirePlace;
    public GameObject Bullet;
    public GameObject aboutToHit;
    [SerializeField] private float cooldown = 5;
    private float cooldownTimer;
    public GameObject Player;
    public float moveSpeed;
    Vector3 moveDirection;


    private void Start()
    {
        DOTween.Init();
        
    }

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
        GameObject current = Instantiate(Bullet, FirePlace.transform.position, Quaternion.identity);
        GameObject effect = Instantiate(aboutToHit, Player.transform.position+ new Vector3(-15, -Player.transform.position.y+1, 0), Quaternion.identity);
        current.transform.DOJump(Player.transform.position + new Vector3(-15, -Player.transform.position.y + 1, 0), 2f,
            1, 1f).OnComplete(()=> ParticleColor(current));
        
        Destroy(effect,4f);
    }

    void ParticleColor(GameObject go)
    {
        go.GetComponentInChildren<ParticleSystem>().Play();
    }



}