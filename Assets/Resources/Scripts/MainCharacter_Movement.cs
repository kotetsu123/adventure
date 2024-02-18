using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MainCharacter_Movement : MonoBehaviour
{
    private Rigidbody2D  rigidbody2d;
    private bool isUnattackable=false;//�Ƿ����޵�
    private float unAttackableTimer;//�޵м�ʱ��
    private Vector2 lookDirection = new Vector2(0, -1);//��ʼ����
    private Animator rubyAnimator;

    //��ɫ����ֵ
    private int currentHp;//��ɫ��ǰ����ֵ
    public int maxHp = 5;//��ɫ�������ֵ����


    public Sprite[] characterSprite;
    public int moveSpeed = 3;
    //��ɫ���޵�ʱ�䳣��
    public float timeUnattackable = 2.0f;

    public GameObject bulletPrefab;
    public ParticleSystem hpEffect;

    public AudioSource audioSource;
    public AudioSource WalkAudioSource;

    public AudioClip playerHit;
    public AudioClip walkSound;

    public static MainCharacter_Movement instance;
    private static MainCharacter_Movement Instance { get => instance; set => instance = value; }

    //���Ե�ʹ��
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
        /*float v = Input.GetAxisRaw("Vertical");//��ֱ�ƶ�
        transform.Translate(Vector3.up * MoveSpeed *v * Time.fixedDeltaTime, Space.World);
        float h = Input.GetAxisRaw("Horizontal");//ˮƽ�ƶ�
        transform.Translate(Vector3.right* MoveSpeed * h * Time.fixedDeltaTime, Space.World);
        Vector3 position= transform.position;
        rigidbody2D.position = position;*/
        Vector2 position=transform.position;
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(h, v);
        if (!Mathf.Approximately(move.x,0)||!Mathf.Approximately(move.y,0))//��ǰ������������Ϊ0
        {
            lookDirection.Set(move.x, move.y);//lookDirection=move;
            lookDirection.Normalize();//��һ�������ش�СΪ1����������Ϊ����Ҫ�����ʵ�ʵ�������С��ֻ��Ҫ����������
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
       /* //x���ϵ��ƶ�
        position.x = position.x+moveSpeed*h * Time.fixedDeltaTime;
        //y���ϵ��ƶ�
        position.y=position.y+moveSpeed*v* Time.fixedDeltaTime;*/
        //�ϲ��Ĵ���
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
            //�յ��˺�
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
