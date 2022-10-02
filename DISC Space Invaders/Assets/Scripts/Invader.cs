using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public System.Action<Invader> hit;
    public SpriteRenderer spriteRenderer;
    public int _animationFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = animationSprites[0];
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if hit by laser destroy itself
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Destroy(this.gameObject);
        }
    }
}
 