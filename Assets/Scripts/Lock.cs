using Oculus.Interaction;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    public UnityEvent OnUnlocked;
    public UnityEvent OnWrongKey;
    public Key targetKey;

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Object found {collision.transform.name}", this);

        if (collision.gameObject.tag == "Key")
        {
            Debug.Log("Key found");
            Unlock();
        }

        else
        {
            return;
            //Debug.Log($"The object is NOT a key", this);
        }
    }*/

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Object found {other.transform.name}", this);
        if (other.TryGetComponent<Key>(out Key incomingKey))
        {
            if (targetKey != null)
            {
                if (targetKey == incomingKey)
                {
                    Unlock();
                }
                else
                {
                    OnWrongKey.Invoke();
                }
            }
            else
            {
                Unlock();
            }
        }
        else
        {
            Debug.Log($"The object is NOT a key", this);
        }
    }

    private void Unlock()
    {
        Debug.Log("Lock Open", this);
        OnUnlocked.Invoke();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(targetKey != null){

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, targetKey.transform.position);
        }
        
    }
#endif

}
