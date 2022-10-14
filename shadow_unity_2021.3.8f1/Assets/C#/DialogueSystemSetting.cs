using UnityEngine;
using TMPro;
using System.Collections;//�ޥΨt��_��ƨt�ε��c��P

namespace jerry
{
    /// <summary>
    /// ��ܤ�r�t��.�زH�J.��s�W��.��s��Ƥ��e.����X.�زH�X
    /// </summary>
    public class DialogueSystemSetting : MonoBehaviour
    {
        [SerializeField, Header("�e����r�بt��")]
        private CanvasGroup groupDialogue;
        [SerializeField, Header("�e����r�بt��")]//TMP��r�t��.using TMPro �ޥ�
        private TextMeshProUGUI textName;//���ɦW��
        [SerializeField, Header("�e����r�بt��")]
        private TextMeshProUGUI textContent;//���ɤ��e

        private AudioSource aud;//�إ߭����W��aud

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
            StartCoroutine(TextPass());
        }

        private IEnumerator TextPass()//��P�����\��W��IEnumerator
        {
            print("�Ĥ@���r");
            yield return new WaitForSeconds(2);//�����
                                               //return �O�^�Ǩð���᭱�{�����B�@
                                               //yield(���B/�h��) return ����즹�^��.�U���{���~�����
            print("�ĤG���r");                //�o�䪺�^��.���ӷ|��s��ܮؤ�r
            yield return new WaitForSeconds(2);
            print("�ĤT���r");
        }
    }
}

