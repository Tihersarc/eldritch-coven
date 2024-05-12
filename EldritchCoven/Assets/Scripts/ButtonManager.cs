using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private List<Button> buttons;

    private List<Button> currentSequence = new List<Button>();

    private static ButtonManager buttonManager;

    public UnityEvent<bool> onCorrectSequence;

    public static ButtonManager instance
    {
        get
        {
            return RequestInstance();
        }
    }

    static ButtonManager RequestInstance()
    {

        if (buttonManager == null)
        {
            buttonManager = FindObjectOfType<ButtonManager>();

            if (buttonManager == null)
            {
                GameObject gamelogicObject = new GameObject("ButtonManager");
                buttonManager = gamelogicObject.AddComponent<ButtonManager>();
            }
        }
        return buttonManager;
    }

    private void Start()
    {
        foreach (var button in buttons)
        {
            Debug.Log(button.gameObject.name);
        }
    }

    public static Action onWin;

    public void AddButtonToCurrentSequence(Button newButton)
    {
        bool equals = true;
        currentSequence.Add(newButton);
        if (currentSequence.Count ==  buttons.Count)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                Debug.Log(buttons[i].gameObject.name + ", " + currentSequence[i].gameObject.name);
                if (!buttons[i].Equals(currentSequence[i]))
                {
                    equals = false;
                }
            }
            if (equals)
            {
                onCorrectSequence.Invoke(true);
            }
            else
            {
                currentSequence.RemoveAt(0);
            }
        }
    }

}
