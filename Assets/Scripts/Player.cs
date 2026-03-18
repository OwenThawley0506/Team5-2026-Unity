using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float PlayerSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementDirection;

    public bool hasCanister;
    public bool hasHammer;

    public Player()
    {

        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); 
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * PlayerSpeed;
    }
}
