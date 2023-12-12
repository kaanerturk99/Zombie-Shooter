using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    
    private void Update() {
        //Player Movement
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;

        //Player looking at cursor
        LookAtCursor();
    }

    void LookAtCursor()
    {
        //mouse pozisyonunu aldık
        Vector3 mousePoisiton = Input.mousePosition;

        mousePoisiton = Camera.main.ScreenToWorldPoint(mousePoisiton);

        //mousePosition dan karakterin pozisyonunu çıkartırsak karakterden mouse doğru bir vektor oluşur. Bu vektörü direction'a 
        //atıyoruz.
        Vector2 direction = new Vector2(mousePoisiton.x - transform.position.x , mousePoisiton.y - transform.position.y);
        //Karakter sprite'ı default olarak sağ tarafa baktığı için transform.right'ı sağ tarafa eşitliyoruz.
        transform.right = direction;
    }

    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }

}
