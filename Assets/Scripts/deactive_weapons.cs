using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactive_weapons : MonoBehaviour {


    private float _delta;
    public float _delta_base;

    void OnEnable()
    {
        _delta= _delta_base;
    }

    void Update () {
        _delta = _delta - Time.deltaTime;
        if (_delta < 0)
        {
            gameObject.SetActive(false);
            _delta = _delta_base;
        }

    }
}
