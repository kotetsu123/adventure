using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    public float followSpeed = 2.0f;
    public float minX;
    public float maxX;
    public float minY; 
    public float maxY;
    public Transform target;

    //private Transform PlayerTransform;
    
     
    void Start()
    {
        //PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

       /* PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;//��ѰĿ��
        transform.position = new Vector3(PlayerTransform.position.x,PlayerTransform.position.y,-10f);
        //transform.position=PlayerTransform.position;//����*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        /* if (target != null)
         {
             *//*targetPosition.x = Mathf.Clamp(PlayerTransform.position.x, minX, maxX);
             targetPosition.y = Mathf.Clamp(PlayerTransform.position.y, minY, maxY);*//*//���˾���û��ʲô��
                                                                                      //transform.position = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);//����
                                                                                      //transform.position = Vector3.Lerp(transform.position,targetPosition,followSpeed*Time.deltaTime);
                                                                                      // transform.position = new Vector3(targetPosition.x, targetPosition.y, -10f);
             *//*Vector3 targetPosition = Camera.main.WorldToViewportPoint(target.position);//����Ŀ������Ļ�����λ��
             targetPosition.z = -10f;
             Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, targetPosition.z));//���Ӧ���ƶ�������
             Vector3 destination = targetPosition + delta;//�����������Ŀ��λ��
             transform.position = Vector3.Lerp(targetPosition,destination,followSpeed*Time.deltaTime);//���ս��*//*


         }*/
        if (target != null)
        {
            float v=Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            Vector3 targetPosition = Camera.main.WorldToViewportPoint(target.position);//����Ŀ������Ļ�Ϸ���λ��
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,targetPosition.z));//�����Ӧ���ƶ�������
            Vector3 destination = transform.position + delta;      //�����������Ŀ��λ��
            transform.position = Vector3.Lerp(transform.position, destination, followSpeed * Time.deltaTime);//���ս��
        }
    }
}
