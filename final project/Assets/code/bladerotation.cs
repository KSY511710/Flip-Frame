using UnityEngine;

public class bladerotation : MonoBehaviour
{
    [SerializeField] private Transform axis; // ȸ�� ��
    [SerializeField] private Transform[] blades; // ȸ���� ����
    [SerializeField] private float rotationSpeed = 50f; // ȸ�� �ӵ�

    void Update()
    {
        if (axis == null || blades.Length == 0) return;

        // ���� ������ ���� �߽����� ȸ��
        foreach (var blade in blades)
        {
            if (blade != null)
            {
                blade.RotateAround(axis.position, axis.up, rotationSpeed * Time.deltaTime);
            }
        }
    }
}