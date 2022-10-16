using UnityEngine;

namespace jerry
{
    /// <summary>
    /// Ū����r�ɸ��.�W�ٻP����
    /// scriptableObject �}���ƪ���
    /// </summary>
    [CreateAssetMenu(menuName ="jerry/Data Text", fileName = "Data Text")]
    public class ReadText : ScriptableObject
    {
        /* ���A�ε{��
        string WordPath;

        [Header("��ܤ�r�����")]
        public string WordData;
        [Header("��ܤ�r�����")]
        public string[] WordDatas;

        private void Awake()
        {
            WordPath = Application.streamingAssetsPath + "/WordText";
            WordData = File.ReadAllText(WordPath);//Ū�����e
            WordDatas = WordData.Split('\n');//Ū���������
        }
        */

        /* ��r�u�ɤJ��"���O"(���A��)
        public TextAsset textFile; //���ɤJ
        void GetTextFormFile(TextAsset file)
        {
            //�N���ɤ�r���Ψ��x�s���r��}�C
            string[] lineDate = file.text.Split('\n');//����N����.(�u����ܳ����?)
            //�L�X�C�椺�e
            foreach(var line in lineDate)
            {
                Debug.Log(line);
            }
        }
        private void Start()
        {
            GetTextFormFile(textFile);
            Debug.Log("next");
        }
        */

        [Header("���/NPC�W��")]
        public string TextTitleName;
        [Header("�Ҧ����"), NonReorderable]//nonreorderable �T���԰}�C�Ƨ�
        public Datadialogue[] datadialogues;

        //�ǦC�����O
        [System.Serializable]
        public class Datadialogue
        {
            [Header("��ܤ��e")]
            public string content;
            [Header("��ܭ���")]
            public AudioClip sound;
        }
    }
}

