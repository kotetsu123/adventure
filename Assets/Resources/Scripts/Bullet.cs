using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;



    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collsion the GameObjcet is : " + collision.gameObject);
        //Destroy(gameObject);

    }
}
