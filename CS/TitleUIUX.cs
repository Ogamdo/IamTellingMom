using UnityEngine;
using UnityEngine.UI;

public class TitleUIUX : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button controlButton;
    
    [SerializeField] private GameObject creditPanel;
    [SerializeField] private GameObject controlPanel;
    
    private void Start()
    {
        // 람다식을 사용한 버튼 이벤트 설정
        startButton.onClick.AddListener(() => {
            GameManager.Instance.ResetGameState();
            GameManager.Instance.LoadNextScene();
        });
        creditButton.onClick.AddListener(() => TogglePanel(creditPanel));
        controlButton.onClick.AddListener(() => TogglePanel(controlPanel));
        
        // 초기 상태 설정
        if (creditPanel) creditPanel.SetActive(false);
        if (controlPanel) controlPanel.SetActive(false);
    }
    
    private void TogglePanel(GameObject panel)
    {
        if (!panel) return;
        panel.SetActive(!panel.activeSelf);
    }
    
    public void CloseAllPanels()
    {
        if (creditPanel) creditPanel.SetActive(false);
        if (controlPanel) controlPanel.SetActive(false);
    }
} 