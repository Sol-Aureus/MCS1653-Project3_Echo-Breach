using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer trailSprite;

    [Header("Attributes")]
    [SerializeField] private float startingAlpha;
    [SerializeField] private float fadeSpeed;

    private float alpha;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        alpha = startingAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= fadeSpeed * Time.deltaTime;
        spriteRenderer.color = new Color(0, 1, 1, alpha);
        trailSprite.color = new Color(0, 1, 1, alpha);

        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
