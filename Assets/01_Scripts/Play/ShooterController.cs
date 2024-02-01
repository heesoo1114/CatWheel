using UnityEngine;

public class ShooterController : Observer<GameController>
{
    private SurfaceEffector2D surfaceEffector;
    private Animator animator;

    private int isShootHash = Animator.StringToHash("isShoot");

    private void Awake()
    {
        SetUp();

        surfaceEffector = GetComponent<SurfaceEffector2D>();
        animator = GetComponent<Animator>();
    }

    public override void Notify()
    {
        if (mySubject.IsPlaying)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        surfaceEffector.enabled = true;
        animator.SetTrigger(isShootHash);

        StartCoroutine(this.GiveDelayWithAction(1f, () =>
        {
            surfaceEffector.enabled = false;
        }));
    }
}
