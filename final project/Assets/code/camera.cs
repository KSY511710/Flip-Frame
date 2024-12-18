using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetTr; // �÷��̾��� Transform�� ����
    private float xdistance = 6.0f; // ĳ���Ϳ��� x �Ÿ�
    private float ydistance = 7.0f; // ĳ���Ϳ��� y �Ÿ�
    private float zdistance = -15.0f; // ĳ���Ϳ��� z �Ÿ�
    public float dampingTrace = 5.0f;  // �ε巴�� �÷��̾ �����ϴ� ����
    private float xdistanceLimit = 3.0f;  // ī�޶��� x ��ǥ ����
   
    

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
            // 3D ī�޶�� ��ȯ
            transform.position = new Vector3(targetTr.position.x-40, 28, targetTr.position.z - 40);
            transform.rotation = Quaternion.Euler(20, 50, 0);
        }
        else
        {
            // 2D ī�޶� ����
            transform.position = new Vector3(targetTr.position.x + 6, 10, targetTr.position.z - 12);

            transform.rotation = Quaternion.Euler(0, 0, 0);
          
        }
    }
}