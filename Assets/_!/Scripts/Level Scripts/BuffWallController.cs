using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffWallController : MonoBehaviour
{
    static public event Action<int> onDamageBuffPickup;

    [SerializeField] private TextMeshProUGUI _text;

    private int[] _buffAmountRange = { -1, +1, +2, };
    private int _buffIndex;
    private int _buffAmount;

    private void Start()
    {
        _buffIndex = UnityEngine.Random.Range(0, 3);
        _buffAmount = _buffAmountRange[_buffIndex];

        if (_buffIndex == 0)
        {
            _text.text = _buffAmount.ToString();
        }
        else
        {
            _text.text = $"+{_buffAmount}";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onDamageBuffPickup?.Invoke(_buffAmount);
            this.gameObject.SetActive(false);
        }
    }
}
