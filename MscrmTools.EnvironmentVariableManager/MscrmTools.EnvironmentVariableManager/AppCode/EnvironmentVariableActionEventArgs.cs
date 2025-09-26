using Microsoft.Xrm.Sdk;
using System;

namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    public class EnvironmentVariableActionEventArgs : EventArgs
    {
        public Entity Definition { get; set; }

        public Entity Solution { get; set; }
    }
}