using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPreset1;    // 첫 번째 방(RoomPreset1)
    public GameObject[] roomPrefabs; // 랜덤 방 배열
    public GameObject player;        // 플레이어 캐릭터
    public float xInterval = 50f;    // 방 간격
    private float nextRoomX = 0f;    // 다음 방의 x 위치
    private List<GameObject> activeRooms = new List<GameObject>(); // 활성화된 방 목록

    private GameObject lastRoom;     // 마지막으로 생성된 방

    void Start()
    {
        // 첫 번째 방(RoomPreset1) 생성
        InstantiateRoom(roomPreset1, true);

        // 두 번째, 세 번째, 네 번째 방 (랜덤 방들) 생성
        for (int i = 0; i < 3; i++)
        {
            InstantiateRoom(GetRandomRoom(), true);
        }
    }

    void Update()
    {
        // 마지막 방으로부터 2번 이전 방에 플레이어가 닿으면 새로운 방 생성
        if (activeRooms.Count > 2)
        {
            GameObject secondLastRoom = activeRooms[activeRooms.Count - 3];
            if (player.transform.position.x >= secondLastRoom.transform.position.x)
            {
                InstantiateRoom(GetRandomRoom(), false);
            }
        }

        // 화면 밖으로 벗어난 방을 자동으로 제거
        RemoveOutOfBoundsRooms();
    }

    void InstantiateRoom(GameObject roomPrefab, bool isInitial)
    {
        // 방 생성
        GameObject newRoom = Instantiate(roomPrefab, new Vector3(nextRoomX, 0, 0), Quaternion.identity);
        activeRooms.Add(newRoom);

        // 마지막으로 생성된 방 기록
        lastRoom = roomPrefab;

        // 다음 방 위치 갱신
        nextRoomX += xInterval;

        // 초기 방 생성 시에만 30초 뒤에 자동으로 사라지도록 설정
        if (isInitial)
        {
            StartCoroutine(RemoveRoomAfterDelay(newRoom, 300f)); // 초기 방은 30초 뒤에 제거
        }
    }

    GameObject GetRandomRoom()
    {
        // 랜덤한 방 반환, 이전 방과 다른 방을 선택
        GameObject randomRoom;
        do
        {
            randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
        } while (randomRoom == lastRoom);

        return randomRoom;
    }

    void RemoveOutOfBoundsRooms()
    {
        // 화면 밖으로 벗어난 방을 제거
        for (int i = 0; i < activeRooms.Count; i++)
        {
            GameObject room = activeRooms[i];
            if (room.transform.position.x + xInterval < player.transform.position.x)
            {
                // 화면 밖으로 나간 방을 제거
                activeRooms.RemoveAt(i);
                Destroy(room);
                i--; // 인덱스를 조정하여 삭제된 인덱스가 누락되지 않도록 함
            }
        }
    }

    IEnumerator RemoveRoomAfterDelay(GameObject room, float delay)
    {
        // 특정 시간 뒤 방 제거
        yield return new WaitForSeconds(delay);

        if (activeRooms.Contains(room))
        {
            activeRooms.Remove(room);
            Destroy(room);
        }
    }
}
