using SangAdv.Common.ListExtensions;
using System;
using System.Collections.Generic;

namespace FPMyobAssistant
{
    internal class MANodeExpanded
    {
        #region Variables

        private List<string> mExpandedNodes = new List<string>();

        #endregion Variables

        #region Methods

        internal bool IsExpended(int moduleId, string Id)
        {
            if (moduleId == 0) throw new Exception(nameof(moduleId));
            return mExpandedNodes.Contains($"{moduleId}-{Id}");
        }

        internal void Add(int moduleId, string Id)
        {
            if (moduleId == 0) throw new Exception(nameof(moduleId));
            mExpandedNodes.AddUnique($"{moduleId}-{Id}");
        }

        internal void Remove(int moduleId, string Id)
        {
            if (moduleId == 0) throw new Exception(nameof(moduleId));
            mExpandedNodes.Remove($"{moduleId}-{Id}");
        }

        #endregion Methods
    }
}