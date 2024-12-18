using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentController : MonoBehaviour
{
    // 부모 오브젝트의 MeshRenderer를 참조합니다.
    private MeshRenderer parentMeshRenderer;

    private void Start()
    {
        // 현재 오브젝트의 MeshRenderer를 가져옵니다.
        parentMeshRenderer = GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        // 자식 오브젝트 2번째를 가져옵니다.
        if (transform.childCount >= 2) // 자식이 최소 2개 있어야 함
        {
            Transform secondChild = transform.GetChild(1); // 두 번째 자식
            if (secondChild.gameObject.activeSelf == false)
            {
                // 두 번째 자식이 비활성화되었을 때 부모의 MeshRenderer를 비활성화
                if (parentMeshRenderer != null)
                {
                    parentMeshRenderer.enabled = false;
                }
            }
            else
            {
                // 두 번째 자식이 활성화되었을 때 부모의 MeshRenderer를 다시 활성화
                if (parentMeshRenderer != null)
                {
                    parentMeshRenderer.enabled = true;
                }
            }
        }
    }
}
