using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;

public class shooting_create_bullets : MonoBehaviour
{


    public GameObject _fire_buton;
    public GameObject _reload_buton;
    private string _fire;
    private string _reload;


    public GameObject _fire_buton_alt;
    public GameObject _reload_buton_alt;
    private string _fire_alt;
    private string _reload_alt;

    public GameObject _fire_buton_m;
    public GameObject _reload_buton_m;
    private string _fire_m;
    private string _reload_m;



    ////базовое кол-во патронов
    public int bullet_pistol_base_cnt;
    public int bullet_shotgun_base_cnt;
    public int bullet_automat_base_cnt;

    ////базовое кол-во патронов
    private int number_of_the_same_weapons;
    private string current_name_weapon;


    ////Создание пула патронов . масиивы, где хранятся ссылки на патроны
    public List<GameObject> bullet_list_all_pistol, bullet_list_all_pistol_2, bullet_list_all_pistol_3, bullet_list_all_pistol_4, bullet_list_all_pistol_5;
    public List<GameObject> bullet_list_all_shotgun, bullet_list_all_shotgun_2, bullet_list_all_shotgun_3, bullet_list_all_shotgun_4, bullet_list_all_shotgun_5;
    public List<GameObject> bullet_list_all_automat, bullet_list_all_automat_2, bullet_list_all_automat_3, bullet_list_all_automat_4, bullet_list_all_automat_5;
    public List<GameObject> bullet_list_all_on_player;

    //Создание пула патронов - обоймы оружия. масиивы, где будут храниться ссылки на активные патроны, теми что можно стрелять

    public List<GameObject> bullet_list_pistol;
    public List<GameObject> bullet_list_shotgun;
    public List<GameObject> bullet_list_automat;
    public List<GameObject> bullet_list_on_player;

    //префабы патронов
    public GameObject _bullet_pistol_prefab;
    public GameObject _bullet_shotgun_prefab;
    public GameObject _bullet_automat_prefab;
    



    // public List<GameObject> bullet_list = new List<GameObject>();
    //private int bullet_list_count;

    private GameObject _startPoint;
    private GameObject _gun_light;
    private GameObject _gun_light2;
    private int i, ii;
    private Vector3 _end_position_basic = new Vector3(-1, -1, -1);


    //Звуки

    public AudioClip _sound_pistol_shot;
    public AudioClip _sound_shotgun_shot;
    public AudioClip _sound_automat_shot;
    public AudioClip _sound_on_player_shot;
    public AudioClip _sound_reload_weapons;
    AudioSource audio;


    // время задержки между патронами
    public float deltaTime_bullet_pistol;
    public float deltaTime_bullet_shotgun;
    public float deltaTime_bullet_automat;
    public float deltaTime_bullet_on_player;
    public float deltaTime_raznica;
    public float deltaTime_bullet_on_player_basic;

    //тест 
    // public GameObject _fortest;
    // private Vector3 _SpawnPoint_fortest;

    public bool is_pause_OFF = true; //условие паузы



    public GameObject player;
    public GameObject _endPoint;
    private Quaternion player_current_Quaternion;
    private List<GameObject> weapon_list;


    public List<GameObject> broken_war1_list = new List<GameObject>();
    public GameObject _broken_war1_prefab;



