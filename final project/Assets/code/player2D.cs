using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRigidbodyMover : MonoBehaviour
{
    public Transform parentTransform;  // 부모 오브젝트의 Transform
    private Vector3 lastChildPosition;
    private Rigidbody rb;

    void Start()
    {
        // 자식 오브젝트의 Rigidbody와 초기 위치 저장
        rb = GetComponent<Rigidbody>();
        lastChildPosition = transform.position;
        
    }

    void OnEnable()
    {
        lastChildPosition = transform.position;
    }
    void FixedUpdate()
    {
        // 자식의 이동 차이를 계산하여 부모에게 적용
        Vector3 movement = transform.position - lastChildPosition;
        parentTransform.position += movement;

        // 자식의 로컬 좌표를 (0, 0, 0)으로 고정
        transform.localPosition = Vector3.zero;

        // 마지막 위치 업데이트
        lastChildPosition = transform.position;
    }

}