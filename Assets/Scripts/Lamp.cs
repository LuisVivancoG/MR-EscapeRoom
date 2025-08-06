using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Lamp : MonoBehaviour
{
    [SerializeField] private GameObject _fallingGO;
    [SerializeField] private Vector3 _newPos;
    [SerializeField] private float _cycle;
    [SerializeField] private Ease _easeMode;

    [SerializeField] private UnityEvent _onBroken;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Projectile>(out Projectile bullet))
        {
            _fallingGO.transform.DOMove(_newPos, _cycle).SetEase(_easeMode);

            _onBroken?.Invoke();
        }
    }
}
