using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingScript : MonoBehaviour
{

    public GameObject endingImage;

    public List<Sprite> cutScenes;
    private Image scene;
    public static EndingScript Instance{get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void Awake()
    {
       
        // 싱글톤 패턴
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    void Start()
    {
        scene = endingImage.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RequsetEnding(int idx)
    {
        endingImage.SetActive(true);
        scene.sprite = cutScenes[idx];
    }
}
