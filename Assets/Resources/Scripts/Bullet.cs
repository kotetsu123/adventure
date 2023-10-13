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
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collsion the GameObjcet is : " + collision.gameObject);
        
        Enemy_Movement enemyControler=collision.gameObject.GetComponent<Enemy_Movement>();
        if (enemyControler != null)
        {
            enemyControler.FixedRobot();
        }
        Destroy(gameObject);
    }
    
}
