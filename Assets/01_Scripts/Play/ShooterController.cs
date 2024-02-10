using UnityEngine;

public class ShooterController : Observer<GameController>
{
    private SurfaceEffector2D surfaceEffector;
    private Animator animator;

    private int isShootHash = Animator.StringToHash("isShoot");

    [SerializeField] private AudioClip shootClip;

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

        StartCoroutine(this.GiveDelayWithAction(0.3f, () =>
        {
            surfaceEffector.enabled = false;
            AudioManager.Instance.Play(shootClip);
        }));
    }
}
