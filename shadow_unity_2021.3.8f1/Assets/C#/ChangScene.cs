using UnityEngine;
using UnityEngine.SceneManagement;

namespace jerry
{
    public class ChangScene : MonoBehaviour
    {
        [SerializeField, Header("���a")]
        private string Player;
        [SerializeField, Header("�����s��")]
        private string SceneNumber;

        private bool DoorArea = false;

        private void OnTriggerEnter2D(Collider2D collision)//��Ĳ�o"�����Ұ�"���L
        {
            if (Player.Contains(Player))//contains(�]�t)
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

