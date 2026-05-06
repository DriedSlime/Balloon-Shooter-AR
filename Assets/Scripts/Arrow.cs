using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifeTime = 4f; // 사라질 시간 (4초)
    Rigidbody rb;
    bool isHit = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // 생성된 시점부터 5초 후에 이 게임 오브젝트를 파괴합니다.
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // 2. 부딪힌 오브젝트의 태그가 "Ground"인지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            StopArrow();
        }
    }
    void StopArrow()
    {
        // 물리 연산 중단: 속도와 회전력을 모두 0으로 만듭니다.
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 더 이상 물리 엔진의 영향을 받지 않도록 고정 (중력 등 무시)
        rb.isKinematic = true;
    }
}