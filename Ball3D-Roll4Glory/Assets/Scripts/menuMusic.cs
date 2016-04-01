using UnityEngine;
using System.Collections;

public class menuMusic : MonoBehaviour {
    static bool AudioBegin = false;

    //awake is called when the instance is loaded, only once called in lifetime  <http://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html>
    //best used to initialize variables and gamestates
    void Awake()
    {
        //if the audio hasn't startet the AudioSource component (linked with the script) is called and beeing started
        if (!AudioBegin)
        {
            GetComponent<AudioSource>().Play();
            //DontDestroyOnLoad keeps the gameObject alive betweens scenes 
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    //Update is called whenever the scene is switched, when the EndScreen is loaded the menueMusic stopts and the gameobject is destroyed
    void Update()
    {
        if (Application.loadedLevelName == "EndScreen")
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
            Destroy(this.gameObject);
        }
    }
}
