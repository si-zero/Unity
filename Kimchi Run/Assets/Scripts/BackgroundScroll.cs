using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("Setting")]
    [Tooltip("얼마나 컴포넌드 이동속도가 빠른가?")]
    public float scrollSpeed;

    [Header("References")]
    public MeshRenderer meshRenderer;

    // 최초 프레임 시작 전에 실행되는 메소드
    void Start()
    {
        
    }

    // 프레임 당 한 번 실행되는 메소드 ex) 300프레임 게임 -> 300번
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * GameManager.Instance.CalculateGameSpeed() / 5 * Time.deltaTime, 0);
    }
}
