using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRigidbodyMover : MonoBehaviour
{
    public Transform parentTransform;  // �θ� ������Ʈ�� Transform
    private Vector3 lastChildPosition;
    private Rigidbody rb;

    void Start()
    {
        // �ڽ� ������Ʈ�� Rigidbody�� �ʱ� ��ġ ����
        rb = GetComponent<Rigidbody>();
        lastChildPosition = transform.position;
        
    }

    void OnEnable()
    {
        lastChildPosition = transform.position;
    }
    void FixedUpdate()
    {
        // �ڽ��� �̵� ���̸� ����Ͽ� �θ𿡰� ����
        Vector3 movement = transform.position - lastChildPosition;
        parentTransform.position += movement;

        // �ڽ��� ���� ��ǥ�� (0, 0, 0)���� ����
        transform.localPosition = Vector3.zero;

        // ������ ��ġ ������Ʈ
        lastChildPosition = transform.position;
    }

}