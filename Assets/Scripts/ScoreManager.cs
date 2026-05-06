using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // 어디서든 접근 가능하게 싱글톤 생성

    public TMP_Text score_text;
    private int score = 0;

    void Awake() { instance = this; }

    public void AddScore(int amount)
    {
        score += amount;
        score_text.text = "Score : " + score;
    }
}
