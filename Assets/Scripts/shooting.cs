using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class shooting : MonoBehaviour
{
    //private Vector3 _start_position;
    private Vector3 _end_position;
   // private Vector3 _end_position_probably;
    public float _speed;
    public float _speed_basic;
   // public float _distance;
    public int dispersion_shooting;
    //private GameObject _player;
    private GameObject _endPoint;
    private GameObject __game;


    private float randx;
    private int znak;
    private float randz;
    //private float dist;
    private float dispersion_shooting_rand;
    
    // public GameObject blood_from_bullet;


    private List<GameObject> weapon_list;
    private List<GameObject> broken_war1_list;

    public GameObject br_war_pref;


    void Awake()
    {
               gameObject.SetActive(false);
        _speed_basic = _speed; //сохраняем параметр скорости для восстановления значения при выходе из паузы

        weapon_list = GameObject.Find("_game").GetComponent<Create_warriors>().weapon_list;
        broken_war1_list = GameObject.Find("Player").GetComponent<shooting_create_bullets>().broken_war1_list;




    }


    void OnEnable()
    {

        _endPoint = GameObject.Find("point_distance_bullet");
       
        __game = GameObject.Find("_game");

        dispersion_shooting_rand = (float)Random.Range(-dispersion_shooting, dispersion_shooting);
        randx = (float)Random.Range(-dispersion_shooting_rand, dispersion_shooting_rand);
        znak = (int)Random.Range(-1, 1);
        if (znak == 0) { znak = 1; }
        randz = Mathf.Sqrt(dispersion_shooting_rand * dispersion_shooting_rand - randx * randx) * znak;

        _end_position = new Vector3(randx, 0, randz) + _endPoint.transform.position;//делаем производьный разброс пуль от конечной точки

        //_end_position = _endPoint.transform.position;//ghb активации получаем новые координаты цели



    }
    


    void FixedUpdate()
    {


       /* if (_end_position == _end_position_basic) //если конечная точка обнулена, то присваиваем конечной точке текущее положение конечной точки. должно срабатывать после активации объектв патрона.
        {
            _end_position = _endPoint.transform.position;
        }
        */
  

        //обработка события полета патрона , затем его деактивация и помещение в массив свободных объектов
        transform.position = Vector3.MoveTowards(transform.position, _end_position, _speed );
        if (transform.position == _end_position)
        {
            gameObject.SetActive(false);
           // _player.GetComponent<shooting_create_bullets>().bullet_list_pistol.Add (gameObject); //передача инф-ии в другой скрипт(shooting_create_bullets). в нем объявлен массив bullet_list
            //_end_position = _end_position_basic;
        }

      
        
    }


    /* старый скрипт
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "warrior" )
        {

            
            // скрипт для реализации сквозных пуль
            //if (gameObject.name != "bullet_shotgun1" && gameObject.name != "bullet_shotgun2")
            //{
            //    gameObject.SetActive(false);
            //}
            
            gameObject.SetActive(false);
            __game.GetComponent<Statistics>().kills++;


        }

    }*/



  

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "warrior")
        {


            // скрипт для реализации сквозных пуль
            //if (gameObject.name != "bullet_shotgun1" && gameObject.name != "bullet_shotgun2")
            //{
            //    gameObject.SetActive(false);
            //}




            gameObject.SetActive(false);//деактивация пули
           


            //_health_current = _health_current - 1;
            other.gameObject.GetComponent<moveVariorsToPlayer>()._health_current--;



            //if (_health_current <= 0)
            if (other.gameObject.GetComponent<moveVariorsToPlayer>()._health_current <= 0)
            {

                int Rand_spawn = (int)Random.Range(1, other.gameObject.GetComponent<moveVariorsToPlayer>()._rand_probability_weapon_respawn);
                if (Rand_spawn == 1) { weapon_respawn(); }

                //восстанавливаем здоровье убитого врага
                other.gameObject.GetComponent<moveVariorsToPlayer>()._health_current = other.gameObject.GetComponent<moveVariorsToPlayer>()._health_basic;
                

                other.gameObject.SetActive(false);//деактивация врага
                GameObject.Find("_game").GetComponent<Create_warriors>().warrior_list.Add(other.gameObject); //передача инф-ии в другой скрипт(Create_warriors). в нем объявлен массив warrior_list

                __game.GetComponent<Statistics>().kills++;//счетчик убиных врагов
                


                // разрушение врагов
                // 
                //
                
                
                broken_war1_list[0].transform.position = other.transform.position;
                broken_war1_list[0].SetActive(true);
                broken_war1_list.Remove(broken_war1_list[0]);







            }




        }
    }

       public void weapon_respawn()
    {
        if (weapon_list.Count > 0)
        {
            //кол -во моделей префабов в массиве пефабов врагов
            int _count_prefab_weapon = weapon_list.Count;

            //рандомный выбор 
            int _rand_prefab_weapon = (int)Random.Range(1, _count_prefab_weapon + 1);

            weapon_list[_rand_prefab_weapon - 1].SetActive(true);
            weapon_list[_rand_prefab_weapon - 1].transform.position = transform.position;
            weapon_list[_rand_prefab_weapon - 1].transform.rotation = transform.rotation;
            weapon_list.Remove(weapon_list[_rand_prefab_weapon - 1]);
        }
    }

}

