
public class HopperPlayerScript : ChallengePlayerScript
{
    public bool playerIsOut = false;

    public void Hit()
    {
        playerIsOut = true;
        gameObject.SetActive(false);
    }
    public override void Cleanup()
    {
        gameObject.SetActive(true);
    }
}