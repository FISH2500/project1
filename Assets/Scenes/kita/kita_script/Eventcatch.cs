using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Eventcatch : MonoBehaviour
{
    public static Eventcatch Instance { get; private set; }

    public bool isHit;

    private void Start()
    {
        if (Instance==null)
        {
            Instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Vending")
        {
            isHit = true;
            UIManager.Instance.SetVendingCheckUI(isHit);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vending")
        {
            isHit = false;
            UIManager.Instance.SetVendingCheckUI(isHit);
        }

    }



}

