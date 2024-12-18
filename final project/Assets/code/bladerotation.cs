using UnityEngine;

public class bladerotation : MonoBehaviour
{
    [SerializeField] private Transform axis; // 회전 축
    [SerializeField] private Transform[] blades; // 회전할 날들
    [SerializeField] private float rotationSpeed = 50f; // 회전 속도

    void Update()
    {
        if (axis == null || blades.Length == 0) return;

        // 날들 각각을 축을 중심으로 회전
        foreach (var blade in blades)
        {
            if (blade != null)
            {
                blade.RotateAround(axis.position, axis.up, rotationSpeed * Time.deltaTime);
            }
        }
    }
}