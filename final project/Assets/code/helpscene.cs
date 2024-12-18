using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helpscene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Start");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            // "help" �±׸� ���� ������Ʈ�� ã��
            GameObject helpObject = GameObject.FindWithTag("help");

            // help ������Ʈ�� �����ϸ� �ڽ� ������Ʈ�� ����
            if (helpObject != null)
            {
                // �ڽ� ������Ʈ�� ���� Ȯ���Ͽ� ù ��°�� �� ��° �ڽ��� Ȱ��ȭ/��Ȱ��ȭ
                if (helpObject.transform.childCount >= 2)
                {
                    // ù ��° �ڽ� Ȱ��ȭ
                    helpObject.transform.GetChild(0).gameObject.SetActive(true);

                    // �� ��° �ڽ� ��Ȱ��ȭ
                    helpObject.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            // "help" �±׸� ���� ������Ʈ�� ã��
            GameObject helpObject = GameObject.FindWithTag("help");

            // help ������Ʈ�� �����ϸ� �ڽ� ������Ʈ�� ����
            if (helpObject != null)
            {
                // �ڽ� ������Ʈ�� ���� Ȯ���Ͽ� ù ��°�� �� ��° �ڽ��� Ȱ��ȭ/��Ȱ��ȭ
                if (helpObject.transform.childCount >= 2)
                {
                    // ù ��° �ڽ� Ȱ��ȭ
                    helpObject.transform.GetChild(1).gameObject.SetActive(true);

                    // �� ��° �ڽ� ��Ȱ��ȭ
                    helpObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
