using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MainCharacter_Movement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private int currentHp;//角色当前生命值
    

    public Sprite[] CharacterSprite;
    public int MoveSpeed = 0;
    public int MaxHp=5;//角色最大生命值上限



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        HP_Control(0);

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
        /*float v = Input.GetAxisRaw("Vertical");//垂直移动
        transform.Translate(Vector3.up * MoveSpeed *v * Time.fixedDeltaTime, Space.World);
        float h = Input.GetAxisRaw("Horizontal");//水平移动
        transform.Translate(Vector3.right* MoveSpeed * h * Time.fixedDeltaTime, Space.World);
        Vector3 position= transform.position;
        rigidbody2D.position = position;*/
        Vector2 position=transform.position;
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        position.x = position.x+3*h * Time.fixedDeltaTime;
        position.y=position.y+3*v* Time.fixedDeltaTime;
        rigidbody2D.MovePosition(position);
    }
    private void HP_Control(int amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, MaxHp);      
        Debug.Log(currentHp+"/"+MaxHp);
    }
}
