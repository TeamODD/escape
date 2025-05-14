using UnityEngine;
using Assets.Scripts.Animators;
using DG.Tweening; // MoveAnimator가 이 네임스페이스에 있음

public class BallMover : MonoBehaviour
{
    [Header("공 오브젝트")]
    [SerializeField] private GameObject selectedBall;

    [Header("이동 애니메이터 (상하좌우)")]
    [SerializeField] private MoveAnimator upAnimator;
    [SerializeField] private MoveAnimator downAnimator;
    [SerializeField] private MoveAnimator leftAnimator;
    [SerializeField] private MoveAnimator rightAnimator;

    private bool isMoving = false;

    /// <summary>
    /// 공을 지정한 방향으로 이동시킵니다.
    /// </summary>
    /// <param name="direction">이동 방향 (Vector2.up, down, left, right)</param>
    public void MoveBall(Vector2 direction)
    {
        if (isMoving || selectedBall == null) return;

        MoveAnimator animator = GetAnimatorByDirection(direction);
        if (animator == null) return;
        
        Vector3 targetPosition = selectedBall.transform.position;
        targetPosition.z = 5f; // Z값을 5로 고정

        // 애니메이터를 공 위치로 옮기고 활성화
        Transform animatorTransform = animator.transform;
        animatorTransform.position = selectedBall.transform.position;
        animator.gameObject.SetActive(true);

        // 기존 이벤트 제거 (중복 방지)
        animator.OnStartEvent.RemoveAllListeners();
        animator.OnCompleteEvent.RemoveAllListeners();

        // 애니메이션 시작 시 퍼즐 입력 비활성화
        animator.OnStartEvent.AddListener(() =>
        {
            isMoving = true;
        });

        // 애니메이션 종료 시 실제 공 이동 처리 및 입력 활성화
        animator.OnCompleteEvent.AddListener(() =>
        {
            selectedBall.transform.position = animatorTransform.position;
            animator.gameObject.SetActive(false);
            isMoving = false;
        });

        animator.PlayAnimation();
    }

    public float moveDuration = 0.3f;

    public void MoveTo(Vector3 targetPosition)
    {
        targetPosition.z = -5f;
        transform.DOMove(targetPosition, moveDuration).SetEase(Ease.InOutQuad).Play();
    }

    /// <summary>
    /// 방향에 따라 적절한 MoveAnimator를 반환합니다.
    /// </summary>
    private MoveAnimator GetAnimatorByDirection(Vector2 direction)
    {
        if (direction == Vector2.up) return upAnimator;
        if (direction == Vector2.down) return downAnimator;
        if (direction == Vector2.left) return leftAnimator;
        if (direction == Vector2.right) return rightAnimator;
        return null;
    }
}
