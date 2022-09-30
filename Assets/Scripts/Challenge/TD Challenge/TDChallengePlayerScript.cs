using UnityEngine;

public abstract class TDChallengePlayerScript : ChallengePlayerScript
{
    private PlayerMovement _playerMovementScript;
    private PlayerInput _playerInputScript;
    private TDPlayerMovement _tdPlayerMovementScript;
    public override void Init()
    {
        base.Init();
        
        _playerMovementScript = GetComponent<PlayerMovement>();
        _tdPlayerMovementScript = GetComponent<TDPlayerMovement>();

        _playerMovementScript.enabled = false;
        _tdPlayerMovementScript.enabled = true;
    }

    public override void Cleanup()
    {
        _playerMovementScript.enabled = true;
        _tdPlayerMovementScript.enabled = false;
    }
}
