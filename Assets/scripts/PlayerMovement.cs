using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Скорость перемещения персонажа")]
    public float speed = 7f;

    [Header("Обьект на земле?")]
    public bool ground;
    
    [Header("Сила прыжка?")]
    public float jumpPower = 200f;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    // Управление персонажем
    private void GetInput() {
        if(Input.GetKey(KeyCode.W)) {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S)) {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A)) {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D)) {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            if(ground == true) {
                rb.AddForce(transform.up * jumpPower);
            }
        }
    }
    // Столкновение с обьектом
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Ground") {
            ground = true;
        }
    }
    // Выход из обьекта
    private void OnCollisionExit(Collision collision) {
        if(collision.gameObject.tag == "Ground") {
            ground = false;
        }
    }
}
