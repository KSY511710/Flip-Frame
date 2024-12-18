using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7.0f;  // 플레이어의 이동 속도

    private Rigidbody2D rb;
    private float movementInput;
    public float jumpForce = 7.0f;
    public GameObject playerDeathEffect;

    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // A와 D 키 입력을 받습니다.
        movementInput = 1f;
        if (Input.GetKeyDown(KeyCode.J) && Mathf.Abs(rb.velocity.y) < 0.01f)  // 바닥에 있을 때만 점프
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // 플레이어의 y좌표가 -15 이하이면 부모 오브젝트 삭제
        if (transform.position.y <= -15f)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2D를 사용해 좌우로 움직입니다.
        rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
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