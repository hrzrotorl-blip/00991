using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadInputLegacy2Digit : MonoBehaviour
{
    [SerializeField] private Text inputText;

    private string current = ""; // 최대 2글자

    void Start()
    {
        Refresh();
    }

    // 숫자 버튼에서 호출 (0~9)
    public void PressDigit(int digit)
    {
        if (digit < 0 || digit > 9) return;

        // 이미 2자리면 더 입력 불가
        if (current.Length >= 2) return;

        // "0"으로 시작하는 거 허용/비허용 선택 가능
        // 현재는 "00" 같은 것도 허용(원하면 아래 주석 참고)
        current += digit.ToString();

        // 0~99 범위 보장(2자리 제한이라 자동으로 만족)
        Refresh();
    }

    // 백스페이스 버튼
    public void PressBackspace()
    {
        if (current.Length == 0) return;

        current = current.Substring(0, current.Length - 1);
        Refresh();
    }

    // C(전체 삭제) 버튼
    public void PressClear()
    {
        current = "";
        Refresh();
    }

    // 엔터 버튼
    public void PressEnter()
    {
        // 아무것도 입력 안 했으면 무시
        if (current.Length == 0) return;

        // "0~99" 숫자로 변환
        int value = int.Parse(current);

        // 여기서 value로 원하는 처리(프리팹 삭제 등) 호출
        Debug.Log($"ENTER: {value}");

        // 엔터 후 입력창 비우고 싶으면:
        current = "";
        Refresh();
    }

    private void Refresh()
    {
        // 빈칸이면 아무것도 안 보이게
        inputText.text = current;
    }
}