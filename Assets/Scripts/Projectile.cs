using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float _forceSpeed;

    private void Start()
    {
        body.AddForce(transform.right * _forceSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision detected");
        Destroy(this.gameObject);
        //StartCoroutine(DisableDelay());
    }

    IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(.2f);

        //Destroy(this.gameObject);
    }
}
