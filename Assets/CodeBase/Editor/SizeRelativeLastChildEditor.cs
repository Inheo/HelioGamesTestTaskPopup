using UnityEngine;
using UnityEditor;
using CodeBase.Logic;

namespace Assets.CodeBase.Editor
{
    [CustomEditor(typeof(SizeRelativeLastChild))]
    public class SizeRelativeLastChildEditor : UnityEditor.Editor
    {
        private SizeRelativeLastChild _fiter;

        private void OnEnable()
        {
            _fiter = target as SizeRelativeLastChild;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fit"))
            {
                var fiters = _fiter.GetComponentsInChildren<SizeRelativeLastChild>();

                for (int i = 0; i < fiters.Length; i++)
                {
                    fiters[i].ToFit();
                }
            }
        }
    }
}