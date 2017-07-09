using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Get_button_keyboard : MonoBehaviour {
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
                   // first_str = k.ToString().ToLower();
                    first_str = k.ToString();
                    //Debug.Log(k.ToString());
                    //Debug.Log(KeyCode.GetValues(typeof(KeyCode)));


                    

                    // 
                    //  if (first_str.Length>1 && first_str.Substring(0, 3) != "joy" && first_str.Substring(0, 3) != "mou")
                    // {

                    if (k.ToString() == "LeftControl") {  PlayerPrefs.SetString(gameObject.name.ToString(), "left ctrl"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "right ctrl"); }

                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "right shift"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "left shift"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "right alt"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "left alt"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "right cmd"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "left cmd"); }
                    else if (k.ToString() == "RightControl") { PlayerPrefs.SetString(gameObject.name.ToString(), "right ctrl"); }

                    else if (k.ToString() == "UpArrow") { PlayerPrefs.SetString(gameObject.name.ToString(), "up"); }
                    else if (k.ToString() == "DownArrow") { PlayerPrefs.SetString(gameObject.name.ToString(), "down"); }
                    else if (k.ToString() == "LeftArrow") { PlayerPrefs.SetString(gameObject.name.ToString(), "left"); }
                    else if (k.ToString() == "RightArrow") { PlayerPrefs.SetString(gameObject.name.ToString(), "right"); }

                    //else if (k.ToString().Substring(0, 5) == "Alpha") { PlayerPrefs.SetString(gameObject.name.ToString(), k.ToString().Replace("Alpha", "")); }

                    else { PlayerPrefs.SetString(gameObject.name.ToString(), k.ToString().ToLower()); }


                    /*
                     
                        +Normal keys: “a”, “b”, “c” …
                        +Number keys: “1”, “2”, “3”, …
                        +Arrow keys: “up”, “down”, “left”, “right”
                        Keypad keys: “[1]”, “[2]”, “[3]”, “[+]”, “[equals]”
                        +Modifier keys: “right shift”, “left shift”, “right ctrl”, “left ctrl”, “right alt”, “left alt”, “right cmd”, “left cmd”
                        Mouse Buttons: “mouse 0”, “mouse 1”, “mouse 2”, …
                        Joystick Buttons (from any joystick): “joystick button 0”, “joystick button 1”, “joystick button 2”, …
                        Joystick Buttons (from a specific joystick): “joystick 1 button 0”, “joystick 1 button 1”, “joystick 2 button 0”, …
                        Special keys: “backspace”, “tab”, “return”, “escape”, “space”, “delete”, “enter”, “insert”, “home”, “end”, “page up”, “page down”
                        +Function keys: “f1”, “f2”, “f3”, …
                     
                     
                     
                     */

                   
                    _text_on_button.GetComponent<Text>().text = PlayerPrefs.GetString(gameObject.name.ToString());
                  //  }



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
