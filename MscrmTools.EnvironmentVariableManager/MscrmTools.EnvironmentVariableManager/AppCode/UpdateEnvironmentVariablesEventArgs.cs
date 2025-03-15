using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    public class UpdateEnvironmentVariablesEventArgs : EventArgs
    {
        public List<Entity> Variables { get; set; }
    }
}