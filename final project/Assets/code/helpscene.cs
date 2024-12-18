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
            // "help" 태그를 가진 오브젝트를 찾음
            GameObject helpObject = GameObject.FindWithTag("help");

            // help 오브젝트가 존재하면 자식 오브젝트에 접근
            if (helpObject != null)
            {
                // 자식 오브젝트의 수를 확인하여 첫 번째와 두 번째 자식을 활성화/비활성화
                if (helpObject.transform.childCount >= 2)
                {
                    // 첫 번째 자식 활성화
                    helpObject.transform.GetChild(0).gameObject.SetActive(true);

                    // 두 번째 자식 비활성화
                    helpObject.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            // "help" 태그를 가진 오브젝트를 찾음
            GameObject helpObject = GameObject.FindWithTag("help");

            // help 오브젝트가 존재하면 자식 오브젝트에 접근
            if (helpObject != null)
            {
                // 자식 오브젝트의 수를 확인하여 첫 번째와 두 번째 자식을 활성화/비활성화
                if (helpObject.transform.childCount >= 2)
                {
                    // 첫 번째 자식 활성화
                    helpObject.transform.GetChild(1).gameObject.SetActive(true);

                    // 두 번째 자식 비활성화
                    helpObject.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
