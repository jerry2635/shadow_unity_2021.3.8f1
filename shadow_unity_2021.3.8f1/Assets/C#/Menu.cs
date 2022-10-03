using UnityEngine;

namespace jerry
{
    public class Menu : MonoBehaviour
    {
        private bool isPause = false;

        //public Button Pautton;
        //public GameObject PauseWindow;

        private void Start()
        {
            
        }
        
        private void Update()
        {
            TimeStop();
            Quit();
        }

        #region ¼È°±/±Ò°Ê¿ï³æ

        private void TimeStop()
        {
            if (isPause == false)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void MenuKeyControl()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = false;
                
            }
        }

        #endregion

        public void Quit()
        {
            Application.Quit();
        }
    }

}

