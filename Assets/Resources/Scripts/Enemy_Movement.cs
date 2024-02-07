using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public ParticleSystem smokeEffect;//����ϵͳ

    private Rigidbody2D rigidbody2d;
    
    
    //�ƶ�����Ŀ���
    private int direction = 1;//�������
    public float changeTime = 3.0f;//ʱ�䳣��
    private float timer;//��ʱ��
    private Animator monsterAnimator;
    //��ǰ������״̬(�Ƿ���й�����)
    private bool broken;

    // Start is called before the first frame update
    void Start()
    {
        broken = true;
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;//����ʱ�����ϳ�ʼֵ
        monsterAnimator = GetComponent<Animator>();
        /* monsterAnimator.SetFloat("MoveX", direction);
         monsterAnimator.SetBool("Vertical",vertical);*/
        MonsterPlayAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (!broken)
        {
            return;//ֹͣ�ƶ�,
        }
        Movement();
        timer -= Time.deltaTime;//ʱ��ĵݼ��ǵ��ڸñ�����
        if (timer <= 0)
        {
            direction = -direction;
            //monsterAnimator.SetFloat("MoveX", direction);
            MonsterPlayAnimation();
            timer = changeTime;
        }
    }
    private void Movement()
    {
        Vector2 position = rigidbody2d.position;//ͨ�����������λ��
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed*direction;//��ֱ
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed*direction;//ˮƽ
        }
        rigidbody2d.MovePosition(position);
    }
    //�������  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MainCharacter_Movement Ruby = collision.gameObject.GetComponent<MainCharacter_Movement>();
        if (Ruby != null)
        {
            Ruby.HP_Control(-1);
        }
    }
    //���ﶯ���Ĳ���
    private void MonsterPlayAnimation()
    {
        if (vertical)//��ֱ���򶯻��Ŀ���
        {
            monsterAnimator.SetFloat("MoveX", 0);
            monsterAnimator.SetFloat("MoveY", direction);
        }
        else//ˮƽ����Ķ�������
        {
            monsterAnimator.SetFloat("MoveX", direction);
            monsterAnimator.SetFloat("MoveY", 0);
        }
    }
    public void FixedRobot()
    {
        broken = false;
        rigidbody2d.simulated = false;//��ģ����壬Ҳ����˵��ͬ�ڹر��˸������;
        monsterAnimator.SetTrigger("Fixed");
        smokeEffect.Stop();
    }
}
