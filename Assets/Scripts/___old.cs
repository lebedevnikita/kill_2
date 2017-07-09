using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Create_warriors_ : MonoBehaviour
{
    public float dist = 45f;//максимальный радиус появления врагов
    public int count_war_from_start; //количество создаваемых врагов
    // GameObject _varior = GameObject.Find("war1");// ссылка на префаб врагов
    public GameObject _var; //префаб врага
    public GameObject _var2; //префаб врага
    public GameObject _var3; //префаб врага

    private float randz;
    private float randx;
    private int znak;
    public List<GameObject> warrior_list = new List<GameObject>();
    public float time;//дельта времени появления врагов 
    private float delta_time;//оставшееся время до появления врагов 
    private int count_war_spawn;
    private Transform _player_transform;

    private GameObject[] _war_prefab_array;

    public bool is_pause_OFF = true; //условие паузы

    void Start()

    {

        //ссылка на игрока
        _player_transform = GameObject.Find("Player").transform;

        //наполение массива префабов врагов
        _war_prefab_array = new GameObject[3] { _var, _var2, _var3 };







        // Создание врагов при старте
        //наполнение массива неактивными врагами
        for (int i = 1; i <= count_war_from_start; i++)

        {
            create_new_item_warrior();
        }







        //активация всех врагов и удаление их из массива
        while (warrior_list.Count > 0)
        {
            warrior_list[0].SetActive(true);
            warrior_list.Remove(warrior_list[0]);
        }


    }








    void Update()

    {
        // Создание врагов при при нехватке в массиве
        if (warrior_list.Count == 0 || warrior_list.Count - count_war_spawn < 0)
        {
            int count_war_create = count_war_spawn - warrior_list.Count;//создавть столько врагов, сколько нехватает в данный момент для респауна
            for (int i = 1; i <= count_war_create; i++)
            {
                create_new_item_warrior();
            }


        }
        // активация врагов из массива
        count_war_spawn = 3;// нужна логика , количество появления врагов от времени

        delta_time = delta_time - Time.deltaTime;//Вычитаем из дельты по секунде
        if (
            delta_time <= 0//Время вышло, респауним врага
            && warrior_list.Count >= count_war_spawn
            && is_pause_OFF
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

                warrior_list[0].SetActive(true);
                warrior_list[0].transform.position = _SpawnPoint;
                warrior_list.Remove(warrior_list[0]);



            }
            delta_time = time;//зацикливаем время
        }

    }

    private int _count_prefab_warrior;
    private int _rand_prefab_warrior;


    //создание нового объекта из префаба врага
    public void create_new_item_warrior()
    {
        //кол -во моделей префабов в массиве пефабов врагов
        _count_prefab_warrior = _war_prefab_array.Length;

        //рандомный выбор модели
        _rand_prefab_warrior = (int)Random.Range(1, _count_prefab_warrior + 1);


        //произвольная позиция респауна. зависит от текущего положения игрока
        randx = (float)Random.Range(-dist, dist);
        znak = (int)Random.Range(-1, 1);
        if (znak == 0) { znak = 1; }
        randz = Mathf.Sqrt(dist * dist - randx * randx) * znak;
        Vector3 _player_current_position = _player_transform.position;//получаем текущие координаты игорка
        Vector3 _SpawnPoint = new Vector3(randx, 1, randz) + _player_current_position;
        Quaternion _Quaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);


        //создание объекта
        GameObject v = Instantiate<GameObject>(_war_prefab_array[_rand_prefab_warrior - 1]); //вычитаем 1 т.к. массив ачинается с 0
        v.transform.position = _SpawnPoint;
        v.transform.rotation = _Quaternion;
        v.SetActive(false);
        warrior_list.Add(v);
    }



}
