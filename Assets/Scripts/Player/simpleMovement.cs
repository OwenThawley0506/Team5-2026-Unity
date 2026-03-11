using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = +1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = +1f;

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        float moveSpeed = 5f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
