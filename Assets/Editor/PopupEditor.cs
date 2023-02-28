using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class PopupEditor : EditorWindow  
    {
        private const string PopupPath = "Popup";
        private string _titleText = "New Popup";
        private string _contentText = "";
        private ButtonType _buttonType;
        private int _sortOrder = 10;
    
        [MenuItem ("Window/Popup Editor")]
        public static void  ShowWindow () {
            GetWindow(typeof(PopupEditor));
        }
        void OnGUI () {
            GUILayout.Label ("Popup Settings", EditorStyles.boldLabel);
            _titleText = EditorGUILayout.TextField ("Title text", _titleText);
            _sortOrder = EditorGUILayout.IntField("Sort order", _sortOrder);
            _contentText = EditorGUILayout.TextField ("Content text", _contentText);
            _buttonType = (ButtonType)EditorGUILayout.EnumPopup("Button type", _buttonType);

            if (GUILayout.Button("Create")) 
                InstantiateAndAddQueue();

            if (GUILayout.Button("ShowAll"))
                ShowAllPopupsInScene();
        }

        private void ShowAllPopupsInScene()
        {
            var popupSystem = FindObjectOfType<PopupSystem>();
            popupSystem.ShowAllPopups();
        }

        private void InstantiateAndAddQueue()
        {
            var popup = Resources.Load<Popup>(PopupPath);
            popup.Construct(_titleText, _contentText, _sortOrder, _buttonType);
            var popupSystem = FindObjectOfType<PopupSystem>();
            var gameObject = Instantiate(popup, popupSystem.transform);
            gameObject.name = _titleText;
            popupSystem.AddToQueue(popup);
        }
    }
}
