using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 1f;

    public bool isMaxSize = false;

    public bool harvestReady;
    public bool harvestReadyToPick;
    public GameObject crop;
    public Rigidbody cropRb;
    public Transform theDest;

    void Start()
    {
        harvestReady = false;
        harvestReadyToPick = false;

        GameObject theDestination = GameObject.Find("PickUpDestination");
        theDest = theDestination.GetComponent<Transform>();

        if (isMaxSize == false)
        {
            StartCoroutine(Grow());
        }
    }

    void Update()
    {
        if(isMaxSize == true)
        {
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
        if (other.tag == "Player" && harvestReady == true)
        {
            Debug.Log("Player hit");
            harvestReadyToPick = true;
        }
    }

    /*public void PlayerPickUp()
    {
        cropRb.useGravity = false;
        cropRb.transform.position = theDest.position;
        cropRb.transform.parent = theDest.transform;
    }*/
}
