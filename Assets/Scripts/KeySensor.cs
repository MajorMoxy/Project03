using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class KeySensor : MonoBehaviour
{
    [SerializeField] private int _keyIndexToSense = 0;
    public UnityEvent onOneTimeTrigger;

    private void OnTriggerEnter(Collider other)
    {
        Key keyCheck = other.GetComponent<Key>();
        if (keyCheck != null)
        {
            if (keyCheck.KeyIndex == _keyIndexToSense)
            {
                onOneTimeTrigger.Invoke();
            }
        }

    }
}
