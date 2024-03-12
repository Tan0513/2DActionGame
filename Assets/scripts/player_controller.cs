using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isHunt;//默認是false

    public Collider2D coll;
    public Collider2D disColl;
    public Transform cellingCheck;
    public float speed = 10f;
    public float jumpForce;
    public LayerMask ground;
    public int cherry;
    public Text cherryNum;
    //public AudioSource jumpAudio, huntAudio, cherryAudio;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // 游戲迴圈
    void FixedUpdate()
    {
        if(!isHunt)
        {
            Movement();
        }
        SwitchAnim();
    }

    private void Update() 
    {
        jump();
        Crouch();
        cherryNum.text = cherry.ToString();
    }
    //角色移動
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");

        // 角色移動
        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));
        }

        if (facedirection != 0)    
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
    }

    //切換動畫效果
    void SwitchAnim()
    {

        if(rb.velocity.y < 0.1f && !coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", true);
        }

        if(anim.GetBool("jumping"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }

        else if(isHunt)
        {
            anim.SetBool("hunt", true);
            anim.SetFloat("running",0);

            if(Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("hunt", false);
                isHunt = false;
            }
        }

        else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
        }
    }

    //碰撞觸發器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //收集物品
        if(collision.tag == "Collection")
        {
            SoundManager.instance.CherryAudio();
            collision.GetComponent<Animator>().Play("isGet");
        }
        //死綫
        if(collision.tag == "DeadLine")
        {
            GetComponent<AudioSource>().enabled = false; 
            Invoke("Restart", 1f);
        }
    }

    //消滅敵人
    private void OnCollisionEnter2D(Collision2D collsion)
        {
            if(collsion.gameObject.tag == "Enemy")
            {
                Enemy enemy = collsion.gameObject.GetComponent<Enemy>(); //調用forg class
                if(anim.GetBool("falling"))
                {
                    enemy.Jumpup();
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
                    anim.SetBool("jumping", true);
                }  

                else if(transform.position.x < collsion.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(-8, rb.velocity.y);
                    isHunt = true;
                    SoundManager.instance.HurtAudio();
                }

                else if(transform.position.x > collsion.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(8, rb.velocity.y);
                    SoundManager.instance.HurtAudio();
                    isHunt = true;
                }    
            }

        }

    void Crouch()
    {   
        if(Physics2D.OverlapCircle(cellingCheck.position, 0.2f, ground))
        {
            return;
        }
        if(Input.GetButton("Crouch"))
        {
            anim.SetBool("crouching", true);
            disColl.enabled = false;
        }
        else
        {
            anim.SetBool("crouching", false);
            disColl.enabled = true;
        }
    }
    
    // 角色跳躍
    void jump()
    {
        
        if (Input.GetButton("Jump") && coll.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.fixedDeltaTime);
            SoundManager.instance.JumpAudio();
            anim.SetBool("jumping", true);
        }
    }

    //死綫
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CherryCount()
    {
        ++cherry;
    }

}
