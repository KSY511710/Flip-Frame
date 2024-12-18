using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7.0f;  // �÷��̾��� �̵� �ӵ�

    private Rigidbody2D rb;
    private float movementInput;
    public float jumpForce = 7.0f;
    public GameObject playerDeathEffect;

    void Start()
    {
        // Rigidbody2D ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // A�� D Ű �Է��� �޽��ϴ�.
        movementInput = 1f;
        if (Input.GetKeyDown(KeyCode.J) && Mathf.Abs(rb.velocity.y) < 0.01f)  // �ٴڿ� ���� ���� ����
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // �÷��̾��� y��ǥ�� -15 �����̸� �θ� ������Ʈ ����
        if (transform.position.y <= -15f)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void FixedUpdate()
    {
        // Rigidbody2D�� ����� �¿�� �����Դϴ�.
        rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ��ü�� �±װ� "wall"���� Ȯ���մϴ�.
        if (collision.gameObject.CompareTag("wall"))
        {
            // ��� ����Ʈ ����
            GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            // �θ� ������Ʈ�� �����մϴ�.
            Destroy(transform.parent.gameObject);
            // 0.5�� �� ��� ����Ʈ �ߴ�
            Destroy(deathEffect, 0.7f);
        }
    }
}