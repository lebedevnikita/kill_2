using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_broken_war_to_list : MonoBehaviour {



    //public Vector3[,] default_position = new Vector3[2, 3];
    public  List<Vector3> default_position = new List<Vector3>();
    public  List<Quaternion> default_rotation = new List<Quaternion>();
    public int i;
    public float time_to_not_active_base;
    private float time_to_not_active;
    private List<GameObject> broken_war1_list;

    // Use this for initialization
    void Awake()
    {
        broken_war1_list = GameObject.Find("Player").GetComponent<shooting_create_bullets>().broken_war1_list;
        transform.position = new Vector3(0, 0, 0);
        i=0;
        foreach (Transform child in transform)
        {
            i++;
            default_position.Add(child.position);
            default_rotation.Add(child.rotation);
        }

        time_to_not_active = time_to_not_active_base;

    }


   


        void Update()
    {

        time_to_not_active = time_to_not_active - Time.deltaTime;
        //aDebug.Log(time_to_not_active.ToString());

        if (time_to_not_active < 0)
        {
            transform.position = new Vector3(0, 0, 0);
            i = 0;
            foreach (Transform child in transform)
            {

                child.position = default_position[i];
                child.rotation = default_rotation[i];

                i++;
            }
            
           
            broken_war1_list.Add(gameObject);
            gameObject.SetActive(false);
            time_to_not_active = time_to_not_active_base;
        }

    }




    


}
