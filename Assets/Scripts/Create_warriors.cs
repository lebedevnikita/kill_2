using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Create_warriors : MonoBehaviour
{
    public float dist_min ;//минимальный радиус появления врагов
    public float dist_max ;//максимальный радиус появления врагов
    private float dist=45f;//максимальный радиус появления врагов
    public int count_war_from_start; //количество создаваемых врагов
    public int count_war_from_start_active; //количество создаваемых врагов
    public int count_boss_from_start; //количество создаваемых боссов
    // GameObject _varior = GameObject.Find("war1");// ссылка на префаб врагов
    public GameObject _var; //префаб врага
    public GameObject _var2; //префаб врага
    public GameObject _var3; //префаб врага
    public GameObject _var4; //префаб врага
    public GameObject _var5; //префаб врага
    public GameObject _var6; //префаб врага

    public GameObject _weapon1; //префаб врага
    public GameObject _weapon2; //префаб врага
    public GameObject _weapon3; //префаб врага


    private float randz;
    private float randx;
    private int znak;
    public List<GameObject> warrior_list = new List<GameObject>();
    public List<GameObject> weapon_list = new List<GameObject>();
    public float time;//дельта времени появления врагов 
    private float delta_time;//оставшееся время до появления врагов 
    private int count_war_spawn;
    private Transform _player_transform;

    private GameObject[] _war_prefab_array;
    private GameObject[] _weapon_prefab_array;
    private GameObject[] _boss_prefab_array;

    public bool is_pause_OFF=true; //условие паузы
    public Transform terrain_Transform; //земля для определения шраниц

    


    void Start()

    {
        dist = (float)Random.Range(dist_min, dist_max);
        //ссылка на игрока
        _player_transform = GameObject.Find("Player").transform;

        //наполение массива префабов врагов
        _war_prefab_array= new GameObject[4] { _var, _var3, _var5, _var6};

        //наполение массива префабов боссов
        _boss_prefab_array = new GameObject[2] { _var4, _var2 };


        // Создание врагов при старте
        //наполнение массива неактивными врагами
        for (int i = 1; i <= count_war_from_start; i++)

        {
            create_new_item(_war_prefab_array 
                                            
                                            , warrior_list//в какой пул добавляем
                                            , dist//дистанция появления
                                                );
        }



        //наполнение массива неактивными Боссами
        for (int i = 1; i <= count_boss_from_start; i++)

        {
            create_new_item(_boss_prefab_array

                                            , warrior_list//в какой пул добавляем
                                            , dist//дистанция появления
                                                );
        }


        //активация всех врагов и удаление их из массива
        while (warrior_list.Count > count_war_from_start-count_war_from_start_active)



        {
            
            randx = (float)Random.Range(-dist, dist);
            znak = (int)Random.Range(-1, 1);
            if (znak == 0) { znak = 1; }
            randz = Mathf.Sqrt(dist * dist - randx * randx) * znak;
            Vector3 _player_current_position = _player_transform.position;//получаем текущие координаты игорка
            Vector3 _SpawnPoint = new Vector3(randx, 1, randz) + _player_current_position;

            warrior_list[0].SetActive(true);
            warrior_list[0].transform.position = _SpawnPoint;
            warrior_list.Remove(warrior_list[0]);
        }







      






        // наполнение массива weapons 

        //делаем одинаковое кол-во 
        _weapon_prefab_array = new GameObject[1] { _weapon1 };


        for (int i = 1; i <= 5; i++)

        {
            create_new_item(_weapon_prefab_array
                                           
                                            , weapon_list//в какой пул добавляем
                                            , dist//дистанция появления
                                                );
        }

        _weapon_prefab_array = new GameObject[1] { _weapon2 };


        for (int i = 1; i <= 5; i++)

        {
            create_new_item(_weapon_prefab_array
                                           
                                            , weapon_list//в какой пул добавляем
                                            , dist//дистанция появления
                                                );
        }

        _weapon_prefab_array = new GameObject[1] { _weapon3 };


        for (int i = 1; i <= 5; i++)

        {
            create_new_item(_weapon_prefab_array
                                            
                                            , weapon_list//в какой пул добавляем
                                            , dist//дистанция появления
                                                );
        }

        _weapon_prefab_array = new GameObject[3] { _weapon1, _weapon2, _weapon3 };



    }








    void Update()

    {
        dist = (float)Random.Range(dist_min, dist_max);

        // Создание врагов при при нехватке в массиве
        if (warrior_list.Count == 0 ||  warrior_list.Count- count_war_spawn  < 0)
        { 
                int count_war_create = count_war_spawn - warrior_list.Count;//создавть столько врагов, сколько нехватает в данный момент для респауна
                for (int i = 1; i <= count_war_create; i++)
                {
                create_new_item(_war_prefab_array
                  
                    ,warrior_list//в какой пул добавляем
                     , dist//дистанция появления
                    );
                }
                
        
        }
// активация врагов из массива
count_war_spawn = 3;// нужна логика , количество появления врагов от времени




        delta_time = delta_time - Time.deltaTime;//Вычитаем из дельты по секунде

        



        if (
            delta_time <= 0//Время вышло, респауним врага
            && warrior_list.Count>= count_war_spawn
            &&  is_pause_OFF
            )
        {
            
            for (int i = 1; i <= count_war_spawn; i++)
            {


               
                randx = (float)Random.Range(-dist, dist);
                znak = (int)Random.Range(-1, 1);
                if (znak == 0) { znak = 1; }
                randz = Mathf.Sqrt(dist * dist - randx * randx) * znak;
                Vector3 _player_current_position = GameObject.Find("Player").transform.position;//получаем текущие координаты игорка
                Vector3 _SpawnPoint = new Vector3(randx, 1, randz) + _player_current_position;

                
                if ((terrain_Transform.lossyScale.x /2) < Mathf.Abs(_SpawnPoint.x))
                { _SpawnPoint.x= (int)Random.Range(-terrain_Transform.localScale.x / 2, terrain_Transform.lossyScale.x / 2); }

                if ((terrain_Transform.lossyScale.y / 2) < Mathf.Abs(_SpawnPoint.y))
                { _SpawnPoint.y = (int)Random.Range(-terrain_Transform.localScale.y / 2, terrain_Transform.lossyScale.y / 2); }


               /* Debug.Log(terrain_Transform.lossyScale.x /2);
                Debug.Log(Mathf.Abs(_SpawnPoint.x));*/

                warrior_list[0].SetActive(true);
                warrior_list[0].transform.position = _SpawnPoint;
                warrior_list.Remove(warrior_list[0]);




                //warrior_list[0].GetComponent<moveVariorsToPlayer>()._health_current = warrior_list[0].GetComponent<moveVariorsToPlayer>()._health_basic;


            }
                delta_time = time;//зацикливаем время
        }

    }

   // private int _count_prefab_warrior;
   // private int _rand_prefab_warrior;


    //создание нового объекта из префаба 
    public void create_new_item(GameObject[] _prefab_array, List<GameObject> pool, float _dist)
    {
        //кол -во моделей префабов в массиве пефабов врагов
        int _count_prefab_warrior = _prefab_array.Length;

        //рандомный выбор модели
        int _rand_prefab_warrior = (int)Random.Range(1, _count_prefab_warrior+1);

        //создание объекта
        GameObject v = Instantiate<GameObject>(_prefab_array[_rand_prefab_warrior - 1]); //вычитаем 1 т.к. массив ачинается с 0
        v.name = _prefab_array[_rand_prefab_warrior - 1].name;
        v.SetActive(false);
        pool.Add(v);
    }

    /*
      public void create_new_item(GameObject[] _prefab_array, Vector3 _player_current_position, List<GameObject> pool, float _dist)
    {
        //кол -во моделей префабов в массиве пефабов врагов
        int _count_prefab_warrior = _prefab_array.Length;

        //рандомный выбор модели
        int _rand_prefab_warrior = (int)Random.Range(1, _count_prefab_warrior+1);


        //произвольная позиция респауна. зависит от текущего положения игрока
        float _randx = (float)Random.Range(-_dist, _dist);
        int _znak = (int)Random.Range(-1, 1);
        if (_znak == 0) { znak = 1; }
        randz = Mathf.Sqrt(_dist * _dist - randx * randx) * znak;

        Vector3 _SpawnPoint = new Vector3(_randx, 1, randz) + _player_current_position;
        Quaternion _Quaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);


        //создание объекта
        GameObject v = Instantiate<GameObject>(_prefab_array[_rand_prefab_warrior - 1]); //вычитаем 1 т.к. массив ачинается с 0
        v.transform.position = _SpawnPoint;
        v.transform.rotation = _Quaternion;
        v.name = _prefab_array[_rand_prefab_warrior - 1].name;
        v.SetActive(false);
        pool.Add(v);
    }
     
     */

}
