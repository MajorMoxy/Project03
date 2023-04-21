using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class KeySensor : MonoBehaviour
{
    [SerializeField] private int _keyIndexToSense = 0;
    [SerializeField] private bool _isPersistant;
    public UnityEvent onOneTimeTrigger;
    public UnityEvent persistantTrigger;
    public UnityEvent onPersistantStop;

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
        if (_isPersistant)
        {
            Key keyCheck = other.GetComponent<Key>();
            if (keyCheck != null)
            {
                if (keyCheck.KeyIndex == _keyIndexToSense)
                {
                    persistantTrigger.Invoke();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_isPersistant)
        {
            Key keyCheck = other.GetComponent<Key>();
            if (keyCheck != null)
            {
                if (keyCheck.KeyIndex == _keyIndexToSense)
                {
                    onPersistantStop.Invoke();
                }
            }
        }
    }
}
