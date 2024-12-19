using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;    // 세팅 UI 패널
    [SerializeField] private Uiset uisetScript;   // Uiset 스크립트를 참조

    private void Start()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);  // 세팅 패널은 시작 시 비활성화
    }

    public void SettingBtn()
    {
        panel.SetActive(true);   // Setting 버튼 클릭 시 패널 활성화
        uisetScript.SetPanelActive(true); // Uiset에 패널 활성화 상태 전달
    }

    public void DebugBtn()
    {
        Debug.Log("삭제");
        panel.SetActive(false);  // Debug 버튼 클릭 시 패널 비활성화
        uisetScript.SetPanelActive(false); // Uiset에 패널 비활성화 상태 전달
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("PSB_Scene");   // Start 버튼 클릭 시 씬 전환
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // 에디터에서 실행 종료
#endif
        Application.Quit();  // 실제 실행 종료
    }
}