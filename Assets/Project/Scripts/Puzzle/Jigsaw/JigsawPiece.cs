using UnityEngine;

public class JigsawPiece : MonoBehaviour
{
    [Header("Target")]
    public Transform targetPoint;

    [Header("Settings")]
    public float snapDistance = 0.5f;

    [Header("State")]
    public bool isPlaced = false;
}