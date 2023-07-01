using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SynchronizationService
{
    public partial class Service1 : ServiceBase
    {
        public SyncEngine syncServicesyncService = null;
        public Service1()
        {
            InitializeComponent();
            syncServicesyncService = new SyncEngine();
        }

        protected override void OnStart(string[] args)
        {
            syncServicesyncService.StartService_Click(null, null);
        }

        protected override void OnStop()
        {
            syncServicesyncService.StopService_Click(null, null);
        }
    }
}
