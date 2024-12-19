using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject escPanel;
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private string sceneName;
    [SerializeField] private string retryScene;
    private bool isStopped = false;

    private void Start()
    {
        Time.timeScale = 1f;
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
                    inputReader.LockInput(true);
                    CloseEscPanel();
                }
                else
                {
                    inputReader.LockInput(false);
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
        SceneManager.LoadScene(retryScene);
    }

    public void DeadPanel()
    {
        Time.timeScale = 0f;
        deadPanel.SetActive(true);
    }

    public void ClearPanel()
    {
        Time.timeScale = 0f;
        clearPanel.SetActive(true);
    }

}
