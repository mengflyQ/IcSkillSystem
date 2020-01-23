using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector2Int Value")]
    public partial class Vector2IntValueNode:ValueNode<IcVariableVector2Int>
    {
        [SerializeField]
        private UnityEngine.Vector2Int _value;
   
        private IcVariableVector2Int _variableValue = new IcVariableVector2Int();
   
        protected override IcVariableVector2Int GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}