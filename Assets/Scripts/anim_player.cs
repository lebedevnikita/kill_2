using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim_player : MonoBehaviour {
    Animator animator;
    // Use this for initialization
    private Transform _player_transform;
    void Start () {
        animator = GetComponent<Animator>();
        _player_transform = GameObject.Find("Player").transform;
    }

    
    private float vv;
    private float v =1f;
    private float h;
    // Update is called once per frame
    void Update () {
        animator.SetFloat("stay", 0);
        animator.SetFloat("forvard", 0);
        animator.SetFloat("side_right", 0);
        animator.SetFloat("side_left", 0);

        /* if (Input.GetAxis("Vertical") != 0)
         { h = Input.GetAxis("Vertical"); }
                     else {  animator.SetFloat("stay", 1.0f);h = Input.GetAxis("Horizontal"); }*/

        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0) { animator.SetFloat("stay", 1); } 
        if (Input.GetAxis("Vertical") != 0 && (Mathf.Abs(_player_transform.rotation.y)<0.2f || Mathf.Abs(_player_transform.rotation.y) > 0.8f)) {animator.SetFloat("forvard", 1);}
        if (Input.GetAxis("Vertical") != 0 && (Mathf.Abs(_player_transform.rotation.y) >= 0.2f && Mathf.Abs(_player_transform.rotation.y) <= 0.8f)) { animator.SetFloat("side_right", 1); }


        if (Input.GetAxis("Horizontal") != 0 && (Mathf.Abs(_player_transform.rotation.y) < 0.2f || Mathf.Abs(_player_transform.rotation.y) > 0.8f)) { animator.SetFloat("side_right", 1); }
        if (Input.GetAxis("Horizontal") != 0 && (Mathf.Abs(_player_transform.rotation.y) >= 0.2f && Mathf.Abs(_player_transform.rotation.y) <= 0.8f)) { animator.SetFloat("forvard", 1); }

        // if (Input.GetAxis("Horizontal") > 0 ) { animator.SetFloat("side_right", 1); } 
        // if (Input.GetAxis("Horizontal") < 0) { animator.SetFloat("side_left", 1); } 




        //animator.SetFloat("forvard", 1.0f);

        /* animator.SetFloat("forvard", Input.GetAxis("Vertical"));
         animator.SetFloat("side", Input.GetAxis("Horizontal"));
         animator.SetFloat("rotate", _player_transform.rotation.y);*/



        /*
         vv = Input.mousePosition.y;
        if (vv != v) { animator.SetFloat("rotate", 1); } else { animator.SetFloat("rotate", 0); }

        v = Input.mousePosition.y;*/





        /*Debug.Log("v" + Input.GetAxis("Vertical").ToString()+
                        "v" + Input.GetAxis("Horizontal").ToString()+
                        "rot" +_player_transform.rotation.y.ToString());*/
    

    }
}
