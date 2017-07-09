using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Statistics : MonoBehaviour {

    public int kills;
    public GameObject _menu;


    // Update is called once per frame
    void Update()
    {
        GameObject.Find("count_kills").GetComponent<Text>().text = kills.ToString();



        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (_menu.activeInHierarchy)
            {

                _menu.GetComponent<Button_menu>().Pause_off();

            }
            else if (_menu.activeInHierarchy == false) { _menu.GetComponent<Button_menu>().Pause_on(); }

        }




        

    }

   

    

        /*void OnGUI()
        {


              GUILayout.Label("All " + Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object)).Length);
              GUILayout.Label("Textures " + Resources.FindObjectsOfTypeAll(typeof(Texture)).Length);
              GUILayout.Label("AudioClips " + Resources.FindObjectsOfTypeAll(typeof(AudioClip)).Length);
              GUILayout.Label("Meshes " + Resources.FindObjectsOfTypeAll(typeof(Mesh)).Length);
              GUILayout.Label("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
              GUILayout.Label("GameObjects " + Resources.FindObjectsOfTypeAll(typeof(GameObject)).Length);
              GUILayout.Label("Components " + Resources.FindObjectsOfTypeAll(typeof(Component)).Length);
        }*/







    }
