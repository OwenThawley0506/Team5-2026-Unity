using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float PlayerSpeed = 5f;
    private Rigidbody2D rb;

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
        
    }

    void FixedUpdate()
    {
        if (DialogueManager.getInstance() != true) { Debug.Log("No Dialogue Manager Found");  return; }

        if (DialogueManager.getInstance().dialogueIsPlaying)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        rb.linearVelocity = InputManager.getInstance().moveDirection * PlayerSpeed;
    }
}
