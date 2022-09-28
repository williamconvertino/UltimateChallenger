using UnityEngine;

public abstract class ChallengePlayerScript : MonoBehaviour
{
    #region Initialization

    //Keeps a reference to the player (for ease of access)
    public GameObject Player { private set; get; }

    public virtual void Init()
    {
        Player = transform.gameObject;
    }
    
    #endregion

    #region Cleanup
    public abstract void Cleanup();
    #endregion

    #region Player Collision
    public virtual void OnPlayerCollision(GameObject player)
    {
        
    }
    #endregion
}
