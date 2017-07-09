using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class MovePlayer : MonoBehaviour {
    public GameObject player;
    public int speed;

    public GameObject _endPoint;
    private Quaternion player_current_Quaternion;

    public bool is_pause_OFF = true; //условие паузы
    private List<GameObject> weapon_list;

    private string _up;
    private string _down;
    private string _left;
    private string _right;

    private string _up_alt;
    private string _down_alt;
    private string _left_alt;
    private string _right_alt;


    //private string _fire;
    //private string _reload;

    public GameObject _up_buton;
    public GameObject _down_buton;
    public GameObject _left_buton;
    public GameObject _right_buton;

    public GameObject _up_buton_alt;
    public GameObject _down_buton_alt;
    public GameObject _left_buton_alt;
    public GameObject _right_buton_alt;
    //public GameObject _fire_buton;
    //public GameObject _reload_buton;

    // public KeyCode current;


    private bool _up_change;
    private bool _down_change;
    private bool _left_change;
    private bool _right_change;



    private float ange_rotate;

    void Start()
    {

        weapon_list = GameObject.Find("_game").GetComponent<Create_warriors>().weapon_list;

        _up= PlayerPrefs.GetString(_up_buton.name.ToString()); 
        _down = PlayerPrefs.GetString(_down_buton.name.ToString());
        _left = PlayerPrefs.GetString(_left_buton.name.ToString());
        _right = PlayerPrefs.GetString(_right_buton.name.ToString());

        _up_alt = PlayerPrefs.GetString(_up_buton_alt.name.ToString());
        _down_alt = PlayerPrefs.GetString(_down_buton_alt.name.ToString());
        _left_alt = PlayerPrefs.GetString(_left_buton_alt.name.ToString());
        _right_alt = PlayerPrefs.GetString(_right_buton_alt.name.ToString());

        //_fire = PlayerPrefs.GetString(_fire_buton.name.ToString());
        //_reload = PlayerPrefs.GetString(_reload_buton.name.ToString());


        /*Debug.Log(_up);
        Debug.Log(_down);
        Debug.Log(_left);
        Debug.Log(_right);
        Debug.Log(_fire);
        Debug.Log(_reload);*/



       

    }


void Update()
    {





     







        if (Input.GetKey(_up)) { _up_change = true; } else 
                                                 if (_up_alt.Substring(0, 1) == "+" && Input.GetAxis(_up_alt.Replace(_up_alt.Substring(0, 1), "")) > 0) { _up_change = true; } else
                                                 if (_up_alt.Substring(0, 1) == "-" && Input.GetAxis(_up_alt.Replace(_up_alt.Substring(0, 1), "")) < 0) { _up_change = true; } else { _up_change = false; }
        if (Input.GetKey(_down)) { _down_change = true; } else
                                                 if (_down_alt.Substring(0, 1) == "+" && Input.GetAxis(_down_alt.Replace(_down_alt.Substring(0, 1), "")) > 0) { _down_change = true; } else
                                                 if (_down_alt.Substring(0, 1) == "-" && Input.GetAxis(_down_alt.Replace(_down_alt.Substring(0, 1), "")) < 0) { _down_change = true; } else { _down_change = false; }
        if (Input.GetKey(_left)) { _left_change = true; } else
                                                    if (_left_alt.Substring(0, 1) == "+" && Input.GetAxis(_left_alt.Replace(_left_alt.Substring(0, 1), "")) > 0) { _left_change = true; } else
                                                    if (_left_alt.Substring(0, 1) == "-" && Input.GetAxis(_left_alt.Replace(_left_alt.Substring(0, 1), "")) < 0) { _left_change = true; } else { _left_change = false; }
        if (Input.GetKey(_right)) { _right_change = true; } else
                                                                if (_right_alt.Substring(0, 1) == "+" && Input.GetAxis(_right_alt.Replace(_right_alt.Substring(0, 1), "")) > 0) { _right_change = true; } else
                                                                if (_right_alt.Substring(0, 1) == "-" && Input.GetAxis(_right_alt.Replace(_right_alt.Substring(0, 1), "")) < 0) { _right_change = true; } else { _right_change = false; }

        //Debug.Log(Input.GetAxis(_up_alt.Replace(_up_alt.Substring(0, 1), "")));
        /*
                if (_up_alt.Substring(0,1)=="+" && Input.GetAxis(_up_alt) > 0) { _up_change = true; } else { _up_change = false; }
                if (_up_alt.Substring(0, 1) == "-" && Input.GetAxis(_up_alt) < 0) { _up_change = true; } else { _up_change = false; }
                if (_down_alt.Substring(0, 1) == "+" && Input.GetAxis(_down_alt) > 0) { _down_change = true; } else { _down_change = false; }
                if (_down_alt.Substring(0, 1) == "-" && Input.GetAxis(_down_alt) < 0) { _down_change = true; } else { _down_change = false; }
                if (_left_alt.Substring(0, 1) == "+" && Input.GetAxis(_left_alt) > 0) { _left_change = true; } else { _left_change = false; }
                if (_left_alt.Substring(0, 1) == "-" && Input.GetAxis(_left_alt) < 0) { _left_change = true; } else { _left_change = false; }
                if (_right_alt.Substring(0, 1) == "+" && Input.GetAxis(_right_alt) > 0) { _right_change = true; } else { _right_change = false; }
                if (_right_alt.Substring(0, 1) == "-" && Input.GetAxis(_right_alt) < 0) { _right_change = true; } else { _right_change = false; }

        */

        //поворот игрока клава
        if (is_pause_OFF)
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
           
            dir.Normalize();
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
            // как вариат transform.LookAt(Input.mousePosition);

        }

        //движение игрока
        var position = player.transform.position;
        var x = position.x;
        var y = position.y;
        var z = position.z;


        //поворот игрока геймпад
        Vector3 lookAt = Vector3.zero;
        float horInput1 = Input.GetAxis("Axis 3");
        float vertInput1 = -Input.GetAxis("Axis 4");
        if (horInput1 != 0 || vertInput1 != 0)
        {
            lookAt.x = horInput1;
            lookAt.z = vertInput1;
            Quaternion direction = Quaternion.LookRotation(lookAt);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                                                 direction, 8 * Time.deltaTime);
        }

        



        /*  if (Input.GetAxis("Axis 4") == -1 && Input.GetAxis("Axis 3") == 0) { ange_rotate = 0; }
          else if (Input.GetAxis("Axis 4") == 1 && Input.GetAxis("Axis 3") == 0) { ange_rotate = 180; }
          else if (Input.GetAxis("Axis 4") == 0 && Input.GetAxis("Axis 3") == 1) { ange_rotate = 90; }
          else if (Input.GetAxis("Axis 4") == 0 && Input.GetAxis("Axis 3") == -1) { ange_rotate = 270; }

          else if (Input.GetAxis("Axis 4") == -1 && Input.GetAxis("Axis 3") == 1) { ange_rotate = 45; }
          else if (Input.GetAxis("Axis 4") == 1 && Input.GetAxis("Axis 3") == 1) { ange_rotate = 135; }
          else if (Input.GetAxis("Axis 4") == 1 && Input.GetAxis("Axis 3") == -1) { ange_rotate = 225; }
          else if (Input.GetAxis("Axis 4") == -1 && Input.GetAxis("Axis 3") == -1) { ange_rotate = 270; }

          else { ange_rotate = Mathf.Tan(Input.GetAxis("Axis 3") / -Input.GetAxis("Axis 4")) * Mathf.Rad2Deg; }
          //Mathf.Tan(Input.GetAxis("Axis 4") / Input.GetAxis("Axis 3")) * Mathf.Rad2Deg;*/


        ///transform.rotation = Quaternion.Euler(0, ange_rotate, 0);
        
        //transform.rotation = Quaternion.Euler(0, Mathf.Sin(Input.GetAxis("Axis 4")) * Mathf.Rad2Deg, 0);
        //Debug.Log(//Mathf.Tan(Input.GetAxis("Axis 4") / Input.GetAxis("Axis 3")) * Mathf.Rad2Deg
 //Mathf.Tan(Input.GetAxis("Axis 3") / -Input.GetAxis("Axis 4")) * Mathf.Rad2Deg + "Axis 3 " + Input.GetAxis("Axis 3").ToString() + "Axis 4 " + Input.GetAxis("Axis 4").ToString()
