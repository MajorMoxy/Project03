using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private int _keyIndex = 0;

    public int KeyIndex { get => _keyIndex; private set => _keyIndex = value; }
}
