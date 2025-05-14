using Assets.Scripts.Dialogue;
using UnityEngine;

public class RealityBoxScript : ClickHandler
{
    public AudioClip openSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void DoToWork()
    {
         if (flowIdx == 1)
        {
            //바닥의판자
            DialogueController.Instance.PlayDialogue(dialogueData[0]);
            _zoomTarget.ZoomRequset();
            _zoomTarget._selectButtonController.SwithchAllButtonStatus(false);
            //상자 퍼즐 진행 성공했다 치고
            flowIdx++;
        }
        else if (flowIdx == 2)
        {
            //상자가열렷다
            DialogueController.Instance.PlayDialogue(dialogueData[1]);
            _soundController.StartEffectBgm(openSFX);
            ChangeSprite(flowIdx);
            flowController.CheckGameObject(gameObject); 
        }
        
    }
}
