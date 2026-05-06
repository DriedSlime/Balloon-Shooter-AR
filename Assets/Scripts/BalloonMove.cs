using UnityEngine;
using TMPro;

public class BalloonMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;   // 올라가는 속도
    public float maxHeight = 5.0f;  // 사라질 한계 높이 (Y축 값)

    private static int currentScore = 0;

    public GameObject destructionEffect; // 풍선 터질 때 이펙트
    public AudioClip popSound;           // 풍선 터지는 소리

    void Update()
    {
        // transform.up 또는 transform.forward는 벌레의 방향에 따라 조절하세요.
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // 2. 현재 높이(Y축 값)가 설정한 최대 높이보다 높은지 체크합니다.
        if (transform.position.y >= maxHeight)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 화살에 맞았을 때의 기존 로직
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // 점수 추가 로직 등을 여기에 넣으세요.
            ScoreManager.instance.AddScore(100);
            RemoveBalloon(true);
            Destroy(collision.gameObject); // 화살도 파괴
        }
    }

    void RemoveBalloon(bool isPopped)
    {
        // 사라질 때 이펙트가 있다면 생성
        if (destructionEffect != null && isPopped)
        {
            Instantiate(destructionEffect, transform.position, transform.rotation);
        }
        if(popSound != null)
        {
            AudioSource.PlayClipAtPoint(popSound, transform.position);
        }

        // 자기 자신을 제거
        Destroy(gameObject);
    }
}