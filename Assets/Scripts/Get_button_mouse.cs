using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Get_button_mouse : MonoBehaviour {
    //public KeyCode keyCode { get; set; }
    public GameObject _text_on_button;
    // Use this for initialization
    void Start () {
        _text_on_button.GetComponent<Text>().text = PlayerPrefs.GetString(gameObject.name.ToString());
    }

    // Update is called once per frame
    public void Input_anyKey() {

        StartCoroutine("Wait");

    }


    /*void OnMouseDown()
    {

        StopCoroutine("Wait");
    }*/


    IEnumerator Wait()
    {
        while (true)
        {
            yield return null;

             foreach (KeyCode k in KeyCode.GetValues(typeof(KeyCode)))
            {

           if (Input.GetKeyDown(k))
           
              {
                    PlayerPrefs.DeleteKey(gameObject.name.ToString());
                    string first_str;
                    first_str = k.ToString().ToLower();
                    //Debug.Log(k.ToString().Substring(1, 3));
                    // 
                    if (first_str.Length>1 && first_str.Substring(0, 3) == "mou")
                    {

                        PlayerPrefs.SetString(gameObject.name.ToString(), k.ToString().ToLower());
                        _text_on_button.GetComponent<Text>().text = PlayerPrefs.GetString(gameObject.name.ToString());
                    }

                    

                    StopCoroutine("Wait");
                    //PlayerPrefs.DeleteAll();

              }


                    





            }



        }
    }












}
