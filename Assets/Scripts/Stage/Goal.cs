using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject DeliverBoxSprite;
    public GameObject GetDeliverBoxSprite()
    {
        return DeliverBoxSprite;
    }

    [SerializeField] private GameObject Triangle;
    private bool isMoveTriangle;
    public bool IsMoveTriangle
    {
        get
        {
            return this.isMoveTriangle;
        }
        set
        {
            this.isMoveTriangle = value;
            if (isMoveTriangle)
            {
                Triangle.SetActive(true);
            }
            else
            {
                Triangle.SetActive(false);
            }
        }
    }
}
