using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class FarmingLand : MonoBehaviour
    {
        public GameObject select;
        
        public GameObject chillieGameObject;

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

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Chillie SeedBag")
            {
                Debug.Log("Chillie");
                Destroy(chillieGameObject);
            }
        }
    }
}

