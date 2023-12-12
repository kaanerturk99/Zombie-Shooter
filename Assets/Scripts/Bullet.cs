using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    void Awake() {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.GetComponent<Enemy>()){
            Destroy(other.gameObject);
            Destroy(gameObject);
            scoreKeeper.scoreValue += 10;
        }
        else if(other.gameObject.tag == "WorldObj"){
            Destroy(gameObject);
        }
    }
}
