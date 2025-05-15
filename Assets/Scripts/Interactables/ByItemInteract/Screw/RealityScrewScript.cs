using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealityScrewScript : ClickHandler
{
    public ZoomImage ZoomImage;

    private bool _isRequestItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
        if (flowIdx == 1)
        {
            //스테인글라스의
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            _isRequestItem = true;
            
            
            OneFlowPlus();
        }
    }

    public void getScrew()
    {
        if (_isRequestItem)
        {
            flowController.CheckGameObject(gameObject); 
            ZoomImage.OnHide();
            _isRequestItem = false;
        }
        
    }
}
