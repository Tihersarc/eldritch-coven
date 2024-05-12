using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorPuzzleManger : MonoBehaviour
{
    [SerializeField] List<int> order;

    private List<int> currentOrder = new List<int>();

    private bool canInputNewNumber;
    public UnityEvent onCorrectSequence;

    public void AddNumberToCurrentSequence(int newNumber)
    {
        if (canInputNewNumber)
        {
            bool equals = true;
            currentOrder.Add(newNumber);
            if (currentOrder.Count == order.Count)
            {
                for (int i = 0; i < order.Count; i++)
                {
                    if (!(order[i] == currentOrder[i]))
                    {
                        equals = false;
                    }
                }
                if (equals)
                {
                    onCorrectSequence.Invoke();
                }
                else
                {
                    currentOrder.RemoveAt(0);
                }
            }
            canInputNewNumber = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canInputNewNumber = true;
    }
}
