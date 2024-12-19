using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject escPanel;
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private string sceneName;
    private bool isStopped = false;

    private void Start()
    {
        escPanel.SetActive(false);
        clearPanel.SetActive(false);
        deadPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isStopped)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (escPanel.activeSelf)
                {
                    CloseEscPanel();
                }
                else
                {
                    OpenEscPanel();
                }
            }
        }

    }

    private void OpenEscPanel()
    {
        Time.timeScale = 0f;
        escPanel.SetActive(true);
    }

    private void CloseEscPanel()
    {
        Time.timeScale = 1f;
        escPanel.SetActive(false);
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RetryBtn()
    {
        SceneManager.LoadScene("PSB_Scene");
    }

    public void DeadPanel()
    {
        deadPanel.SetActive(true);
    }

    public void ClearPanel()
    {
        clearPanel.SetActive(true);
    }

}
