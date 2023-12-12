using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    
    [SerializeField] GameObject bulletPrefab; //Bullet prefabini atıyoruz.
    [SerializeField] float bulletSpeed; //Mermi hızı
    [SerializeField] Transform gunOffset;
    bool fireContinuously; //sürekli ateş etmek için
    [SerializeField] float timeBetweenShots; //Mermiler arası hız
    private float lastFireTime; //En son ne zaman ateş ettik.

    // Update is called once per frame
    void Update()
    {
        if(fireContinuously){ //eğer basılı tutuyorsa true olcak, FireBullet çalışcak.
            float timeSinceLastFire = Time.time -  lastFireTime;
            if(timeSinceLastFire  >= timeBetweenShots){
                FireBullet();
            lastFireTime  =  Time.time;
            } 
        }
    }

    private void FireBullet(){
        //Oyun içinde bullet oluşturuyoruz. Pozisyon ve rotasyon olarak bu scripti atadığımız objecti alıyoruz.
        GameObject bullet = Instantiate(bulletPrefab,gunOffset.position,transform.rotation); 
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>(); //Merminin rigidbody'si

        rigidbody2D.velocity = bulletSpeed * transform.right;

    }

    private void OnFire(InputValue inputValue){ //InputSystem'de Fire metodu, eğer inputValue basılırsa fireContinuously true oluyor.
        fireContinuously = inputValue.isPressed;
    }
}