    void Start()
    {

        //Кнопки

        _fire = PlayerPrefs.GetString(_fire_buton.name.ToString());
        _reload = PlayerPrefs.GetString(_reload_buton.name.ToString());
        _fire_alt = PlayerPrefs.GetString(_fire_buton_alt.name.ToString());
        _reload_alt = PlayerPrefs.GetString(_reload_buton_alt.name.ToString());
        _fire_m = PlayerPrefs.GetString(_fire_buton_m.name.ToString());
        _reload_m = PlayerPrefs.GetString(_reload_buton_m.name.ToString());










        number_of_the_same_weapons = 1;
        weapon_list = GameObject.Find("_game").GetComponent<Create_warriors>().weapon_list;

        _startPoint = GameObject.Find("point_endgun");
        
         _gun_light = GameObject.Find("Gun_light");
        _gun_light2 = GameObject.Find("Gun_light2");

        //Наполнение масcива  bullet_list_pistol патронами
        add_bullet_array(bullet_pistol_base_cnt, _bullet_pistol_prefab, bullet_list_all_pistol);
        add_bullet_array(bullet_pistol_base_cnt*2, _bullet_pistol_prefab, bullet_list_all_pistol_2);
        add_bullet_array(bullet_pistol_base_cnt*3, _bullet_pistol_prefab, bullet_list_all_pistol_3);
        add_bullet_array(bullet_pistol_base_cnt*4, _bullet_pistol_prefab, bullet_list_all_pistol_4);
        add_bullet_array(bullet_pistol_base_cnt*5, _bullet_pistol_prefab, bullet_list_all_pistol_5);
        reload_weapons(bullet_list_all_pistol, bullet_list_pistol);

        //Наполнение масcива  bullet_list_shotgun патронами
        add_bullet_array(bullet_shotgun_base_cnt, _bullet_shotgun_prefab, bullet_list_all_shotgun);
        add_bullet_array(bullet_shotgun_base_cnt *3/2, _bullet_shotgun_prefab, bullet_list_all_shotgun_2);
        add_bullet_array(bullet_shotgun_base_cnt *2, _bullet_shotgun_prefab, bullet_list_all_shotgun_3);
        add_bullet_array(bullet_shotgun_base_cnt*5/2, _bullet_shotgun_prefab, bullet_list_all_shotgun_4);
        add_bullet_array(bullet_shotgun_base_cnt*3, _bullet_shotgun_prefab, bullet_list_all_shotgun_5);
        reload_weapons(bullet_list_all_shotgun, bullet_list_shotgun);

        //Наполнение масcива  bullet_list_automat патронами
        add_bullet_array(bullet_automat_base_cnt, _bullet_automat_prefab, bullet_list_all_automat);
        add_bullet_array(bullet_automat_base_cnt*2, _bullet_automat_prefab, bullet_list_all_automat_2);
        add_bullet_array(bullet_automat_base_cnt*3, _bullet_automat_prefab, bullet_list_all_automat_3);
        add_bullet_array(bullet_automat_base_cnt*4, _bullet_automat_prefab, bullet_list_all_automat_4);
        add_bullet_array(bullet_automat_base_cnt*5, _bullet_automat_prefab, bullet_list_all_automat_5);
        reload_weapons(bullet_list_all_automat, bullet_list_automat);


        //Наполнение масcивов для разрушения врагов
        add_bullet_array(100, _broken_war1_prefab, broken_war1_list);
        

             //начальное оружие у игрока

             bullet_list_all_on_player = bullet_list_all_automat;
                bullet_list_on_player = bullet_list_automat;
                current_name_weapon = "weapon_automat";
                deltaTime_bullet_on_player_basic = deltaTime_bullet_automat;
                _sound_on_player_shot = _sound_automat_shot;

                audio = GetComponent<AudioSource>();
        


    }

