using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;

public class ArrowShooter : MonoBehaviour
{
    public GameObject arrowPrefab;     // 발사할 화살 프리팹

    [Header("발사 설정")]
    float shootForce = 4f;    // 화살 발사 힘 (속도)
    float fireRate = 1f;     // 발사 간격 (초)
    float nextFireTime = 0f;

    public GameObject reticlePrefab;    // 조준점 (선택사항, 화면 중앙)

    private Animator anim;
    private ARRaycastManager arRaycastManager;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SetCrossbowLook();
    }

    void SetCrossbowLook()
    {
        Transform camPos = Camera.main.transform;

        // 위치 고정: 카메라 위치에서 약간 앞(+forward), 아래(-up)로 오프셋 조절
        Vector3 offset = (camPos.forward * 0.18f) + (camPos.up * -0.1f);
        transform.position = camPos.position + offset;

        // 회전 고정: 카메라가 바라보는 방향과 똑같이 회전
        Quaternion additionalRotation = Quaternion.Euler(-3f, 0, 0);
        transform.rotation = camPos.rotation * additionalRotation;
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        // 'Started'는 터치가 시작되는 순간 딱 한 번 실행
        if (context.started)
        {
            if (Time.time >= nextFireTime)
            {
                ShootArrow();
                nextFireTime = Time.time + fireRate;
            }
        }
    }
    void ShootArrow()
    {
        if (arrowPrefab == null) return;

        // 석궁의 위치와 회전을 기준으로 생성
        Vector3 spawnPos = transform.position + (transform.forward * -0.2f);

        if(anim != null)
        {
            anim.SetTrigger("Shoot");
        }

        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // 석궁이 바라보는 앞방향으로 발사
            rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
        }
    }
    
}
