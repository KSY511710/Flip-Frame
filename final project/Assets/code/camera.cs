using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetTr; // 플레이어의 Transform을 연결
    private float xdistance = 6.0f; // 캐릭터와의 x 거리
    private float ydistance = 7.0f; // 캐릭터와의 y 거리
    private float zdistance = -15.0f; // 캐릭터와의 z 거리
    public float dampingTrace = 5.0f;  // 부드럽게 플레이어를 추적하는 정도
    private float xdistanceLimit = 3.0f;  // 카메라의 x 좌표 제한
   
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (GameManager.is3Dcamera)
        {
            // 3D 카메라로 전환
            transform.position = new Vector3(targetTr.position.x-40, 28, targetTr.position.z - 40);
            transform.rotation = Quaternion.Euler(20, 50, 0);
        }
        else
        {
            // 2D 카메라 동작
            transform.position = new Vector3(targetTr.position.x + 6, 10, targetTr.position.z - 12);

            transform.rotation = Quaternion.Euler(0, 0, 0);
          
        }
    }
}