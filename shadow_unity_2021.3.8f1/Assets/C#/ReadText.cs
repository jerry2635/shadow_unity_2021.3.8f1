using UnityEngine;

namespace jerry
{
    /// <summary>
    /// 讀取文字檔資料.名稱與音效
    /// scriptableObject 腳本化物件
    /// </summary>
    [CreateAssetMenu(menuName ="jerry/Data Text", fileName = "Data Text")]
    public class ReadText : ScriptableObject
    {
        /* 不適用程式
        string WordPath;

        [Header("顯示文字資料檔")]
        public string WordData;
        [Header("顯示文字資料檔")]
        public string[] WordDatas;

        private void Awake()
        {
            WordPath = Application.streamingAssetsPath + "/WordText";
            WordData = File.ReadAllText(WordPath);//讀取內容
            WordDatas = WordData.Split('\n');//讀取之後切割
        }
        */

        /* 文字只導入至"指令"(不適用)
        public TextAsset textFile; //文件導入
        void GetTextFormFile(TextAsset file)
        {
            //將文檔文字分割並儲存成字串陣列
            string[] lineDate = file.text.Split('\n');//換行就切割.(只能顯示單行對話?)
            //印出每行內容
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

        [Header("文件/NPC名稱")]
        public string TextTitleName;
        [Header("所有對話"), NonReorderable]//nonreorderable 禁止拖拉陣列排序
        public Datadialogue[] datadialogues;

        //序列化類別
        [System.Serializable]
        public class Datadialogue
        {
            [Header("對話內容")]
            public string content;
            [Header("對話音效")]
            public AudioClip sound;
        }
    }
}

