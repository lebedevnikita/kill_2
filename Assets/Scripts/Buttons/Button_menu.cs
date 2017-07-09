using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class Button_menu : MonoBehaviour {

    
    public GameObject[] array_warraiors;
    public GameObject[] array_bullets;
    public List<GameObject> list_active_obj_for_pause = new List<GameObject>();
    private int i;
   // public bool is_pause_OFF = true; //условие паузы
    public GameObject _menu ;
    public GameObject _menu_control;
    public GameObject _button_options;
    public Texture _img_on;
    public Texture _img_off;
    public Slider _volume;
    public Button _Button_volume_ON_OFF ;


    void Start()
    {
        //сразу скрываем меню
       // _menu = GameObject.Find("menu");
        _menu.SetActive(false);

       // _menu_control = GameObject.Find("menu_control");
        _menu_control.SetActive(false);
    }

   

   public  void Quit()
    {

        Application.Quit();
    }


    void OnGUI()
    {
        //Debug.Log(Input.GetAxis("Axis 5").ToString());
        
        // GameObject.Find("qqq").GetComponent<Text>().text = "asds";
        //GameObject.Find("qqq").GetComponent<Text>().text = Event.current.keyCode.ToString();
        //GameObject.Find("qqq").GetComponent<Text>().text = Event.current.control.ToString()
        //Debug.Log(Input.inputString.ToString()); //записываем в консоль нажатую букву
        //Debug.Log( Event.current.keyCode.ToString());



        //if (Input.GetKey(KeyCode.JoystickButton0)) //если нажата какая-либо клавиша
        //{            //Debug.Log(Input.inputString.ToString()); //записываем в консоль нажатую букву
        //   // GameObject.Find("qqq").GetComponent<Text>().text = KeyCode.JoystickButton1.ToString();
        //    PlayerPrefs.SetString("JoystickButton", KeyCode.JoystickButton0.ToString());

        //}


        //GameObject.Find("qqq").GetComponent<Text>().text = PlayerPrefs.GetString("JoystickButton");

        //if (Input.GetButton(PlayerPrefs.GetString("JoystickButton")))
        //{
        //    GameObject.Find("qqq").GetComponent<Text>().text = Input.GetKey(PlayerPrefs.GetString("JoystickButton")).ToString();
        //}




        GUILayout.Label(array_warraiors.Length.ToString());
        GUILayout.Label(list_active_obj_for_pause.Count.ToString());
    }

   public void Pause_on()
   {

        GameObject.Find("_game").GetComponent<Create_warriors>().is_pause_OFF = false;//отключение появление врагов в режиме паузы
        GameObject.Find("Player").GetComponent<shooting_create_bullets>().is_pause_OFF = false;//отключение стрельбы в режиме паузы
        GameObject.Find("Player").GetComponent<MovePlayer>().is_pause_OFF = false;//отключение движения игрока в режиме паузы

        //деактивируем  объекты враго  
        array_warraiors = GameObject.FindGameObjectsWithTag("warrior");
       for ( i = 0; i<= array_warraiors.Length-1; i++)
       {
            // if (array_warraiors[i].activeInHierarchy == true) { list_active_obj_for_pause.Add(array_warraiors[i]); }
            array_warraiors[i].GetComponent<moveVariorsToPlayer>()._speed = 0f;
        }

        //деактивируем  объекты пуль  
        array_bullets = GameObject.FindGameObjectsWithTag("anyBullets");
         for ( i = 0; i <= array_bullets.Length - 1; i++)
         {
            array_bullets[i].GetComponent<shooting>()._speed = 0f;

         }





        

        
        for ( i = 0; i <= list_active_obj_for_pause.Count - 1; i++ )
           {
            list_active_obj_for_pause[i].GetComponent<moveVariorsToPlayer>()._speed = 0f;//отключение движения врагов в режиме паузы
            //list_active_obj_for_pause[i].SetActive(false);
           }


        _menu.SetActive(true);//показываем меню при входе в  режим паузы
        _button_options.SetActive(false);//скрываем кнопку

    }

    public void Pause_off()
    {

        /*for (i = 0; i <= list_active_obj_for_pause.Count - 1; i++)
        {
            // list_active_obj_for_pause[i].SetActive(true);
            list_active_obj_for_pause[i].GetComponent<moveVariorsToPlayer>()._speed = list_active_obj_for_pause[i].GetComponent<moveVariorsToPlayer>()._speed_basic;//ВКЛЮЧЕНИЕ движения врагов в режиме паузы
        }*/
        for (i = 0; i <= array_warraiors.Length - 1; i++)
        {
            // if (array_warraiors[i].activeInHierarchy == true) { list_active_obj_for_pause.Add(array_warraiors[i]); }
            array_warraiors[i].GetComponent<moveVariorsToPlayer>()._speed = array_warraiors[i].GetComponent<moveVariorsToPlayer>()._speed_basic;
        }

        for (i = 0; i <= array_bullets.Length - 1; i++)
        {
            array_bullets[i].GetComponent<shooting>()._speed = array_bullets[i].GetComponent<shooting>()._speed_basic;

        }


        list_active_obj_for_pause.Clear();
        GameObject.Find("_game").GetComponent<Create_warriors>().is_pause_OFF = true;          // ВКЛЮЧЕНИЕ появление врагов в режиме паузы
        GameObject.Find("Player").GetComponent<shooting_create_bullets>().is_pause_OFF = true; //ВКЛЮЧЕНИЕ стрельбы в режиме паузы
        GameObject.Find("Player").GetComponent<MovePlayer>().is_pause_OFF = true;//ВКЛЮЧЕНИЕ движения игрока в режиме паузы
        _menu_control.SetActive(false);//привыходе из паузы скрываем меню
        _menu.SetActive(false);//привыходе из паузы скрываем меню
       
        _button_options.SetActive(true);//показываем кнопку


    }


   




    public void volume()
    {
        if (_volume.value > 0) { _Button_volume_ON_OFF.GetComponent<RawImage>().texture = _img_on; }
        else { _Button_volume_ON_OFF.GetComponent<RawImage>().texture = _img_off; }
            AudioListener.volume = _volume.value;
       

    }

 

    private float _volume_value_memory;
    public void volume_ON_OFF()
    {
        if (_volume.value>0) {
            AudioListener.volume = 0;
            _Button_volume_ON_OFF.GetComponent<RawImage>().texture = _img_off;
            _volume_value_memory = _volume.value;
            _volume.value = 0f;

        } else {
            AudioListener.volume = _volume.value;
            _Button_volume_ON_OFF.GetComponent<RawImage>().texture = _img_on;
            _volume.value = _volume_value_memory;
        }




    }

    public void Restart_game()
    {

        SceneManager.LoadScene("level1");


    }




    public void load_start_menu()
    {

        SceneManager.LoadScene("scene_StartMenu");
    }


    public void load_menu_control()
    {
        _menu_control.SetActive(true);
        _menu.SetActive(false);

    }
}