    // Update is called once per frame
    void Update()
    {
     

        //рисование кол патронов в обойме
        GameObject.Find("count_bullets").GetComponent<Text>().text = bullet_list_on_player.Count.ToString();

        _gun_light.SetActive(false);//выключаем свет от оружия
        _gun_light2.SetActive(false);//выключаем свет от оружия


        deltaTime_bullet_on_player = deltaTime_bullet_on_player - deltaTime_raznica; //задержка на выстрел и перезарядку


        //перезарядка

        //if (Input.GetMouseButtonDown(1) ||
         if (
                (Input.GetMouseButtonDown(System.Convert.ToInt32(_reload_m.Substring(_reload_m.Length-1, 1))) || Input.GetKeyDown(_reload) || Input.GetKeyDown(_reload_alt))
                && deltaTime_bullet_on_player <= 0
                    && is_pause_OFF
            )
            {
                reload_weapons(bullet_list_all_on_player, bullet_list_on_player);
               // deltaTime_bullet_on_player = deltaTime_bullet_on_player_basic;


            audio.PlayOneShot(_sound_reload_weapons, 0.7F);
        }


        //выстрел





        // if (Input.GetButton("Fire1") ||
        if (
            (Input.GetMouseButton(System.Convert.ToInt32(_fire_m.Substring(_fire_m.Length-1, 1))) || Input.GetKey(_fire) || Input.GetKey(_fire_alt))
                    && bullet_list_on_player.Count!=0 
                        && deltaTime_bullet_on_player <= 0
                            && is_pause_OFF
            )
        {


            audio.PlayOneShot(_sound_on_player_shot, 0.7F);
            //bullet_list_count = bullet_list.Count - 1;

            if (current_name_weapon == "weapon_shotgun")
            { ii = 15; }
            else { ii = 1; } 

                for (i = 1; i <= ii; i++)
                {
                    
                    GameObject g_non_activ = bullet_list_on_player[0];
                    g_non_activ.transform.position = _startPoint.transform.position;
                    g_non_activ.SetActive(true);
                    
                    _gun_light.SetActive(true); //включаем свет от оружия
                    _gun_light2.SetActive(true);//включаем свет от оружия
                    bullet_list_on_player.Remove(bullet_list_on_player[0]);
                }
                deltaTime_bullet_on_player = deltaTime_bullet_on_player_basic;
            

        }





    }




    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "anyWeapon")
        {
            //player.SetActive(false);
            _endPoint.transform.position = player.transform.position;
            player_current_Quaternion = player.transform.rotation;
            player.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f); // обнуляем дистанию полета патронов, для упрощения расчета дистанции

            if (other.name == "weapon_pistol")
            {

                if (current_name_weapon == other.name)
                {
                    number_of_the_same_weapons++;
                    if (number_of_the_same_weapons == 2) { bullet_list_all_on_player = bullet_list_all_pistol_2; }
                    if (number_of_the_same_weapons == 3) { bullet_list_all_on_player = bullet_list_all_pistol_3; }
                    if (number_of_the_same_weapons == 4) { bullet_list_all_on_player = bullet_list_all_pistol_4; }
                    if (number_of_the_same_weapons >= 5) { bullet_list_all_on_player = bullet_list_all_pistol_5; }
                }

                else
                {
                    bullet_list_all_on_player = bullet_list_all_pistol;
                    bullet_list_on_player = bullet_list_pistol;
                    number_of_the_same_weapons = 1;
                   
                }


               _sound_on_player_shot = _sound_pistol_shot;
               deltaTime_bullet_on_player_basic = deltaTime_bullet_pistol;
                _endPoint.transform.position = player.transform.position + new Vector3(0, 0, 40);
                current_name_weapon = other.name;


            }

            else

            if (other.name == "weapon_shotgun")
            {

                if (current_name_weapon == other.name)
                {
                    number_of_the_same_weapons++;
                    if (number_of_the_same_weapons == 2) { bullet_list_all_on_player = bullet_list_all_shotgun_2; }
                    if (number_of_the_same_weapons == 3) { bullet_list_all_on_player = bullet_list_all_shotgun_3; }
                    if (number_of_the_same_weapons == 4) { bullet_list_all_on_player = bullet_list_all_shotgun_4; }
                    if (number_of_the_same_weapons >= 5) { bullet_list_all_on_player = bullet_list_all_shotgun_5; }
                }

                else {
                    bullet_list_all_on_player = bullet_list_all_shotgun;
                    bullet_list_on_player = bullet_list_shotgun;
                    number_of_the_same_weapons = 1;
                   
                }

                _sound_on_player_shot = _sound_shotgun_shot;
                deltaTime_bullet_on_player_basic = deltaTime_bullet_shotgun;
                _endPoint.transform.position = player.transform.position + new Vector3(0, 0, 35);
                current_name_weapon = other.name;
            }
            else

            if (other.name == "weapon_automat")
            {

                if (current_name_weapon == other.name)
                {
                    number_of_the_same_weapons++;
                    if (number_of_the_same_weapons == 2) { bullet_list_all_on_player = bullet_list_all_automat_2; }
                    if (number_of_the_same_weapons == 3) { bullet_list_all_on_player = bullet_list_all_automat_3; }
                    if (number_of_the_same_weapons == 4) { bullet_list_all_on_player = bullet_list_all_automat_4; }
                    if (number_of_the_same_weapons >= 5) { bullet_list_all_on_player = bullet_list_all_automat_5; }
                }

                else
                {   
                    bullet_list_all_on_player = bullet_list_all_automat;
                    bullet_list_on_player = bullet_list_automat;
                    number_of_the_same_weapons = 1;
                    
                }

                _sound_on_player_shot = _sound_automat_shot;
                deltaTime_bullet_on_player_basic = deltaTime_bullet_automat;
                _endPoint.transform.position = player.transform.position + new Vector3(0, 0, 45);
                current_name_weapon = other.name;


            }







            player.transform.rotation = player_current_Quaternion;//возвращаем угол поворота игрока
            deltaTime_bullet_on_player = -1;//после поднятия оружия задержка на выстрел сбрасывается


            other.gameObject.SetActive(false);
            weapon_list.Add(other.gameObject);

        }

    }


















    public void add_bullet_array(int cnt_bullets, GameObject _prefab, List<GameObject> _list)
    {
        i = 1;
        for (i = 1; i <= cnt_bullets; i++)
        {
            GameObject g = Instantiate<GameObject>(_prefab);
            //g.transform.position = _end_position_basic;
            g.name = _prefab.name.ToString() + i.ToString();
            g.SetActive(false);
            _list.Add(g);

        }
    }


    private int cnt_all_bulets;
    //private int cnt_exist_bulets;
    public void reload_weapons(List<GameObject> _list_all_bullets, List<GameObject> _list_current)
    {
        cnt_all_bulets = _list_all_bullets.Count;
        //cnt_exist_bulets = _list_current.Count;

        _list_current.Clear();

        for (i = 1; i <= cnt_all_bulets; i++)
        {

 
                _list_all_bullets[i - 1].SetActive(false);
                _list_current.Add(_list_all_bullets[i - 1]);
            

            
            
            //_list_all_bullets[i - 1].transform.position = _end_position_basic;
        }


    }



}

