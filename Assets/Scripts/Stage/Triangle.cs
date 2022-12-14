using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    private float time = 0;//三角形を回すためのカウンター
    private Transform _transform;
    [SerializeField] private SpriteRenderer sprire;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.IsPause)
        {
            sprire.enabled = false;
        }
        else
        {
            sprire.enabled = true;
            time += (Time.deltaTime * 4);
            _transform.rotation = Quaternion.Euler(0, 90 * Mathf.Sin(time), 0);
            if (time > Mathf.PI)
            {
                time -= Mathf.PI;
            }
        }
    }
}
