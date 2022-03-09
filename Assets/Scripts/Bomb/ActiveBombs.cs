using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ActiveBombs : MonoBehaviour
{
    [SerializeField] private List<GameObject> _activeBombs;

    private void Awake()
    {
        GameServicesProvider.instance.Register(this);
    }

    private void Start()
    {
        _activeBombs = new List<GameObject>();
    }

    private void OnDisable()
    {
        GameServicesProvider.instance.Unregister(this);
    }

    public List<GameObject> GetActiveBombs()
    {
        return _activeBombs;
    }

    public void AddBomb(GameObject bomb)
    {
        _activeBombs.Add(bomb);
    }

    public void DestroyBomb(GameObject bomb)
    {
        _activeBombs.Remove(bomb);
        Destroy(bomb);
    }
}
