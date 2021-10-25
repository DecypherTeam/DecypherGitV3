using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

namespace Examples
{
    public class ObjectPickUp : MonoBehaviour
    {
        public GameObject player;
        public Transform pickUpDest;

        private SphereCollider sc = new SphereCollider();
        private Animator anim = new Animator();
        private bool isPickUp;

        void Start()
        {
            sc = gameObject.GetComponent<SphereCollider>();
            anim = player.GetComponent<Animator>();
            sc.radius = 1.5f;
            isPickUp = false;
        }

        private void Update()
        {
            if (TCKInput.GetAction("pickBtn", EActionEvent.Press))
            {
                anim.SetBool("isPickup", true);

                if (isPickUp)
                {
                    transform.position = pickUpDest.position;
                }
            }

            if (TCKInput.GetAction("pickBtn", EActionEvent.Up))
            {
                anim.SetBool("isPickup", false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            togglePickUp(other);
        }

        private void OnTriggerExit(Collider other)
        {
            togglePickUp(other);
        }

        private void togglePickUp(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                isPickUp = !isPickUp;
            }
        }
    }

}

