using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MainCharacter_Movement : MonoBehaviour
{
    private Rigidbody2D  rigidbody2d;
    private bool isUnattackable=false;//是否是无敌
    private float unAttackableTimer;//无敌计时器
    private Vector2 lookDirection = new Vector2(0, -1);//初始朝向
    private Animator rubyAnimator;

    //角色生命值
    private int currentHp;//角色当前生命值
    public int maxHp = 5;//角色最大生命值上限


    public Sprite[] characterSprite;
    public int moveSpeed = 3;
    //角色的无敌时间常量
    public float timeUnattackable = 2.0f;

    public GameObject bulletPrefab;
    public ParticleSystem hpEffect;

    public AudioSource audioSource;
    public AudioSource WalkAudioSource;

    public AudioClip playerHit;
    public AudioClip walkSound;

    public static MainCharacter_Movement instance;
    private static MainCharacter_Movement Instance { get => instance; set => instance = value; }

    //属性的使用
    public int Health { get { return currentHp; } set { currentHp=value; } }



    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        rubyAnimator=GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        if (isUnattackable)
        {
            unAttackableTimer = unAttackableTimer - Time.deltaTime;
            if (unAttackableTimer <= 0)
            {
                isUnattackable = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            TalkWithNPC();
           
        }
        

    }
    private void FixedUpdate()
    {
       
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    private void Movement()
    {
        /*if (Input.GetKey(KeyCode.D)) {
            Vector2 position = transform.position;
            position.x = position.x + 0.1f;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 position = transform.position;
            position.x = position.x - 0.1f;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 position = transform.position;
            position.y = position.y+ 0.1f;
            transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 position = transform.position;
            position.y = position.y - 0.1f;
            transform.position = position;
        }*/
        /*float v = Input.GetAxisRaw("Vertical");//垂直移动
        transform.Translate(Vector3.up * MoveSpeed *v * Time.fixedDeltaTime, Space.World);
        float h = Input.GetAxisRaw("Horizontal");//水平移动
        transform.Translate(Vector3.right* MoveSpeed * h * Time.fixedDeltaTime, Space.World);
        Vector3 position= transform.position;
        rigidbody2D.position = position;*/
        Vector2 position=transform.position;
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(h, v);
        if (!Mathf.Approximately(move.x,0)||!Mathf.Approximately(move.y,0))//当前玩家输入的轴向不为0
        {
            lookDirection.Set(move.x, move.y);//lookDirection=move;
            lookDirection.Normalize();//归一化，返回大小为1的向量。因为不需要上面的实际的数量大小，只需要它的向量。
            if (!WalkAudioSource.isPlaying)
            {
                WalkAudioSource.clip = walkSound;
                WalkAudioSource.Play();
            }

        }
        else
        {
            WalkAudioSource.Stop();
        }
        rubyAnimator.SetFloat("Look X",lookDirection.x);
        rubyAnimator.SetFloat("Look Y", lookDirection.y);
        rubyAnimator.SetFloat("Speed", move.magnitude);
       /* //x轴上的移动
        position.x = position.x+moveSpeed*h * Time.fixedDeltaTime;
        //y轴上的移动
        position.y=position.y+moveSpeed*v* Time.fixedDeltaTime;*/
        //合并的代码
        position = position + moveSpeed * move * Time.fixedDeltaTime;
        rigidbody2d.MovePosition(position);
    }
    public  void HP_Control(int amount)
    {
        
        if (amount < 0)
        {
            if (isUnattackable == true)
            {
                return;
            }
            //收到伤害
            isUnattackable = true;
            unAttackableTimer = timeUnattackable;
        }

        currentHp = Mathf.Clamp(currentHp + amount, 0, maxHp);      
        Debug.Log(currentHp+"/"+maxHp);
        UiHealthBar.instance.SetValue(currentHp / (float)maxHp);
        rubyAnimator.SetTrigger("Hit");
        PlaySound(playerHit);
    }
    private void Launch()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, rigidbody2d.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Launch(lookDirection,300f);
        rubyAnimator.SetTrigger("Launch");

    }
    private void TalkWithNPC()
    {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("Npc"));
        if (hit.collider != null)
        {
            NPC npc = hit.collider.GetComponent<NPC>();
            if (npc != null)
            {
                npc.DisPlayDialog();
            }
        }
    }
}
