using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class Game : MonoBehaviour
    {
        Growth growth;
        public bool harvestChillie;

        // Start is called before the first frame update
        void Start()
        {
            GameObject crop = GameObject.Find("Chillie Crop");
            growth = crop.GetComponent<Growth>();
        }

        // Update is called once per frame
        void Update()
        {
            if (GameObject.Find("Chillie Crop") && growth.harvestReadyToPick == true)
            {
                harvestChillie = true;
                Debug.Log("player can pick up crop now");
            }
        }
    }
}

