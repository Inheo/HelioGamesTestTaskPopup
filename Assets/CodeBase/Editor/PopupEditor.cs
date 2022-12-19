using CodeBase.Logic;
using UnityEditor;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(Popup))]
    public class PopupEditor : UnityEditor.Editor
    {
        private Popup _popup;

        private void OnEnable()
        {
            _popup = target as Popup;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var sizeChangers = _popup.GetComponentsInChildren<SizeRelativeLastChild>();

            for (int i = 0; i < sizeChangers.Length; i++)
            {
                sizeChangers[i].ToFit();
            }
        }
    }
}