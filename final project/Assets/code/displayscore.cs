using UnityEngine;
using TMPro;

public class DisplayGlobalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 이 TMP 오브젝트의 텍스트를 갱신

    void Update()
    {
        // GameManager의 전역 스코어를 가져와 표시
        if (scoreText != null)
        {
            scoreText.text = $"Score: {Mathf.Round(GameManager.GetScore() * 100) / 100:F1}";
        }
    }
}
