using UnityEngine;

public class PlayerController : Observer<GameController>
{
    private Vector2 initPosition;

    private void Awake()
    {
        SetUp();

        initPosition = transform.position;
    }

    public override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            gameObject.SetActive(true);
        }
        else if (mySubject.IsReady)
        {
            gameObject.SetActive(false);
            transform.position = initPosition;
        }
    }
}
