using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 7.0f;  // 이동 속도
    public float jumpForce = 7.0f;
    public GameObject playerDeathEffect;

    private Rigidbody rb;         // Rigidbody 컴포넌트를 저장할 변수

    void Start()
    {
        // Rigidbody 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveSpeed = 7.0f;
        // GetAxis를 사용하여 입력값을 받아옵니다.
        // Horizontal: A, D, Left/Right 화살표
        // Vertical: W, S, Up/Down 화살표
        float moveX = 1.0f;
        float moveZ = -Input.GetAxis("Horizontal");

        // 이동 벡터 계산
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;

        // Rigidbody를 이용해 물리적 이동
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Z축 좌표를 -4.5에서 4.5 사이로 제한
        float clampedZ = Mathf.Clamp(transform.position.z, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Mathf.Abs(rb.velocity.y) < 0.01f)  // 바닥에 있을 때만 점프
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 플레이어의 y좌표가 -15 이하이면 부모 오브젝트 삭제
        if (transform.position.y <= -15f)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 물체의 태그가 "wall"인지 확인합니다.
        if (collision.gameObject.CompareTag("wall"))
        {
            // 사망 이펙트 생성
            GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            // 부모 오브젝트를 삭제합니다.
            Destroy(transform.parent.gameObject);
            // 0.5초 후 사망 이펙트 중단
            Destroy(deathEffect, 0.7f);
        }
    }
}