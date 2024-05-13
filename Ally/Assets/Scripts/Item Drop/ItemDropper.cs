using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private ObjType _dropType;
    [SerializeField] [Min(1)] private int _dropCount = 3;
    [SerializeField] private int _dropRandomness = 0;


    public void DropItems()
    {
        int finalDropCount = _dropCount + Random.Range(-_dropRandomness, _dropRandomness);
        for (int i = 0; i < finalDropCount; i++)
        {
            var drop = PoolManager.Instance.Get(_dropType);
            
            drop.gameObject.SetActive(true);
            drop.GetComponent<BaseDropItem>().DeactiveItem();

            drop.transform.position = transform.position + new Vector3(0, Random.Range(0.5f, 1f), 0.5f);

            Vector3 target = transform.position;
            target.x += Random.Range(-1.5f, 1.5f);
            target.z += Random.Range(4.5f, 6.5f);
            drop.transform.DOJump(target, Random.Range(0.7f, 1.3f), 1, Random.Range(0.2f, 0.35f)).OnComplete(() => drop.GetComponent<BaseDropItem>().ActiveItem());
            
            Vector3 targetEuler = drop.transform.eulerAngles;
            targetEuler.y = Random.Range(-180, 180);
            drop.transform.DORotate(targetEuler, 0.2f);
        }
    }
}
