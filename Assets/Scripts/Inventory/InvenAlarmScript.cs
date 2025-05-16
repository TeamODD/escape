using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InvenAlarmScript : MonoBehaviour
{
     // 만약 배경 패널의 투명도도 조절하고 싶다면
    public Text MainText;
    public GameObject Panel;
    private Coroutine fadeCoroutine;
    public List<Sprite> ImageLists;
    public Image imageComponent;
    void Start()
    {
        Panel.SetActive(false);
        // 초기화 필요 시 여기에
    }

    public void SwitchText(GameObject input)
    {
        if (input.name == "DreamEmptyBottle")
        {
            imageComponent.sprite=ImageLists[0];
            MainText.text = "무언가 차 있는병 을 획득했습니다";
        }
        else if (input.name == "DreamKnife")
        {
            imageComponent.sprite=ImageLists[1];
            MainText.text = "만년필을 획득했습니다!";
        }
        else if (input.name == "JellyWarm")
        {
            imageComponent.sprite=ImageLists[2];
            MainText.text = "애벌레를 획득했습니다!";
        }
        else if (input.name == "DreamBroch1")
        {
            imageComponent.sprite=ImageLists[3];
            MainText.text = "유리조각을 획득했습니다!";
        }
        else if (input.name == "DreamBrouch2")
        {
            imageComponent.sprite=ImageLists[4];
            MainText.text = "머리핀을 획득했습니다!";
        }
        else if (input.name == "DreamBrouch3")
        {
            imageComponent.sprite=ImageLists[5];
            MainText.text = "나비 브로치를 획득했습니다!";
        }
        else if (input.name == "DreamBrouch4")
        {
            imageComponent.sprite=ImageLists[6];
            MainText.text = "꽃잎을 획득했습니다!";
        }
        else if (input.name == "DreamBrouchMid")
        {
            imageComponent.sprite=ImageLists[7];
            MainText.text = "나사못을 획득했습니다!";
        }
        
       
    }

    public void AlarmGetNewItem(GameObject input)
    {
        SwitchText(input);
        Panel.SetActive(true);
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine); // 이전 애니메이션 중단
        }
        fadeCoroutine = StartCoroutine(FadeTextEffect());
    }

    private IEnumerator FadeTextEffect()
    {
        Color color = imageComponent.color;
        color.a = 0f;
        imageComponent.color = color;

        // Fade-in
        float t = 0f;
        while (t < 0.7f)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t);
            imageComponent.color = color;
            
            yield return null;
        }

        // 유지 2초
        yield return new WaitForSeconds(2f);

        // Fade-out
        t = 0f;
        while (t < 1.2f)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t);
            imageComponent.color = color;
            
            yield return null;
        }
        Panel.SetActive(false);
        
    }
}