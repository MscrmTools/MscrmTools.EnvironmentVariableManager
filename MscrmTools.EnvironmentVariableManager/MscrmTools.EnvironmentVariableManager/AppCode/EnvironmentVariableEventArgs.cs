using Microsoft.Xrm.Sdk;
using System;

namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    public class EnvironmentVariableEventArgs : EventArgs
    {
        public Entity Definition { get; set; }
        public Guid DefinitionId { get; set; }
        public Guid VariableId { get; set; }
    }
}