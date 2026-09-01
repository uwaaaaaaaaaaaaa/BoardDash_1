using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public AudioClip jumpClip;
    public AudioClip runningClip;
    public AudioSource jumpSource;
    public AudioSource runningSource;

    public float volume;

    public float JumpForce = 2f;
    private Rigidbody2D rb;
    public bool isGround = true;
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
        runningSource.clip = runningClip;
        runningSource.loop = true;
        volume = PlayerPrefs.GetFloat("Volume", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (title.jumpTrue == 1)
        {
            isTrash = Physics2D.OverlapCircle(groundChk.position, groundChkR, trashLayer);
        }
        isGround = Physics2D.OverlapCircle(groundChk.position, groundChkR, groundLayer);
        if ((Input.GetMouseButtonDown(0) || InScreenTapped()) && (isGround || isTrash))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
            jumpSource.PlayOneShot(jumpClip);
        }
        if (isGround)
        {
            if (!runningSource.isPlaying)  
            {
                Debug.Log($"runningSource instance ID: {runningSource.GetInstanceID()}");
    Debug.Log($"jumpSource instance ID: {jumpSource.GetInstanceID()}");
    Debug.Log($"Same? {runningSource == jumpSource}");
    Debug.Log($"runningSource.clip: {runningSource.clip}");
    Debug.Log($"runningClip: {runningClip}");
    
    runningSource.Play();
    
    Debug.Log($"再生後 isPlaying: {runningSource.isPlaying}");

            }
            animator.SetBool("isJump", false);
        }
        else
        {
            animator.SetBool("isJump", true);
            runningSource.Stop();
        }
        if(transform.position.x < -0.46f)
        {
            UISys.GameOver = true;
        }
        jumpSource.volume = volume;
        runningSource.volume = volume;

    }
    private bool InScreenTapped()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    public void StopAllSound()
    {
        runningSource.Stop();
    }
    
}
