using UnityEngine;
using System.Collections;

public class menuMusic : MonoBehaviour {
    static bool AudioBegin = false;

    public static menuMusic Instance;

    //awake is called when the instance is loaded, only once called in lifetime  <http://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html>
    //best used to initialize variables and gamestates
    void Awake()
    {
        //if the audio hasn't startet the AudioSource component (linked with the script) is called and beeing started
        if(Instance){
             DestroyImmediate(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
            Instance = this;
            if (!AudioBegin){
            GetComponent<AudioSource>().Play();
            AudioBegin = true;
            }
        }
    }

    //Update is called whenever the scene is switched, when the EndScreen is loaded the menuMusic stopts and the gameobject is destroyed
    void Update()
    {
        if (Application.loadedLevelName == "EndScreen" || Application.loadedLevelName == "LoseScreen")
        {
            GetComponent<AudioSource>().Stop();
            AudioBegin = false;
            Destroy(this.gameObject);
        }
    }
}
