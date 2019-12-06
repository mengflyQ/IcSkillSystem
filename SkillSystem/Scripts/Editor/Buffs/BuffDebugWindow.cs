﻿using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using UnityEditor;
using EditorGUI = UnityEditor.EditorGUI;
using EditorGUILayout = UnityEditor.EditorGUILayout;

namespace  CabinIcarus.IcSkillSystem.Editor
{
    public class BuffDebugWindow : EditorWindow
    {
        public static IBuffManager<IIcSkSEntity> EntityManager;
        
        [UnityEditor.MenuItem("Icarus/Analysis/IIcSkSEntity Buff")]
        private static void ShowWindow()
        {
            var window = GetWindow<BuffDebugWindow>();

            window.titleContent = new UnityEngine.GUIContent("Buff Analysis");
            window.Show();
        }
        
        private void OnGUI()
        {
            if (EntityManager == null)
            {
                EditorGUILayout.HelpBox("please set EntityManager -> BuffDebugWindow.EntityManager",
                    MessageType.Warning);
                return;
            }

            var entitys = EntityManager.Entitys;

            EditorGUILayout.LabelField("Entity count:" + entitys.Count);

            EditorGUI.indentLevel++;
            foreach (var entity in entitys)
            {
                EditorGUILayout.LabelField($"{entity} Buff Count:" +
                                           EntityManager.GetAllBuff(entity).Count());
            }

            EditorGUI.indentLevel--;
        }
    }
}