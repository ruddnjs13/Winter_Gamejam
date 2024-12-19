using UnityEngine;
using UnityEngine.UI;

public class Uiset : MonoBehaviour
{
    public GameObject image; // 이동할 이미지 (Inspector에서 설정)
    public Button startButton;   // Start 버튼 (Inspector에서 설정)
    public Button settingButton; // Setting 버튼 (Inspector에서 설정)
    public Button exitButton;    // Exit 버튼 (Inspector에서 설정)

    private const float fixedXPosition = -931f; // 고정된 X 좌표
    private float currentYPosition = 190f;      // 현재 선택된 Y 좌표
    private readonly float topYPosition = 190f;    // Start 버튼 Y 좌표
    private readonly float middleYPosition = 65f; // Setting 버튼 Y 좌표
    private readonly float bottomYPosition = -55f; // Exit 버튼 Y 좌표

    void Start()
    {
        // 버튼 클릭 동작 설정
        startButton.onClick.AddListener(ExecuteStartButton);
        settingButton.onClick.AddListener(ExecuteSettingButton);
        exitButton.onClick.AddListener(ExecuteExitButton);

        image.SetActive(false); // 시작 시 이미지 비활성화
        MoveImage(currentYPosition); // 초기 위치 설정
        image.SetActive(true); // 이미지 활성화
    }

    void Update()
    {
        if (image == null) return;

        // 위쪽 이동: 190 → -55
        if (Input.GetKeyDown(KeyCode.UpArrow) && currentYPosition == topYPosition)
        {
            currentYPosition = bottomYPosition;
            MoveImage(currentYPosition);
        }
        // 아래쪽 이동: -55 → 190
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentYPosition == bottomYPosition)
        {
            currentYPosition = topYPosition;
            MoveImage(currentYPosition);
        }
        // 기본 동작: 아래 방향키
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentYPosition = Mathf.Max(currentYPosition - 125f, bottomYPosition);
            MoveImage(currentYPosition);
        }
        // 기본 동작: 위 방향키
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentYPosition = Mathf.Min(currentYPosition + 125f, topYPosition);
            MoveImage(currentYPosition);
        }

        // 엔터키로 현재 선택된 버튼 실행
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ExecuteSelectedButton();
        }
    }

    void MoveImage(float newYPosition)
    {
        // 이미지 위치를 업데이트
        RectTransform rectTransform = image.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(fixedXPosition, newYPosition);
        }
    }

    void ExecuteSelectedButton()
    {
        // 현재 Y 좌표에 따라 버튼 실행
        if (currentYPosition == topYPosition)
        {
            startButton.onClick.Invoke(); // Start 버튼 실행
        }
        else if (currentYPosition == middleYPosition)
        {
            settingButton.onClick.Invoke(); // Setting 버튼 실행
        }
        else if (currentYPosition == bottomYPosition)
        {
            exitButton.onClick.Invoke(); // Exit 버튼 실행
        }
    }

    void ExecuteStartButton()
    {
        Debug.Log("게임이 시작됩니다!");
        // 실제 Start 버튼 동작 추가
    }

    void ExecuteSettingButton()
    {
        Debug.Log("설정 화면으로 이동합니다!");
        // 실제 Setting 버튼 동작 추가
    }

    void ExecuteExitButton()
    {
        Debug.Log("게임을 종료합니다!");
        Application.Quit();
        // 실제 Exit 버튼 동작 추가
    }
}