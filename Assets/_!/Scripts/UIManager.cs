using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _weaponPowerText;
    private int _score = 0;
    private int _weaponPower = 1;


    private void OnEnable()
    {
        CollectibleController.onCoinPickup += AddScoreText;
        BuffWallController.onDamageBuffPickup += AddDamageText;
    }
    private void Start()
    {
        _scoreText.text = $"Score: {_score}";
        _weaponPowerText.text = $"Weapon Power: {_weaponPower}";
    }

    private void AddScoreText(int coinValue)
    {
        _score += coinValue;
        _scoreText.text = $"Score: {_score}";
    }
    private void AddDamageText(int buffValue)
    {
        _weaponPower += buffValue;
        _weaponPowerText.text = $"Weapon Power: {_weaponPower}";
    }

    private void OnDisable()
    {
        CollectibleController.onCoinPickup -= AddScoreText;
        BuffWallController.onDamageBuffPickup -= AddDamageText;

    }


}
