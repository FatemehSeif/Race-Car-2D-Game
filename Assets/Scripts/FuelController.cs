using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FuelController : MonoBehaviour
{

    public static FuelController instance;

    [SerializeField] private Image _fuelImage;
    [SerializeField, Range(0.1f, 5f)] private float _fuelDrainSpeed = 1f;
    [SerializeField] private float _maxFuelAmount = 100f;
   

    [SerializeField] private Gradient _fuelGradient;

    private float _currentFuelAmount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("FuelController instance initialized.");
        }
        else
        {
            Debug.LogError("Duplicate FuelController instance detected!");
        }
    }


    private void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        if (GameManager.instance.CurrentState == GameState.Playing)
        {
            if (_currentFuelAmount > 0)
            {
                _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;
                UpdateUI();
            }
            else
            {
                GameManager.instance.GameOver(); 
            }
        }
    }

    private void UpdateUI()
    {
        _fuelImage.fillAmount = (_currentFuelAmount / _maxFuelAmount);
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }
    public void FillFuel()
    {
        _currentFuelAmount = _maxFuelAmount; 
        UpdateUI(); 
    }

}
