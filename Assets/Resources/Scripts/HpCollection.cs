using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCollection : MonoBehaviour
{
    public ParticleSystem HpEffect;
    public GameObject HpPrefab;
    public AudioClip collectedClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MainCharacter_Movement Ruby = collision.GetComponent<MainCharacter_Movement>();
        //��ǰ��������������Ϸ���������Ƿ���MainCharacter_Movement
        if (Ruby!=null)
        {
            
            //Destroy(collision.gameObject);
            //�����Ƿ���Ѫ
            if (Ruby.Health<Ruby.maxHp)//Ruby.currentHp<Ruby.maxHp)
            {
                //���ǲ�����Ѫʱ
                // Ruby.currentHp = Ruby.currentHp + 1;
                //Ruby.Health = Ruby.Health + 1;
                Ruby.HP_Control(1);//������Ķ�ѡһ���������������Ե�����ĵ��ñ�Ľű����е�public���� �۰�ȫ��Ӧ������������Ը���
                Destroy(gameObject);

                Ruby.PlaySound(collectedClip);
               //HpEffecthelper();
                
            }
            
        }
        else
        {
            Destroy(null);
        }
    }
    public void HpEffecthelper(Vector3 position)
    {
        GameObject hpObject = Instantiate(HpPrefab, position, Quaternion.identity);
        HpEffect = hpObject.GetComponent<ParticleSystem>();
        if (!HpEffect.main.loop && HpEffect.main.stopAction == ParticleSystemStopAction.Destroy)
        {
            HpEffect.Play();
        }
    }
}
