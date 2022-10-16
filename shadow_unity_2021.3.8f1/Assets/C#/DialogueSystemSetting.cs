using UnityEngine;
using TMPro;
using System.Collections;//�ޥΨt��_��ƨt�ε��c��P
using System;

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
        [SerializeField, Header("��ܤ޾�")]
        private GameObject dialogueTip;//�إ�����m�޾ɪ���

        private AudioSource aud;//�إ߭����W��aud

        public ReadText dataText;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();

            StartCoroutine(StartDialogueFrame());//�ܧ󬰨�{.�~�౵���^�ǭ�
        }

        public IEnumerator StartDialogueFrame()//�X�ֶ���.�ܧ�IEnumerator/��{.�~��ϥ�yield return/�Ȱ��^��
        {
            textName.text = dataText.TextTitleName;//�b�}�Үɧ��datatext�����D���Y
            textContent.text = "";//���D���Y��l���ť�

            yield return StartCoroutine(TextPass());
            yield return StartCoroutine(TypeEffect());
        }

        private IEnumerator TextPass()//��P�����\��W��IEnumerator
        {
            //return �O�^�Ǩð���᭱�{�����B�@
            //yield(���B/�h��) return ����즹�^��.�U���{���~�����
            //�o�䪺�^��.���ӷ|��s��ܮؤ�r
            for (int i = 0; i < 10; i++)//�]�w����Q��
            {
                groupDialogue.alpha += 0.1f;
                yield return new WaitForSeconds(0.5f);//�C0.5��W�[0.1�i����
            }

            StartCoroutine(TypeEffect());//��for�j����槹����.����J�r���S��
        }

        private IEnumerator TypeEffect()
        {
            aud.PlayOneShot(dataText.datadialogues[0].sound);//playoneshot������������

            string content = dataText.datadialogues[0].content;//�r��.�}�C[0]
            for (int i = 0; i < content.Length; i++)//content.length�O���}�C�̭����r��
            {
                textContent.text += content[i];
                yield return new WaitForSeconds(0.05f);
            }

            dialogueTip.SetActive(true);//����ܧ�����.�|��ܹ�ܤ޾�
        }
    }
}

