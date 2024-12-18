using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private string sceneName;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
        }
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene(sceneName);
    }

}
