using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private Transform _dropPF;
    [SerializeField] [Min(1)] private int _dropCount = 3;
    [SerializeField] private int _dropRandomness = 0;

    private List<Transform> _dropList;

    private void Awake()
    {
        _dropList = new List<Transform>();
        int finalDropCount = _dropCount + Random.Range(-_dropRandomness, _dropRandomness);
        for (int i = 0; i < finalDropCount; i++)
        {
            Transform drop = Instantiate(_dropPF);
            drop.gameObject.SetActive(false);
            _dropList.Add(drop);
        }
    }

    public void DropItems()
    {
        foreach (Transform drop in _dropList)
        {
            Vector3 target = transform.position;
            target.x += Random.Range(-3.5f, 3.5f);
            target.z += Random.Range(2f, 4f);
            drop.DOJump(target, Random.Range(0.7f, 1.3f), 1, Random.Range(0.2f, 0.35f));
        }
    }
}