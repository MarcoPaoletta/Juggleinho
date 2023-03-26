using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrailRendererHandler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TrailRenderer trailRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Lists")]
    [SerializeField] private List<Gradient> ballGradients;
    [SerializeField] private List<Sprite> ballSprites;

    private void Start()
    {
        int random = Random.Range(0, ballGradients.Count);
        trailRenderer.colorGradient = ballGradients[random];
        spriteRenderer.sprite = ballSprites[random];
    }
}