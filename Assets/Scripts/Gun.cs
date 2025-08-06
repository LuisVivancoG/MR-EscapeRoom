using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _spawnLoc;
    [SerializeField] private float _timeCD = 1f;

    private bool _cooldown = true;
    public bool _canShoot = false;

    private void Update()
    {
        if (_canShoot)
        {
            var value = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
            if(value >= .1f && _cooldown)
            {
                _cooldown = false;
                StartCoroutine(ShootBullet());
            }
        }
    }

    IEnumerator ShootBullet()
    {
        var bullet = Instantiate(_prefab, _spawnLoc.transform.position, _spawnLoc.transform.rotation);

        yield return new WaitForSeconds(_timeCD);

        _cooldown = true;
    }

    public void EnableShooting()
    {
        _canShoot = true;
    }

    public void DisableShooting()
    {
        _canShoot = false;
    }
}
