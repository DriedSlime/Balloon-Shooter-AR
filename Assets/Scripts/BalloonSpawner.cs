using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] balloonPrefabs; 
    public float spawnInterval = 5f;

    private ARPlaneManager planeManager;
    private List<ARPlane> Planes = new List<ARPlane>();

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

    void Start()
    {
        InvokeRepeating("SpawnBalloon", 2f, spawnInterval);
    }

    void SpawnBalloon()
    {
        Planes.Clear();

        foreach (var plane in planeManager.trackables)
        {
            if (plane.alignment == PlaneAlignment.HorizontalUp)
            {
                Planes.Add(plane);
            }
        }

        if (Planes.Count > 0 && balloonPrefabs.Length > 0)
        {
            // 1. 랜덤하게 벽 하나 선택
            ARPlane selectedPlane = Planes[Random.Range(0, Planes.Count)];

            // 2. 종류 중 하나를 랜덤하게 선택
            int randomIndex = Random.Range(0, balloonPrefabs.Length);
            GameObject selected = balloonPrefabs[randomIndex];

            // 3. 위치 계산 (핵심 로직)
            Vector3 spawnPosition = GetRandomPositionOnPlane(selectedPlane);

            // 4. 생성 (벽이 바라보는 방향(Rotation)을 고려하여 생성)
            Instantiate(selected, spawnPosition, selectedPlane.transform.rotation);
        }
    }

    // 평면의 크기를 계산하여 랜덤한 좌표를 반환하는 함수
    Vector3 GetRandomPositionOnPlane(ARPlane plane)
    {
        Vector3 center = plane.center;

        // 만약 size가 0이라면 최소 10cm(0.1f) 범위를 부여합니다.
        float halfWidth = Mathf.Max(plane.size.x * 0.4f, 0.1f);
        float halfHeight = Mathf.Max(plane.size.y * 0.4f, 0.1f);

        float randomX = Random.Range(-halfWidth, halfWidth);
        float randomY = Random.Range(-halfHeight, halfHeight);

        // 벽에서 5cm 정도 띄워서 생성 (벽 안에 파묻힘 방지)
        Vector3 localRandomPos = (plane.transform.right * randomX) + 
                                (plane.transform.up * randomY) + 
                                (plane.transform.forward * 0.05f);

        return center + localRandomPos;
    }
}