namespace Watcher.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MonitorProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.MonitorServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // MonitorProcessInstaller
            // 
            this.MonitorProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.MonitorProcessInstaller.Password = null;
            this.MonitorProcessInstaller.Username = null;
            // 
            // MonitorServiceInstaller
            // 
            this.MonitorServiceInstaller.Description = "DataMicron Folder Watch Service";
            this.MonitorServiceInstaller.DisplayName = "DataMicron Folder Watch Service";
            this.MonitorServiceInstaller.ServiceName = "Datamicron.Services.Watcher";
            this.MonitorServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MonitorProcessInstaller,
            this.MonitorServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller MonitorServiceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller MonitorProcessInstaller;
    }
}