﻿using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using UnityEditor;
using UnityEngine;
using XNodeEditor;
using EditorGUIUtility = UnityEditor.Experimental.Networking.PlayerConnection.EditorGUIUtility;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node
{
    [NodeEditor.CustomNodeEditorAttribute(typeof(NPBehaveNode))]
    public class NPBehaveNodeEditor:NodeEditor 
    {
        private NPBehaveNode _node;
        private Color _backColor;

        protected bool Error;
        protected bool Warning;
        
        public void _check()
        {
            if (_node == null) _node = target as NPBehaveNode;
            _backColor = GUI.color;
        }

        public override Color GetTint()
        {
            if (Error)
            {
                return Color.red;
            }

            if (Warning)
            {
                return Color.yellow;
            }

            return base.GetTint();
        }

        protected SerializedProperty OutputSerPro;
        
        public sealed override void OnCreate()
        {
            OutputSerPro = serializedObject.FindProperty(NPBehaveNode.OutputName);
            _check();
            OnInit();
        }

        protected virtual void OnInit()
        {
        }

        public sealed override void OnBodyGUI()
        {
            _reSetColor();
            ColorCheck();
            {
                DrawBody();
            }
        }

        protected virtual void DrawBody()
        {
            base.OnBodyGUI();
        }
        
        protected virtual void ColorCheck()
        {
            var NPBNodeInputs = _node.Inputs.Where(x => typeof(NPBehaveNode).IsAssignableFrom(x.ValueType));
            foreach (var nodePort in NPBNodeInputs)
            {
                if (nodePort.ConnectionCount == 0)
                {
                    Error = true;
                }
            }
        }

        private void _reSetColor()
        {
            Error = false;
            Warning = false;
        }
    }
}