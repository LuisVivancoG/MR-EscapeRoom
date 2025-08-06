using DG.Tweening;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    [SerializeField] private Vector3 _newPos;
    [SerializeField] private Vector3 _newRot;
    [SerializeField] private float _cycle;

    public void Thrownd()
    {
        transform.DOMove(_newPos, _cycle);
        transform.DORotate(_newRot, _cycle);
    }
}
