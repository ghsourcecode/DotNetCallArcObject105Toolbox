using ESRI.ArcGIS.esriSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCallArcObject105Toolbox
{
    static class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new NetCallArcObject105Toolbox.LicenseInitializer();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code. 添加许可
            m_AOLicenseInitializer.InitializeApplication(
                new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeAdvanced },
                new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
            m_AOLicenseInitializer.ShutdownApplication();
        }
    }
}
