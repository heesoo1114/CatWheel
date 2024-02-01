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

    void Update()
    {
        // 상하 clamp 걸어서 게임오브젝트 꺼주기
        // 골라인까지 남은 거리 X값
    }
}
