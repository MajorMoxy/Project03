using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class KeySensor : MonoBehaviour
{
    [SerializeField] private int _keyIndexToSense = 0;
    [SerializeField] private bool _isPersistent;
    public UnityEvent onOneTimeTrigger;
    public UnityEvent persistentTrigger;
    public UnityEvent onPersistentStop;

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

    private void OnTriggerStay(Collider other)
    {
        if (_isPersistent)
        {
            Key keyCheck = other.GetComponent<Key>();
            if (keyCheck != null)
            {
                if (keyCheck.KeyIndex == _keyIndexToSense)
                {
                    persistentTrigger.Invoke();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isPersistent)
        {
            Key keyCheck = other.GetComponent<Key>();
            if (keyCheck != null)
            {
                if (keyCheck.KeyIndex == _keyIndexToSense)
                {
                    onPersistentStop.Invoke();
                }
            }
        }
    }
}
