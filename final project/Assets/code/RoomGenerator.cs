using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPreset1;    // ù ��° ��(RoomPreset1)
    public GameObject[] roomPrefabs; // ���� �� �迭
    public GameObject player;        // �÷��̾� ĳ����
    public float xInterval = 50f;    // �� ����
    private float nextRoomX = 0f;    // ���� ���� x ��ġ
    private List<GameObject> activeRooms = new List<GameObject>(); // Ȱ��ȭ�� �� ���

    private GameObject lastRoom;     // ���������� ������ ��

    void Start()
    {
        // ù ��° ��(RoomPreset1) ����
        InstantiateRoom(roomPreset1, true);

        // �� ��°, �� ��°, �� ��° �� (���� ���) ����
        for (int i = 0; i < 3; i++)
        {
            InstantiateRoom(GetRandomRoom(), true);
        }
    }

    void Update()
    {
        // ������ �����κ��� 2�� ���� �濡 �÷��̾ ������ ���ο� �� ����
        if (activeRooms.Count > 2)
        {
            GameObject secondLastRoom = activeRooms[activeRooms.Count - 3];
            if (player.transform.position.x >= secondLastRoom.transform.position.x)
            {
                InstantiateRoom(GetRandomRoom(), false);
            }
        }

        // ȭ�� ������ ��� ���� �ڵ����� ����
        RemoveOutOfBoundsRooms();
    }

    void InstantiateRoom(GameObject roomPrefab, bool isInitial)
    {
        // �� ����
        GameObject newRoom = Instantiate(roomPrefab, new Vector3(nextRoomX, 0, 0), Quaternion.identity);
        activeRooms.Add(newRoom);

        // ���������� ������ �� ���
        lastRoom = roomPrefab;

        // ���� �� ��ġ ����
        nextRoomX += xInterval;

        // �ʱ� �� ���� �ÿ��� 30�� �ڿ� �ڵ����� ��������� ����
        if (isInitial)
        {
            StartCoroutine(RemoveRoomAfterDelay(newRoom, 300f)); // �ʱ� ���� 30�� �ڿ� ����
        }
    }

    GameObject GetRandomRoom()
    {
        // ������ �� ��ȯ, ���� ��� �ٸ� ���� ����
        GameObject randomRoom;
        do
        {
            randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
        } while (randomRoom == lastRoom);

        return randomRoom;
    }

    void RemoveOutOfBoundsRooms()
    {
        // ȭ�� ������ ��� ���� ����
        for (int i = 0; i < activeRooms.Count; i++)
        {
            GameObject room = activeRooms[i];
            if (room.transform.position.x + xInterval < player.transform.position.x)
            {
                // ȭ�� ������ ���� ���� ����
                activeRooms.RemoveAt(i);
                Destroy(room);
                i--; // �ε����� �����Ͽ� ������ �ε����� �������� �ʵ��� ��
            }
        }
    }

    IEnumerator RemoveRoomAfterDelay(GameObject room, float delay)
    {
        // Ư�� �ð� �� �� ����
        yield return new WaitForSeconds(delay);

        if (activeRooms.Contains(room))
        {
            activeRooms.Remove(room);
            Destroy(room);
        }
    }
}
