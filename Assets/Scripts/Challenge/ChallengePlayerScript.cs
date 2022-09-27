using UnityEngine;

public abstract class ChallengePlayerScript : MonoBehaviour
{
    public abstract void Init();
    public abstract void Cleanup();
    public virtual void OnPlayerCollision(GameObject player)
    {
        
    }
}
