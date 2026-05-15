본 프로젝트는 스마트폰 카메라를 통해 실제 현실 공간의 평면을 탐지하고, 가상의 석궁을 이용해 둥둥 떠오르는 고무 질감의 풍선을 맞추어 점수를 획득하는 모바일 AR 슈팅 콘텐츠입니다. 단순한 기능 구현을 넘어 실시간 공간 데이터의 동적 가공, 물리 엔진 결합, 고도화된 비주얼 연출 및 UX 최적화에 초점을 맞추어 개발되었습니다.

---

## 프로젝트 핵심 특징 (Key Features)

* **실시간 공간 데이터 매핑**: `AR Plane Manager`를 통해 실시간으로 수평 및 수직 평면을 정밀하게 감지합니다.
* **동적 스폰 알고리즘**: 인식된 평면의 실제 물리적 크기를 계산하여, 영역 내부에서만 가상 오브젝트(풍선)가 무작위로 생성되도록 수학적 위치를 계산합니다.
* **시각 및 청각적 타격감 (Game Feel)**: 석궁 발사 애니메이션, 파티클 시스템 기반의 풍선 파편 효과, 그리고 공간 오디오를 결합하여 몰입감 높은 타격감을 선사합니다.

---

## 적용된 AR 기술

### 1. AR Plane Detection & Management
* 현실의 바닥(Horizontal)과 벽면(Vertical)을 분석하여 가상 콘텐츠가 배치될 물리적 기반을 확보합니다.
* 평면의 상태 변화를 실시간으로 추적하여 게임 월드의 경계면을 동적으로 갱신합니다.

---

```pascal
Assets/
├── Scripts/
|   ├── Arrow.cs               # 화살의 생명 주기 제어
│   ├── ArrowShooter.cs        # 석궁 위치 제어, 화살 발사 로직
│   ├── BalloonMove.cs         # 풍선 수직 상승 물리 제어, 충돌 감지, 점수 연동 및 이펙트/오디오 재생
│   └── BalloonSpawner.cs      # 탐지된 평면 크기에 맞춰 랜덤한 위치에 풍선을 생
└── Prefabs/
    ├── Arrow.prefab           # Rigidbody와 물리 충돌체가 세팅된 화살 오브젝트
    ├── DetectedPlane.prefab   # 평면 바닥을 탐지할 시 생성될 바닥 오브젝
    └── Balloon_~.prefab       # 반투명 고무 셰이더가 적용된 풍선 오브젝트
```
### 바닥 탐지 시 Detected Plane 생성
<img width="216" height="480" alt="화면캡쳐3" src="https://github.com/user-attachments/assets/7580e0cd-8494-4fe1-8351-2de34bae9334" />

### 화면 터치 시 화살 발사
<img width="216" height="480" alt="화면캡쳐1" src="https://github.com/user-attachments/assets/f5163d21-d100-4dbd-b983-aa4486d55182" />ㅁㅁㅁㅁㅁ

### 풍선 적중 시 점수 획득
<img width="216" height="480" alt="화면캡쳐2" src="https://github.com/user-attachments/assets/116af0ff-276b-4652-a15c-d79c5c9f15d8" />

