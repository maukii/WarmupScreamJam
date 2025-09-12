using UnityEngine;

public class ConversationTester : MonoBehaviour
{
    [SerializeField] string[] testConversation;


    void Start() => Container.Instance.ConversationSystem.StartConversation(testConversation);
}
