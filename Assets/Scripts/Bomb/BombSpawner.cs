using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bombPrefab;
    [SerializeField] private Button _button;

    private ActiveBombs _activeBombs;
    
    private void Start()
    {
        _button.onClick.AddListener(SpawnBomb);
        _activeBombs = GameServicesProvider.instance.GetService<ActiveBombs>();
    }

    private void SpawnBomb()
    {
        GameObject bomb = Instantiate(_bombPrefab, transform.position, Quaternion.identity, _activeBombs.transform);
        _activeBombs.AddBomb(bomb);
    }
}