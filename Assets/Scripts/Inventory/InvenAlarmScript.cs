using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InvenAlarmScript : MonoBehaviour
{
    public Image alarmPanel; // 만약 배경 패널의 투명도도 조절하고 싶다면
    public Text MainText;

    private Coroutine fadeCoroutine;

    void Start()
    {
        // 초기화 필요 시 여기에
    }

    public void SwitchText(GameObject input)
    {
        if (input.name == "DreamEmptyBottle")
        {
            MainText.text = "무언가 차 있는병 을 획득했습니다";
        }
        else if (input.name == "DreamKnife")
        {
            MainText.text = "만년필을 획득했습니다!";
        }
        else if (input.name == "JellyWarm")
        {
            MainText.text = "애벌레를 획득했습니다!";
        }
        else if (input.name == "DreamBroch1")
        {
            MainText.text = "유리조각을 획득했습니다!";
        }
        else if (input.name == "DreamBrouch2")
        {
            MainText.text = "머리핀을 획득했습니다!";
        }
        else if (input.name == "DreamBrouch3")
        {
            MainText.text = "나비 브로치를 획득했습니다!";
        }
        else if (input.name == "DreamBrouch4")
        {
            MainText.text = "꽃잎을 획득했습니다!";
        }
        else if (input.name == "DreamBrouchMid")
        {
            MainText.text = "나사못을 획득했습니다!";
        }
        
       
    }

    public void AlarmGetNewItem(GameObject input)
    {
        SwitchText(input);
        
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); // 이전 애니메이션 중단
        }
        fadeCoroutine = StartCoroutine(FadeTextEffect());
    }

    private IEnumerator FadeTextEffect()
    {
        Color color = MainText.color;
        color.a = 0f;
        MainText.color = color;

        // Fade-in
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t);
            MainText.color = color;
            
            yield return null;
        }

        // 유지 2초
        yield return new WaitForSeconds(2f);

        // Fade-out
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t);
            MainText.color = color;
            
            yield return null;
        }

        
    }
}