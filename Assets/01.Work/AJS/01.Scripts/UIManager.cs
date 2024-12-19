using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;    // ���� UI �г�
    [SerializeField] private GameObject image;    // ���� UI ���� �̹���
    [SerializeField] private string sceneName;    // �ε��� �� �̸�
    [SerializeField] private Uiset uisetScript;   // Uiset ��ũ��Ʈ�� ����

    private void Start()
    {
        panel.SetActive(false);  // ���� �г��� ���� �� ��Ȱ��ȭ
        image.SetActive(false);  // �̹����� ���� �� ��Ȱ��ȭ
    }

    public void SettingBtn()
    {
        panel.SetActive(true);   // Setting ��ư Ŭ�� �� �г� Ȱ��ȭ
        uisetScript.SetPanelActive(true); // Uiset�� �г� Ȱ��ȭ ���� ����
    }

    public void DebugBtn()
    {
        Debug.Log("����");
        panel.SetActive(false);  // Debug ��ư Ŭ�� �� �г� ��Ȱ��ȭ
        uisetScript.SetPanelActive(false); // Uiset�� �г� ��Ȱ��ȭ ���� ����
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(sceneName);   // Start ��ư Ŭ�� �� �� ��ȯ
    }

    public void ExitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // �����Ϳ��� ���� ����
#endif
        Application.Quit();  // ���� ���� ����
    }
}