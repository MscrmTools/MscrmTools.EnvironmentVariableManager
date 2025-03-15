using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MscrmTools.EnvironmentVariableManager.AppCode
{
    internal class SolutionInfo
    {
        private Entity _record;

        public SolutionInfo(Entity record)
        {
            _record = record;
        }

        public string UniqueName => _record.GetAttributeValue<string>("uniquename");

        public override string ToString()
        {
            return _record.GetAttributeValue<string>("friendlyname");
        }
    }
}