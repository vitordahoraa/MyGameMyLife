using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField]private Rigidbody2D player;
    [SerializeField]private float JumpSpeed;
    
    public Animator ani;

    private Vector2 movement;

    private bool isJumping;

    public TextMeshProUGUI VelocityX;


    [SerializeField]private Transform groundCheck;
    [SerializeField]private float groundCheckRadius;
    [SerializeField]private LayerMask groundLayer;
    private bool isTouchingGround;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        bool flipped = movement.x < 0;
        
        this.transform.localScale = new Vector3(flipped ? -1 : 1,1,1);
        
        float dirX = Input.GetAxisRaw("Horizontal");
        isTouchingGround =Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);
        isJumping = (isTouchingGround && Input.GetButton("Jump"));


        movement = new Vector2(dirX * 10f, isJumping ? JumpSpeed : player.velocity.y);  
        VelocityX.text = "Velocity: " + player.velocity.x.ToString();
        player.velocity = movement;


        ani.SetFloat("speedAtDirection", Mathf.Abs(movement.x));

    }
}
