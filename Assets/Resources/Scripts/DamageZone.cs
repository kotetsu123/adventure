using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private float timeValue;
    // Start is called before the first frame update
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }*/ 
    private void OnTriggerStay2D(Collider2D collision)
    {
        MainCharacter_Movement Ruby = collision.GetComponent<MainCharacter_Movement>();
        if (Ruby != null)
        {
            // Ruby.Health = Ruby.Health - 1;
            Ruby.HP_Control(-1);
            Debug.Log(Ruby.Health);

        }
    }
}
