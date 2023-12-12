using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Transform playerPos; //Player'ımızın pozisyonuna ulaşmak için
    [SerializeField] float enemySpeed = 5f;
  

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //Player'ın konumuna ulaşıyoruz.
    }

    // Update is called once per frame
    void Update()
    {
        EnemyToPlayer();
    }

    private void EnemyToPlayer()
    {
        //Enemy'nin oyuncuya doğru haraketlenmesi
        transform.position = Vector2.MoveTowards(
            transform.position,
            playerPos.position,
            enemySpeed * Time.deltaTime
        );
    }
}
