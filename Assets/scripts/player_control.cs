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
    bool isRunningSoundPlayed = false; // ���ڱ����Ч�Ƿ��Ѳ���

    public float speed;
    float xvelocity;
    

    //��������Ƿ�Ӵ�ͼ��
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
        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));//���ö����Ĳ����ٶ�

        xvelocity = Input.GetAxisRaw("Horizontal");//getaxisraw�������Է���0 1 -1 �����˽�ɫ���ܶ�����;�ֹ���

        if (xvelocity != 0 && !isRunningSoundPlayed&&isongroud) // ���xvelocity������0����Чδ����
        {
            audioSource.clip = run;
            audioSource.Play();
            isRunningSoundPlayed = true; // ������Ч�Ѳ���
        }
        else if (xvelocity == 0)
        {
            isRunningSoundPlayed = false; // ������Ч����״̬
        }


        rb.velocity=new Vector2 (xvelocity*speed,rb.velocity.y);//new������������vector��ֵ

        if(xvelocity!=0)
            transform.localScale=new Vector3(xvelocity,1,1);//�ı�����ĳ���

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
