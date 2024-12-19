using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private string sceneName;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void SettingBtn()
    {
        panel.SetActive(true);
    }

    public void DebugBtn()
    {
        Debug.Log("ªË¡¶");
        panel.SetActive(false);
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
