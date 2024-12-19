using UnityEngine;
using UnityEngine.UI;

public class Uiset : MonoBehaviour
{
    public GameObject image;  // �̵��� �̹���
    public Button startButton;
    public Button settingButton;
    public Button exitButton;

    private const float fixedXPosition = -931f; // ������ X ��ǥ
    private float currentYPosition = 190f;      // ���� ���õ� Y ��ǥ
    private readonly float topYPosition = 190f;    // Start ��ư Y ��ǥ
    private readonly float middleYPosition = 65f; // Setting ��ư Y ��ǥ
    private readonly float bottomYPosition = -55f; // Exit ��ư Y ��ǥ

    private bool isPanelActive = false; // �г��� Ȱ��ȭ�� ���¸� Ȯ��
    private bool isInputLocked = false; // �Է� ��� �÷���

    void Start()
    {
        image.SetActive(false);  // ���� �� �̹��� ��Ȱ��ȭ
        MoveImage(currentYPosition); // �ʱ� ��ġ ����
        image.SetActive(true);  // �̹��� Ȱ��ȭ
    }

    void Update()
    {
        if (isPanelActive || image == null || isInputLocked) return;  // �Է� ��� �Ǵ� �г� Ȱ��ȭ ���̸� �Է� ����

        // ���� �̵�: 190 �� -55
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentYPosition == topYPosition)
        {
            currentYPosition = bottomYPosition;
            MoveImage(currentYPosition);
        }
        // �Ʒ��� �̵�: -55 �� 190
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentYPosition == bottomYPosition)
        {
            currentYPosition = topYPosition;
            MoveImage(currentYPosition);
        }
        // �⺻ ����: �Ʒ� ����Ű
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentYPosition = Mathf.Max(currentYPosition - 125f, bottomYPosition);
            MoveImage(currentYPosition);
        }
        // �⺻ ����: �� ����Ű
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentYPosition = Mathf.Min(currentYPosition + 125f, topYPosition);
            MoveImage(currentYPosition);
        }

        // ����Ű�� ���� ���õ� ��ư ����
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteSelectedButton();
        }
    }

    void MoveImage(float newYPosition)
    {
        // �̹��� ��ġ�� ������Ʈ
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(fixedXPosition, newYPosition);
        }
    }

    void ExecuteSelectedButton()
    {
        isInputLocked = true; // �Է� ��� Ȱ��ȭ

        // ���� Y ��ǥ�� ���� ��ư ����
        if (currentYPosition == topYPosition)
        {
            startButton.onClick.Invoke(); // Start ��ư ����
        }
        else if (currentYPosition == middleYPosition)
        {
            settingButton.onClick.Invoke(); // Setting ��ư ����
        }
        else if (currentYPosition == bottomYPosition)
        {
            exitButton.onClick.Invoke(); // Exit ��ư ����
        }
    }

    public void SetPanelActive(bool isActive)
    {
        // UIManager���� �г��� Ȱ��ȭ ���¸� �޾Ƽ� �̹��� ó��
        isPanelActive = isActive;

        if (isPanelActive)
        {
            image.SetActive(false); // �г��� Ȱ��ȭ�Ǹ� �̹��� ��Ȱ��ȭ
        }
        else
        {
            image.SetActive(true); // �г��� ��Ȱ��ȭ�Ǹ� �̹��� Ȱ��ȭ

            // ��Ȱ��ȭ �� �Է� ���� �ʱ�ȭ
            currentYPosition = 190f; // �ʱ� ��ġ�� ����
            MoveImage(currentYPosition);

            isInputLocked = false; // �Է� ��� ����
        }
    }
}