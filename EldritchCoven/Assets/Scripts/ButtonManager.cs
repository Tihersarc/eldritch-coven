using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private List<Button> buttons;

    private List<Button> currentSequence = new List<Button>();

    private static ButtonManager buttonManager;

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

    public void AddButtonToCurrentSequence(Button newButton)
    {
        bool equals = true;
        currentSequence.Add(newButton);
        if (currentSequence.Count ==  buttons.Count)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (!buttons[i].Equals(currentSequence[i]))
                {
                    equals = false;
                }
            }
            if (equals)
            {
                Debug.Log("win");
            }
            else
            {
                currentSequence.RemoveAt(0);
            }
        }
    }

}
