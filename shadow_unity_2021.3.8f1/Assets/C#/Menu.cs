using UnityEngine;

namespace jerry
{
    public class Menu : MonoBehaviour
    {
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            Time.timeScale = 0;
           
        }

        public void StartButtonClick()
        {
            Time.timeScale = 1;
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.gameObject.SetActive(false);
        }

        private void Update()
        {
            StartButtonClick();
            Quit();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }

}

