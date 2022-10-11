using UnityEngine;

namespace jerry
{
    public class Menu : MonoBehaviour
    {
        private bool isPause = false;
        private bool OpenTheMenu = false;

        private void Start()
        {

        }

        private void Update()
        {
            MenuKeyControl();
            TimeStop();
            Quit();
        }

        #region ¼È°±/±Ò°Ê¿ï³æ

        private void TimeStop()
        {
            if (isPause == false) { Time.timeScale = 1; }
            else { Time.timeScale = 0; }
        }

        private void MenuKeyControl()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPause = true;

            }
        }

        #endregion

        public void Quit()
        {
            Application.Quit();
        }
    }

}

