using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MainCharacter_Movement Ruby = collision.GetComponent<MainCharacter_Movement>();
        if (Ruby!=null)
        {
            Ruby.HP_Control(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(null);
        }
    }

}
