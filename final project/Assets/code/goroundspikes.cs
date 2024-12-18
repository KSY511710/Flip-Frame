using UnityEngine;

public class goroundspikes : MonoBehaviour
{
    [SerializeField] private Transform axis; // ȸ�� ��
    [SerializeField] private Transform[] blades; // ȸ���� ����
    [SerializeField] private float rotationSpeed = 300f; // ȸ�� �ӵ�

    public float speed = 10f; // ���� �̵� �ӵ�
    public float MinX = -20f; // �ּ� �Ÿ�
    public float MaxX = 20f; // �ִ� �Ÿ�

    private int direction = 1; // �̵� ���� (1: ������, -1: ����)
    private float initialX; // �ʱ� X ��ġ (���� ��ǥ ����)

    // Start is called before the first frame update
    void Start()
    {
        // ���� �� X ��ǥ
        initialX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // X ��ǥ ������Ʈ
        float targetX = transform.position.x + (speed * direction * Time.deltaTime);
        float localX = targetX - initialX;

        // �ִ� �Ÿ��� �����ϸ� ���� ��ȯ
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

        // ��ġ ������Ʈ
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);



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