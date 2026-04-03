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
<<<<<<< HEAD:Assets/Scripts/Player/Player.cs
<<<<<<< HEAD:Assets/Scripts/Player/Player.cs
        if (DialogueManager.getInstance().dialogueIsPlaying)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        rb.velocity = InputManager.getInstance().moveDirection * PlayerSpeed;
=======
        rb.linearVelocity = movementDirection * PlayerSpeed;
>>>>>>> Art:Assets/Scripts/Player.cs
=======
        rb.velocity = movementDirection * PlayerSpeed;
>>>>>>> parent of 2fd057b (Merge branch 'CharacterInteraction2.0'):Assets/Scripts/Player.cs
    }
}
