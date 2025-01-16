using UnityEngine;

/// <summary>
/// 게임의 모든 오디오를 관리하는 매니저 클래스
/// 배경음악과 효과음을 구분하여 재생/정지 기능 제공
/// </summary>
public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;            // 사운드 식별자
        public AudioClip clip;         // 실제 오디오 클립
        [Range(0f, 1f)]
        public float volume = 1f;      // 음량 (0~1)
        [Range(0.1f, 3f)]
        public float pitch = 1f;       // 음의 높낮이
        public bool loop = false;      // 반복 재생 여부
        
        [HideInInspector]
        public AudioSource source;     // 실제 사운드 재생기
    }

    [Header("오디오 설정")]
    [SerializeField] private Sound[] backgroundMusic;    // 배경음악 목록
    [SerializeField] private Sound[] soundEffects;       // 효과음 목록
} 