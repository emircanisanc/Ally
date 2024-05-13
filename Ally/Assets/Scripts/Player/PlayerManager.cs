using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Emir
{
    public class PlayerManager : MonoBehaviour
    {
        public void Die()
        {
            Debug.Log("GAME OVER");
            Debug.Break();
        }
    }
}