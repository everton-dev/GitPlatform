using Git.Platform.Context;
using Git.Platform.Operation.Interfaces.RuleInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Platform.Operation.Main
{
    public class OperationMain
    {
        #region Rules
        public IRuleService RuleService { get; set; }
        #endregion

        #region Constructor
        public OperationMain()
        {
            ContextSetup oContextSetup = new ContextSetup(ConfigurationManager.AppSettings["PATH_CONTEXT"]);
            this.RuleService = (IRuleService) oContextSetup.Context.InjectionClassList[0].Instance;
        }
        #endregion

        #region Public
        public void Start()
        {
            this.RuleService.Start();
        }
        #endregion
    }
}
