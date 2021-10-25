using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Examples
{
    public class GrowingCrop : MonoBehaviour
    {
        PlantInteraction plantInteraction;

        //public GameObject crop;
        public Rigidbody cropRb;
        public bool harvestReady;
        public bool harvestReadyToPick;
        public bool cropPickedUp;
        public bool playerHit;

        public bool cropDestroyed;

        public float timer = 0f;
        public float growTime = 6f;
        public float maxSize = 2f;

        public bool isMaxSize = false;

        public Transform theDest;

        void Start()
        {
            harvestReady = false;
            harvestReadyToPick = false;
            cropPickedUp = false;

            GameObject theDestination = GameObject.Find("PickUpDestination");
            theDest = theDestination.GetComponent<Transform>();
        }

        void FixedUpdate()
        {
            playerHit = false;

            StartCoroutine(Grow());

            if (isMaxSize == true)
            {
                /*Debug.Log("Plant is ready for harvest");*/
                harvestReady = true;
            }
        }

        private IEnumerator Grow()
        {
            Vector3 startScale = transform.localScale;
            Vector3 maxScale = new Vector3(maxSize, maxSize, maxSize);

            do
            {
                transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
                timer += Time.deltaTime;
                yield return null;
            }
            while (timer < growTime);

            isMaxSize = true;
        }

        public void OnTriggerStay(Collider other)
        {
            if (other.tag == "Player")
            {
                playerHit = true;
            }

            if (harvestReady == true && playerHit == true)
            {
                Debug.Log("Player touch");
                harvestReadyToPick = true;
            }
        }

        public void Player()
        {
            cropRb.transform.position = theDest.position;
            cropRb.transform.parent = theDest.transform;
        }

        /*public void PlayerPickCrop()
        {
            Debug.Log("Player Pick");
            cropRb.useGravity = false;
            cropRb.transform.position = theDest.position;
            cropRb.transform.parent = GameObject.Find("PickUpDestination").transform;
            cropPickedUp = true;
        }*/

        /*public void PlayerDropCrop()
        {
            cropRb.transform.parent = null;
            cropRb.useGravity = true;
        }*/

        public IEnumerator WaitBeforeDestroy()
        {
            yield return new WaitForSeconds(3);
            Destroy(this);
            //Destroy(crop);
            cropDestroyed = true;
            /*Debug.Log("Destroy gameObject");*/
        }
    }
}

