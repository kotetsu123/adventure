using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MainCharacter_Movement Ruby = collision.GetComponent<MainCharacter_Movement>();
        //当前发生触发检测的游戏物体身上是否有MainCharacter_Movement
        if (Ruby!=null)
        {
            
            //Destroy(collision.gameObject);
            //主角是否满血
            if (Ruby.Health<Ruby.maxHp)//Ruby.currentHp<Ruby.maxHp)
            {
                //主角不是满血时
                // Ruby.currentHp = Ruby.currentHp + 1;
                Ruby.Health = Ruby.Health + 1;
                //Ruby.HP_Control(1);//与上面的二选一，上面是运用属性的下面的调用别的脚本当中的public方法 论安全性应该是上面的属性更高
                Destroy(gameObject);
            }
            
        }
        else
        {
            Destroy(null);
        }
    }

}
