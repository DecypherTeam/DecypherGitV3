using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class FarmingLand3 : MonoBehaviour
    {
        public GameObject select;

        void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                select.SetActive(true);
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                select.SetActive(false);
            }
        }
    }
}

