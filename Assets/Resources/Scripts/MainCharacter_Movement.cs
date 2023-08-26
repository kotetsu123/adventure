using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter_Movement : MonoBehaviour
{
    public Sprite[] CharacterSprite;
    public int MoveSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
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
        float v = Input.GetAxisRaw("Vertical");//��ֱ�ƶ�
        transform.Translate(Vector3.up * MoveSpeed *v * Time.fixedDeltaTime, Space.World);
        float h = Input.GetAxisRaw("Horizontal");//ˮƽ�ƶ�
        transform.Translate(Vector3.right* MoveSpeed * h * Time.fixedDeltaTime, Space.World);
        
    }
}
