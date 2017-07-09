using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class moveVariorsToPlayer : MonoBehaviour
{
    public float _speed;
    public float _speed_basic;
    public float _rand_probability_weapon_respawn;
    //private Transform _endPoint;
    //private Vector3 _end_position_basic = new Vector3(-1, -1, -1);
    private Transform _player;
    private float delta_time_update_rotation;
    private float _time;
    // public bool is_pause_OFF = true; //условие паузы
    //private List<GameObject> weapon_list;
    public float _health_current;
    public float _health_basic;


    void Start()
    {
        _speed = (float)Random.Range(_speed/2, _speed) / 100f;
        _player = GameObject.Find("Player").transform;
        _time = 1.5f;
        _speed_basic = _speed; //сохраняем параметр скорости для восстановления значения при выходе из паузы
        //weapon_list= GameObject.Find("_game").GetComponent<Create_warriors>().weapon_list;
    }



    void FixedUpdate()
        //void Update()
    {
        //движение


        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed);
        //поворот в сторону игрока
        //transform.LookAt(_player_for_LookAt) ;
        // StartCoroutine("rotat");
        //delta_time_update_rotation = delta_time_update_rotation - Time.deltaTime;
        delta_time_update_rotation = delta_time_update_rotation - 0.2f;// делаем пропуск кадров для отрисовки поворота
        if (delta_time_update_rotation < 0 )
        {
           
            transform.LookAt(_player);
            delta_time_update_rotation = _time;
        }




    }


    /*IEnumerator rotat()
   {

           transform.LookAt(_player_for_LookAt);
           yield return new WaitForSeconds(1.5f);


   }*/


    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "anyBullets")
        {
            _health_current = _health_current - 1;

            if (_health_current <= 0)
            {   
               
                int Rand_spawn = (int)Random.Range(1, _rand_probability_weapon_respawn);
                if (Rand_spawn == 1) { weapon_respawn(); }
                _health_current = _health_basic;
                //GameObject.Find("www").GetComponent<Text>().text = Rand_spawn.ToString();
                gameObject.SetActive(false);//деактивация врага
                GameObject.Find("_game").GetComponent<Create_warriors>().warrior_list.Add(gameObject); //передача инф-ии в другой скрипт(Create_warriors). в нем объявлен массив warrior_list
            }

        }
    }*/

   









/*
    public void weapon_respawn( )
    {
        if (weapon_list.Count>0) {
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
    */








}
