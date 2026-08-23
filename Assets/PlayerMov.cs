using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float JumpForce = 2f;
    private Rigidbody2D rb;
    private bool isGround = true;
    public LayerMask groundLayer;
    public LayerMask trashLayer;
    public Transform groundChk;
    public float groundChkR = 0.1f;
    private Animator animator;
    private bool isTrash = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(-0.429f, -0.209f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (title.jumpTrue == 1)
        {
            isTrash = Physics2D.OverlapCircle(groundChk.position, groundChkR, trashLayer);
        }
        isGround = Physics2D.OverlapCircle(groundChk.position, groundChkR, groundLayer);
        if (isGround && (Input.GetMouseButtonDown(0) || InScreenTapped()))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
        else if (isTrash && (Input.GetMouseButtonDown(0) || InScreenTapped()))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
            if (isGround)
        {
            animator.SetBool("isJump", false);
        }
        else
        {
            animator.SetBool("isJump", true);
        }
        if(transform.position.x < -0.46f)
        {
            UISys.GameOver = true;
        }
    }
    private bool InScreenTapped()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
}
