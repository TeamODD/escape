using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealityFlowerPotScript : ClickHandler
{

    public ZoomImage zoomImage;
    private bool _isRequestItem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
        
        if (flowIdx == 1)
        {
            //햇빛을 양껏..
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            _isRequestItem = true;
           
            flowIdx++;

        }
    }

    public void GetLeaf()
    {
        if (_isRequestItem)
        {
            
       
        zoomImage.OnHide();
        flowController.CheckGameObject(gameObject);
        _isRequestItem = false;
        }
    }
}
