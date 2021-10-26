using System.Collections;
using System.Collections.Generic;
using TouchControlsKit;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    public GameObject player;
    public Transform pickUpDest;
    public Rigidbody pickupitem;

    private SphereCollider sc = new SphereCollider();
    private Animator anim = new Animator();
    private bool isPickUp;

    void Start()
    {
        sc = gameObject.GetComponent<SphereCollider>();
        anim = player.GetComponent<Animator>();
        sc.radius = 2.5f;
        isPickUp = false;
    }

    private void Update()
    {
        if (TCKInput.GetAction("pickBtn", EActionEvent.Press))
        {

            if (isPickUp)
            {
                anim.SetBool("isPickup", true);
                transform.position = pickUpDest.position;
                pickupitem.useGravity = false;
                pickupitem.transform.parent = pickUpDest.transform;
                pickupitem.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

        if (TCKInput.GetAction("pickBtn", EActionEvent.Up))
        {
            pickupitem.constraints = RigidbodyConstraints.None;
            anim.SetBool("isPickup", false);
            pickupitem.useGravity = true;
            pickupitem.transform.parent = null;
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
