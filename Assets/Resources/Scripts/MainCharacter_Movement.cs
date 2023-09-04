using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MainCharacter_Movement : MonoBehaviour
{
    private Rigidbody2D  rigidbody2d;
    private bool isUnattackable=false;//�Ƿ����޵�
    private float unAttackableTimer;//�޵м�ʱ��
    //��ɫ����ֵ
    private int currentHp;//��ɫ��ǰ����ֵ
    public int maxHp = 5;//��ɫ�������ֵ����


    public Sprite[] characterSprite;
    public int moveSpeed = 3;
    //��ɫ���޵�ʱ�䳣��
    public float timeUnattackable = 2.0f;

   

    //���Ե�ʹ��
    public int Health { get { return currentHp; } set { currentHp=value; } }



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        
        
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
        

    }
    private void FixedUpdate()
    {
       
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
        position.x = position.x+moveSpeed*h * Time.fixedDeltaTime;
        position.y=position.y+moveSpeed*v* Time.fixedDeltaTime;
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
    }
}
