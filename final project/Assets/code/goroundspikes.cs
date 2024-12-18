using UnityEngine;

public class goroundspikes : MonoBehaviour
{
    [SerializeField] private Transform axis; // 회전 축
    [SerializeField] private Transform[] blades; // 회전할 날들
    [SerializeField] private float rotationSpeed = 300f; // 회전 속도

    public float speed = 10f; // 가시 이동 속도
    public float MinX = -20f; // 최소 거리
    public float MaxX = 20f; // 최대 거리

    private int direction = 1; // 이동 방향 (1: 오른쪽, -1: 왼쪽)
    private float initialX; // 초기 X 위치 (월드 좌표 기준)

    // Start is called before the first frame update
    void Start()
    {
        // 시작 시 X 좌표
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // X 좌표 업데이트
        float targetX = transform.position.x + (speed * direction * Time.deltaTime);
        float localX = targetX - initialX;

        // 최대 거리에 도달하면 방향 전환
        if (localX >= MaxX)
        {
            direction = -1;
            targetX = initialX + MaxX;
        }
        else if (localX <= MinX)
        {
            direction = 1;
            targetX = initialX + MinX;
        }

        // 위치 업데이트
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);



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