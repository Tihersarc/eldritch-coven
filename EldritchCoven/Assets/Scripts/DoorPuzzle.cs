using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour
{
    [SerializeField] DoorPuzzleManger puzzleManager;
    [SerializeField] int number;

    private void OnTriggerEnter(Collider other)
    {
        puzzleManager.AddNumberToCurrentSequence(number);
    }
}
