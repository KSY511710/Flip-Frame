using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float moveSpeed = 7.0f;  // �̵� �ӵ�
    public float jumpForce = 7.0f;
    public GameObject playerDeathEffect;

    private Rigidbody rb;         // Rigidbody ������Ʈ�� ������ ����

    void Start()
    {
        // Rigidbody ������Ʈ�� �����ɴϴ�.
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveSpeed = 7.0f;
        // GetAxis�� ����Ͽ� �Է°��� �޾ƿɴϴ�.
        // Horizontal: A, D, Left/Right ȭ��ǥ
        // Vertical: W, S, Up/Down ȭ��ǥ
        float moveX = 1.0f;
        float moveZ = -Input.GetAxis("Horizontal");

        // �̵� ���� ���
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;

        // Rigidbody�� �̿��� ������ �̵�
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Z�� ��ǥ�� -4.5���� 4.5 ���̷� ����
        float clampedZ = Mathf.Clamp(transform.position.z, -4.5f, 4.5f);
        transform.position = new Vector3(transform.position.x, transform.position.y, clampedZ);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && Mathf.Abs(rb.velocity.y) < 0.01f)  // �ٴڿ� ���� ���� ����
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // �÷��̾��� y��ǥ�� -15 �����̸� �θ� ������Ʈ ����
        if (transform.position.y <= -15f)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
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