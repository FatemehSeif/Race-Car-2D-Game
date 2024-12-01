using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDistance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _distanceText;
    [SerializeField] private Transform _PlayerTrans;     
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = _PlayerTrans.position;
    }

    private void Update()
    {
        Vector2 distance = (Vector2)_PlayerTrans.position - _startPosition;

        _distanceText.text = Mathf.Abs(distance.x).ToString("0");

    }
}
