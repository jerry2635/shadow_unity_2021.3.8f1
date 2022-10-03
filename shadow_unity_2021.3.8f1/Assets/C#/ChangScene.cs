using UnityEngine;
using UnityEngine.SceneManagement;

namespace jerry
{
    public class ChangScene : MonoBehaviour
    {
        [SerializeField, Header("玩家")]
        private string Player;
        [SerializeField, Header("場景編號")]
        private string SceneNumber;

        private bool DoorArea = false;

        private void OnTriggerEnter2D(Collider2D collision)//用觸發"關閉啟動"布林
        {
            if (Player.Contains(Player))//contains(包含)
            {
                DoorArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (Player.Contains(Player))
            {
                DoorArea = false;
            }
        }

        public void NextScene()
        {
            if (Input.GetKeyDown(KeyCode.E) && DoorArea == true)
            {
                SceneManager.LoadScene(SceneNumber);
            }
            
        }



        void Update()
        {
            NextScene();
        }


    }
}

