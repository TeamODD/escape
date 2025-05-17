using System;
using System.Collections;
using Assets.Scripts.Dialogue;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LighControlScript : MonoBehaviour
{
    public DialogueData lightOnDialogue;
    private Light2D Light2D;
    public float targetIntensity = 5.0f;
    public float fadeDuration = 1.0f;
    public GameObject StainLight;
    public bool islighton;
    void Start()
    {
        Light2D = GetComponent<Light2D>();
        Light2D.intensity = 0f; // 시작은 꺼진 상태
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LightOn();
        }
    }

    public void LightOn()
    {
        
        if (islighton)
        {
            islighton = false;
            StainLight.SetActive(false);
            StartCoroutine(FadeInLight());
        }
    }

    private IEnumerator FadeInLight()
    {
        float elapsed = 0f;
        float startIntensity = Light2D.intensity;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float newIntensity = Mathf.Lerp(startIntensity, targetIntensity, elapsed / fadeDuration);
            Light2D.intensity = newIntensity;
            yield return null;
        }

        Light2D.intensity = targetIntensity; // 정확히 맞춰줌
        DialogueController.Instance.PlayDialogue(lightOnDialogue);
    }
}
