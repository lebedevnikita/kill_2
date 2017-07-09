using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Get_button_joy : MonoBehaviour {
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
                    if (first_str.Length>1 && first_str.Substring(0, 3) == "joy" )
                    {
                        
                        
                      
                        //Debug.Log(first_str.Substring(0, 3));
                        string substr1 = first_str.Substring(0,8);
                        /*Joystick12Button0*/
                        first_str=first_str.Replace(substr1, "");
                       // Debug.Log(first_str);
                        
                        string substr2 = first_str.Substring(first_str.IndexOf("but"), 6);
                        first_str = first_str.Replace(substr2, "!");
                       // Debug.Log(first_str);

                        string substr3 = first_str.Substring(0, first_str.IndexOf("!"));
                        first_str = first_str.Replace(substr3+ "!", "");
                        string substr4 = first_str;
                       // Debug.Log(first_str);

                        PlayerPrefs.SetString(gameObject.name.ToString(), "joystick "+ substr3+ " button "+ substr4);
                      //   Debug.Log("joystick " + substr3 + " button " + substr4);
                        _text_on_button.GetComponent<Text>().text = PlayerPrefs.GetString(gameObject.name.ToString());
                    }

                   /* else { 
                          
                            PlayerPrefs.SetString(gameObject.name.ToString(), k.ToString().ToLower());
                            _text_on_button.GetComponent<Text>().text = PlayerPrefs.GetString(gameObject.name.ToString());
                         }*/

                    StopCoroutine("Wait");
                    //PlayerPrefs.DeleteAll();

              }


                     if (Input.GetAxis("Axis 1") > 0) { _text_on_button.GetComponent<Text>().text = "+Axis 1"; PlayerPrefs.SetString(gameObject.name.ToString(), "+Axis 1"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 2") > 0) { _text_on_button.GetComponent<Text>().text = "+Axis 2"; PlayerPrefs.SetString(gameObject.name.ToString(), "+Axis 2"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 3") > 0) { _text_on_button.GetComponent<Text>().text = "+Axis 3"; PlayerPrefs.SetString(gameObject.name.ToString(), "+Axis 3"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 4") > 0) { _text_on_button.GetComponent<Text>().text = "+Axis 4"; PlayerPrefs.SetString(gameObject.name.ToString(), "+Axis 4"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 5") > 0) { _text_on_button.GetComponent<Text>().text = "+Axis 5"; PlayerPrefs.SetString(gameObject.name.ToString(), "+Axis 5"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 6") > 0) { _text_on_button.GetComponent<Text>().text = "+Axis 6"; PlayerPrefs.SetString(gameObject.name.ToString(), "+Axis 6"); StopCoroutine("Wait"); }

                else if (Input.GetAxis("Axis 1") < 0) { _text_on_button.GetComponent<Text>().text = "-Axis 1"; PlayerPrefs.SetString(gameObject.name.ToString(), "-Axis 1"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 2") < 0) { _text_on_button.GetComponent<Text>().text = "-Axis 2"; PlayerPrefs.SetString(gameObject.name.ToString(), "-Axis 2"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 3") < 0) { _text_on_button.GetComponent<Text>().text = "-Axis 3"; PlayerPrefs.SetString(gameObject.name.ToString(), "-Axis 3"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 4") < 0) { _text_on_button.GetComponent<Text>().text = "-Axis 4"; PlayerPrefs.SetString(gameObject.name.ToString(), "-Axis 4"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 5") < 0) { _text_on_button.GetComponent<Text>().text = "-Axis 5"; PlayerPrefs.SetString(gameObject.name.ToString(), "-Axis 5"); StopCoroutine("Wait"); }
                else if (Input.GetAxis("Axis 6") < 0) { _text_on_button.GetComponent<Text>().text = "-Axis 6"; PlayerPrefs.SetString(gameObject.name.ToString(), "-Axis 6"); StopCoroutine("Wait"); }





            }



        }
    }












}
