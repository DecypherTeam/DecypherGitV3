using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class SeedCollider : MonoBehaviour
    {
        Player player;
        public Rigidbody chillieSeedBag;
        public Transform pickUpDest;

        public bool playerTouchSeed;

        void Start()
        {
            GameObject thePlayer = GameObject.Find("Player");
            player = thePlayer.GetComponent<Player>();
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                playerTouchSeed = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                playerTouchSeed = false;
            }
        }

        public void PickUp()
        {
            // Coding the pickable items to be carried
            chillieSeedBag.useGravity = false;
            chillieSeedBag.transform.position = pickUpDest.position;
            chillieSeedBag.transform.parent = GameObject.Find("PickUpDestination").transform;
        }   

        public void PickDown()
        {
            chillieSeedBag.transform.parent = null;
            chillieSeedBag.useGravity = true;
        }
    }
}
