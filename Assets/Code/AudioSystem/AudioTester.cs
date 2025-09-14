using UnityEngine;

public class AudioTester : MonoBehaviour
{
    void Start()
    {
        //AudioManager.PlayMusic("outtake");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //AudioManager.FadeOutMusic(0.5f);
            AudioManager.FadeInMusic("outtake", 1f);
            AudioManager.PlayAudio("test");
            Debug.Log("wuwu");
        }
        if (Input.GetMouseButtonDown(1)){
            AudioManager.FadeOutMusic(0.5f);

        }
        
    }
}
