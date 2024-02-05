using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : Observer<GameController>
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private List<Sprite> backgroundImages = new ();

    private void Awake()
    {
        SetUp();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void Notify()
    {
        if (mySubject.IsReady)
        {
            ChangeRandomImage();
        }
    }

    private void ChangeRandomImage()
    {
        int randomIndedx = Random.Range(0, backgroundImages.Count);
        spriteRenderer.sprite = backgroundImages[randomIndedx];
    }
}