//(180*0.5f / 0.7f ) / Mathf.PI + " " + (0.5f / 0.7f).ToString() +" " + (0.5f / 0.7f *Mathf.Rad2Deg).ToString()


//);//



        if ( (_up_change)  && is_pause_OFF)
        {

            if ((_right_change) && is_pause_OFF) { player.transform.position = new Vector3(x + Mathf.Sqrt(speed*speed / 2) * Time.deltaTime, y, z + Mathf.Sqrt(speed*speed / 2) * Time.deltaTime); }
            else {
                if ((_left_change) && is_pause_OFF)
                {
                    player.transform.position = new Vector3(x - Mathf.Sqrt(speed*speed / 2) * Time.deltaTime, y, z + Mathf.Sqrt(speed*speed / 2) * Time.deltaTime);
                }
                else { player.transform.position = new Vector3(x, y, z + speed * Time.deltaTime); }

            }

            

        }

        else {
                if (((_down_change) ) && is_pause_OFF)
                {

                    if ((_right_change) && is_pause_OFF) { player.transform.position = new Vector3(x + Mathf.Sqrt(speed*speed / 2) * Time.deltaTime, y, z - Mathf.Sqrt(speed*speed / 2) * Time.deltaTime); }
                    else {
                    if ((_left_change) && is_pause_OFF) { player.transform.position = new Vector3(x - Mathf.Sqrt(speed*speed / 2) * Time.deltaTime, y, z - Mathf.Sqrt(speed*speed / 2) * Time.deltaTime); }
                    else { player.transform.position = new Vector3(x, y, z - speed * Time.deltaTime); }
                }





            }
            else
                {
                if ((_right_change) && is_pause_OFF)
                {

                    player.transform.position = new Vector3(x + speed * Time.deltaTime, y, z);

                }
                else {
                    if ((_left_change) && is_pause_OFF)
                    {

                        player.transform.position = new Vector3(x - speed * Time.deltaTime, y, z);

                    }
                }
            }
            }


        /*базовые движения*/
        /* if (Input.GetKey(_up) || Input.GetKey(KeyCode.UpArrow))
         {
             player.transform.position = new Vector3(x, y, z + speed * Time.deltaTime);
         }


         if (Input.GetKey(_down) || Input.GetKey(_rightownArrow))
         {
             player.transform.position = new Vector3(x , y, z - speed * Time.deltaTime);
         }
         if (Input.GetKey(_left) || Input.GetKey(KeyCode.LeftArrow))
         {
             player.transform.position = new Vector3(x - speed * Time.deltaTime, y , z);
         }

        if (Input.GetKey(_right) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position = new Vector3(x + speed * Time.deltaTime, y , z);
        }
        */

    }






    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "warrior")
        {
            //SceneManager.UnloadSceneAsync("level1");
            SceneManager.LoadScene("scene_GameOver");
        }

      /*  else
        if (other.tag == "anyWeapon")
        {
            //player.SetActive(false);
            _endPoint.transform.position = player.transform.position; 
            player_current_Quaternion = player.transform.rotation;
            player.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); // обнуляем дистанию полета патронов, для упрощения расчета дистанции

            if (other.name == "weapon_pistol")
            {
                player.GetComponent<shooting_create_bullets>().bullet_list_all_on_player = player.GetComponent<shooting_create_bullets>().bullet_list_all_pistol;
                player.GetComponent<shooting_create_bullets>().bullet_list_on_player = player.GetComponent<shooting_create_bullets>().bullet_list_pistol;
                player.GetComponent<shooting_create_bullets>()._sound_on_player_shot = player.GetComponent<shooting_create_bullets>()._sound_pistol_shot;
                player.GetComponent<shooting_create_bullets>().deltaTime_bullet_on_player_basic = player.GetComponent<shooting_create_bullets>().deltaTime_bullet_pistol;


                _endPoint.transform.position = player.transform.position + new Vector3(0, 0, 40);
                


            }

            else

            if (other.name == "weapon_shotgun")
            {
                player.GetComponent<shooting_create_bullets>().bullet_list_all_on_player = player.GetComponent<shooting_create_bullets>().bullet_list_all_shotgun;
                player.GetComponent<shooting_create_bullets>().bullet_list_on_player = player.GetComponent<shooting_create_bullets>().bullet_list_shotgun;
                player.GetComponent<shooting_create_bullets>()._sound_on_player_shot = player.GetComponent<shooting_create_bullets>()._sound_shotgun_shot;
                player.GetComponent<shooting_create_bullets>().deltaTime_bullet_on_player_basic = player.GetComponent<shooting_create_bullets>().deltaTime_bullet_shotgun;

                _endPoint.transform.position = player.transform.position + new Vector3(0, 0, 35);
              
            }
            else

            if (other.name == "weapon_automat")
            {
                player.GetComponent<shooting_create_bullets>().bullet_list_all_on_player = player.GetComponent<shooting_create_bullets>().bullet_list_all_automat;
                player.GetComponent<shooting_create_bullets>().bullet_list_on_player = player.GetComponent<shooting_create_bullets>().bullet_list_automat;
                player.GetComponent<shooting_create_bullets>()._sound_on_player_shot = player.GetComponent<shooting_create_bullets>()._sound_automat_shot;
                player.GetComponent<shooting_create_bullets>().deltaTime_bullet_on_player_basic = player.GetComponent<shooting_create_bullets>().deltaTime_bullet_automat;

                _endPoint.transform.position = player.transform.position + new Vector3(0, 0, 45);


                if (player.GetComponent<shooting_create_bullets>().bullet_list_all_on_player == player.GetComponent<shooting_create_bullets>().bullet_list_all_automat)
                {
                    
                    player.GetComponent<shooting_create_bullets>().add_bullet_array(30, player.GetComponent<shooting_create_bullets>()._bullet_automat_prefab, player.GetComponent<shooting_create_bullets>().bullet_list_all_automat);
                    player.GetComponent<shooting_create_bullets>().reload_weapons(player.GetComponent<shooting_create_bullets>().bullet_list_all_automat, player.GetComponent<shooting_create_bullets>().bullet_list_automat);
                }
                else {
                    player.GetComponent<shooting_create_bullets>().bullet_list_all_automat.Clear();
                }





            }







            player.transform.rotation = player_current_Quaternion;//возвращаем угол поворота игрока
            player.GetComponent<shooting_create_bullets>().deltaTime_bullet_on_player = -1;//после поднятия оружия задержка на выстрел сбрасывается

            
            other.gameObject.SetActive(false);
            weapon_list.Add(other.gameObject);

        }*/

    }


}
