using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour
{   
    Rigidbody2D rb;
    Animator animator;

    AudioSource audioSource;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip death;
    bool isRunningSoundPlayed = false; // 用于标记音效是否已播放

    public float speed;
    float xvelocity;
    

    //检测人物是否接触图层
    public bool isongroud;
    public LayerMask platform;
    public float r;
    public GameObject groudcheck;

    public static bool playerdead;

    public float jumpForce = 5f;

    public int jumpCount = 2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        isongroud = Physics2D.OverlapCircle(groudcheck.transform.position, r,platform);
        animator.SetBool("isongroud", isongroud);
        Jump();
       

    }
    private void FixedUpdate()
    {
        movement();
        Jump();
    }

    void movement()
    {
        rb.rotation = 0;
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));//设置动画的播放速度

        xvelocity = Input.GetAxisRaw("Horizontal");//getaxisraw函数可以返回0 1 -1 决定了角色的跑动方向和静止与否

        if (xvelocity != 0 && !isRunningSoundPlayed&&isongroud) // 如果xvelocity不等于0且音效未播放
        {
            audioSource.clip = run;
            audioSource.Play();
            isRunningSoundPlayed = true; // 设置音效已播放
        }
        else if (xvelocity == 0)
        {
            isRunningSoundPlayed = false; // 重置音效播放状态
        }


        rb.velocity=new Vector2 (xvelocity*speed,rb.velocity.y);//new函数用于重载vector的值

        if(xvelocity!=0)
            transform.localScale=new Vector3(xvelocity,1,1);//改变人物的朝向

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&jumpCount>0 )
        {
            jumpCount--;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            audioSource.clip = jump;
            audioSource.Play();
        }

        if (isongroud)
        {
            jumpCount = 2;
         
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            animator.SetTrigger("dead");
            dead();
        }
    }

    public void dead()
    {
        audioSource.clip = death;
        audioSource.Play();
        playerdead = true;
        gamecontrol.gameover(playerdead);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groudcheck.transform.position, r);
    }
    
    
}
