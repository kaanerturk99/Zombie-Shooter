using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    
    public GameObject  enemyPrefab; //Spawnlanacak enemynin prefabini alıyoruz
    public Transform[] spawnPoints;
    public float interval;
    
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepating fonksiyonu ile, Spawn Fonksiyonunu, 1f saniye sonra, interval aralıklarında çalıştırıyoruz.
        InvokeRepeating("Spawn", 1f , interval);
    }

    private void Spawn(){
        //spawnPointslerden random spawnpoint alıyoruz.
        int randPos = Random.Range(0, spawnPoints.Length); 
        //Enemy spawnlıyoruz. Pozisyon olarak random seçtiğimiz spawnpoints atıyoruz.
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randPos].position, Quaternion.identity);
    }
}
