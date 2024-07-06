using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Emir
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private ObjType _dropGoldType;

        private void Start()
        {
            GameManager.Instance.OnGameStarted += SetWeaponVisual;
        }

        private void OnDisable()
        {
            if (GameManager.Instance)
                GameManager.Instance.OnGameStarted -= SetWeaponVisual;
        }

        private void SetWeaponVisual()
        {
            WeaponInventoryManager.Instance.CurrentWeapon.transform.SetParent(transform);
        }

        private bool isDead;

        public void Die()
        {
            if (isDead) return;

            isDead = true;
            GameManager.Instance.GameOver();
        }

        public void Hit()
        {
            int dropGoldCount = Random.Range(3, 6);
            // REDUCE MONEY
            for (int i = 0; i < dropGoldCount; i++)
            {
                var drop = PoolManager.Instance.Get(_dropGoldType);
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
}