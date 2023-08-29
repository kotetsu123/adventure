using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MainCharacter_Movement : MonoBehaviour
{
    private Rigidbody2D  rigidbody2D;
    private int currentHp;//角色当前生命值
    

    public Sprite[] characterSprite;
    public int moveSpeed = 3;
    public int maxHp=5;//角色最大生命值上限



    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
        
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        

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
        position.x = position.x+moveSpeed*h * Time.fixedDeltaTime;
        position.y=position.y+moveSpeed*v* Time.fixedDeltaTime;
        rigidbody2D.MovePosition(position);
    }
    public  void HP_Control(int amount)
    {
        currentHp = Mathf.Clamp(currentHp + amount, 0, maxHp);      
        Debug.Log(currentHp+"/"+maxHp);
    }
}
