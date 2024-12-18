using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentController : MonoBehaviour
{
    // �θ� ������Ʈ�� MeshRenderer�� �����մϴ�.
    private MeshRenderer parentMeshRenderer;

    private void Start()
    {
        // ���� ������Ʈ�� MeshRenderer�� �����ɴϴ�.
        parentMeshRenderer = GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        // �ڽ� ������Ʈ 2��°�� �����ɴϴ�.
        if (transform.childCount >= 2) // �ڽ��� �ּ� 2�� �־�� ��
        {
            Transform secondChild = transform.GetChild(1); // �� ��° �ڽ�
            if (secondChild.gameObject.activeSelf == false)
            {
                // �� ��° �ڽ��� ��Ȱ��ȭ�Ǿ��� �� �θ��� MeshRenderer�� ��Ȱ��ȭ
                if (parentMeshRenderer != null)
                {
                    parentMeshRenderer.enabled = false;
                }
            }
            else
            {
                // �� ��° �ڽ��� Ȱ��ȭ�Ǿ��� �� �θ��� MeshRenderer�� �ٽ� Ȱ��ȭ
                if (parentMeshRenderer != null)
                {
                    parentMeshRenderer.enabled = true;
                }
            }
        }
    }
}