/*
 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shooting_create_bullets : MonoBehaviour
{
    
    //Создание пула патронов
    public GameObject _bullet_prefab;
    public List<GameObject> bullet_list_pistol  ;
    public List<GameObject> bullet_list_shotgun;
    public List<GameObject> bullet_list_automat;


    // public List<GameObject> bullet_list = new List<GameObject>();
    //private int bullet_list_count;
    private int cnt_bulets;
    private GameObject _startPoint;
    private GameObject _gun_light;
    private GameObject _gun_light2;
    private int i;


   

    //тест 
    // public GameObject _fortest;
    // private Vector3 _SpawnPoint_fortest;




    void Start()
    {
         _startPoint = GameObject.Find("point_endgun");
        
         _gun_light = GameObject.Find("Gun_light");
        _gun_light2 = GameObject.Find("Gun_light2");


        //Наполнение масcива  bullet_list_pistol патронами
        fill_bullet_array(6, _bullet_prefab, bullet_list_pistol);
        //Наполнение масcива  bullet_list_shotgun патронами
        fill_bullet_array(2, _bullet_prefab, bullet_list_shotgun);
        //Наполнение масcива  bullet_list_automat патронами
        fill_bullet_array(30, _bullet_prefab, bullet_list_automat);




    }

    // Update is called once per frame
    void Update()
    {
        _gun_light.SetActive(false);//выключаем свет от оружия
        _gun_light2.SetActive(false);//выключаем свет от оружия
        if (Input.GetButtonDown("Fire1"))
        {

            

            if (bullet_list_pistol.Count==0)//создание нового патрона, если в массиве нет свободных объектов
            {
              
                //cnt_bulets = cnt_bulets + 1;
                GameObject New_g = Instantiate<GameObject>(_bullet_prefab);
                New_g.SetActive(false);
                //New_g.transform.position = new Vector3(-1,-1,-1);
                //New_g.name = "_bullet1_" + (cnt_bulets + i).ToString();
                bullet_list_pistol.Add(New_g);
            }
            
            

            //bullet_list_count = bullet_list.Count - 1;
            GameObject g_non_activ = bullet_list_pistol[0];
            
            g_non_activ.transform.position = _startPoint.transform.position;
            g_non_activ.SetActive(true);
            _gun_light.SetActive(true);//включаем свет от оружия
            _gun_light2.SetActive(true);//включаем свет от оружия
            bullet_list_pistol.Remove(bullet_list_pistol[0]);

            



        }


    }




    public void fill_bullet_array(int cnt_bullets, GameObject _prefab, List<GameObject> _list)
    {
        for (i = 1; i <= cnt_bullets; i++)
        {
            GameObject g = Instantiate<GameObject>(_prefab);
            //g.transform.position = _startPoint.transform.position;
            g.SetActive(false);
            _list.Add(g);

        }


    }



}
     */
