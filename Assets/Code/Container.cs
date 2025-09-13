using UnityEngine;

public class Container : MonoBehaviour
{
    public static Container Instance { get; private set; }

    [field: SerializeField] public ConversationSystem ConversationSystem { get; private set; }
    [field: SerializeField] public CutscenePlayer CutscenePlayer { get; private set; }


    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
}
