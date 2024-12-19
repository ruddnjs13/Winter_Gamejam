using UnityEngine;
using UnityEngine.UI;

public class Uiset : MonoBehaviour
{
    public GameObject image;  // 이동할 이미지
    public Button startButton;
    public Button settingButton;
    public Button exitButton;

    private const float fixedXPosition = -931f; // 고정된 X 좌표
    private float currentYPosition = 190f;      // 현재 선택된 Y 좌표
    private readonly float topYPosition = 190f;    // Start 버튼 Y 좌표
    private readonly float middleYPosition = 65f; // Setting 버튼 Y 좌표
    private readonly float bottomYPosition = -55f; // Exit 버튼 Y 좌표

    private bool isPanelActive = false; // 패널이 활성화된 상태를 확인
    private bool isInputLocked = false; // 입력 잠금 플래그

    void Start()
    {
        image.SetActive(false);  // 시작 시 이미지 비활성화
        MoveImage(currentYPosition); // 초기 위치 설정
        image.SetActive(true);  // 이미지 활성화
    }

    void Update()
    {
        if (isPanelActive || image == null || isInputLocked) return;  // 입력 잠금 또는 패널 활성화 중이면 입력 차단

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
        isInputLocked = true; // 입력 잠금 활성화

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

    public void SetPanelActive(bool isActive)
    {
        // UIManager에서 패널의 활성화 상태를 받아서 이미지 처리
        isPanelActive = isActive;

        if (isPanelActive)
        {
            image.SetActive(false); // 패널이 활성화되면 이미지 비활성화
        }
        else
        {
            image.SetActive(true); // 패널이 비활성화되면 이미지 활성화

            // 비활성화 후 입력 상태 초기화
            currentYPosition = 190f; // 초기 위치로 복구
            MoveImage(currentYPosition);

            isInputLocked = false; // 입력 잠금 해제
        }
    }
}