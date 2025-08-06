using DG.Tweening;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float _cycle;
    [SerializeField] private Ease _easeMode;

    private void Start()
    {
        var fullRot = new Vector3(360, 0, 0);

        transform.DOLocalRotate(fullRot, _cycle, RotateMode.Fast).SetLoops(-1, LoopType.Restart).SetEase(_easeMode);
    }
}
