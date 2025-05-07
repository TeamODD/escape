using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Inventoryhighlighter : MonoBehaviour
{
    private float _blinkDuration=2;
    private Outline _outline;
    private Coroutine _blinkCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.effectColor =  new Color(0f, 0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHighlighter()
    {
        _outline.gameObject.SetActive(true);

        if (_blinkCoroutine == null)
        {
            _blinkCoroutine = StartCoroutine(Blink());
        }
        
        
    }

    public void OffHighliter()
    {
        if (_blinkCoroutine != null)
        {
            StopCoroutine(_blinkCoroutine);
            _blinkCoroutine = null;
        }
        _outline.effectColor =new Color(0f, 0f, 0f, 0f);
    }


    private IEnumerator Blink()
    {

        while (true)
        {
            
            yield return StartCoroutine(LerpColor(Color.black, Color.white, _blinkDuration));
            yield return new WaitForSeconds(3);

            yield return StartCoroutine(LerpColor(Color.white, Color.black, _blinkDuration));
            yield return new WaitForSeconds(3);

        }
    }

    private IEnumerator LerpColor(Color input, Color output, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            _outline.effectColor = Color.Lerp(input, output, time / duration);
            yield return null;
        }

        _outline.effectColor = output;
    }
}
