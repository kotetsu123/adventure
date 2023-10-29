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

       /* PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;//搜寻目标
        transform.position = new Vector3(PlayerTransform.position.x,PlayerTransform.position.y,-10f);
        //transform.position=PlayerTransform.position;//错误*/
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
             targetPosition.y = Mathf.Clamp(PlayerTransform.position.y, minY, maxY);*//*//个人觉得没有什么用
                                                                                      //transform.position = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);//错误
                                                                                      //transform.position = Vector3.Lerp(transform.position,targetPosition,followSpeed*Time.deltaTime);
                                                                                      // transform.position = new Vector3(targetPosition.x, targetPosition.y, -10f);
             *//*Vector3 targetPosition = Camera.main.WorldToViewportPoint(target.position);//计算目标在屏幕上面的位置
             targetPosition.z = -10f;
             Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, targetPosition.z));//相机应该移动的向量
             Vector3 destination = targetPosition + delta;//计算摄像机的目标位置
             transform.position = Vector3.Lerp(targetPosition,destination,followSpeed*Time.deltaTime);//最终结果*//*


         }*/
        if (target != null)
        {
            float v=Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");
            Vector3 targetPosition = Camera.main.WorldToViewportPoint(target.position);//计算目标在屏幕上方的位置
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,targetPosition.z));//摄像机应该移动的向量
            Vector3 destination = transform.position + delta;      //计算摄像机的目标位置
            transform.position = Vector3.Lerp(transform.position, destination, followSpeed * Time.deltaTime);//最终结果
        }
    }
}
