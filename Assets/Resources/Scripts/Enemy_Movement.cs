using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public bool vertical;

    private Rigidbody2D rigidbody2d;
    
    
    //移动方向的控制
    private int direction = 1;//轴向控制
    public float changeTime = 3.0f;//时间常量
    private float timer;//计时器

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = changeTime;//给计时器附上初始值
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        timer -= Time.deltaTime;//时间的递减是等于该变量的
        if (timer <= 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }
    private void Movement()
    {
        Vector2 position = rigidbody2d.position;//通过刚体来获得位移
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed*direction;//垂直
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed*direction;//水平
        }
        rigidbody2d.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MainCharacter_Movement Ruby = collision.gameObject.GetComponent<MainCharacter_Movement>();
        if (Ruby != null)
        {
            Ruby.HP_Control(-1);
        }
    }

}
