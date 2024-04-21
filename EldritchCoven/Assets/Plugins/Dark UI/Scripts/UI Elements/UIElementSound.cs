using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.UI.Dark
{
    public class UIElementSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {
        // Resources
        public StudioListener audioSource;
        
        public StudioEventEmitter hoverSound; //public AudioClip hoverSound;
        public StudioEventEmitter clickSound; //public AudioClip clickSound;

        // Settings
        public bool enableHoverSound = true;
        public bool enableClickSound = true;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (audioSource != null && enableHoverSound == true)
                hoverSound.Play(); //audioSource.PlayOneShot(hoverSound);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (audioSource != null && enableClickSound == true)
                clickSound.Play(); //audioSource.PlayOneShot(clickSound);
        }
    }
}