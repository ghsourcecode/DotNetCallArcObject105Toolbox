using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.IO;
using System.Windows.Forms;

namespace NetCallArcObject105Toolbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //调用系统自带 toolbox
            callSystemToolbox();

            //调用自定义toolbox
            callCustomerToolbox();

            InitializeComponent();
        }

        /// <summary>
        /// 调用系统自带toolbox
        /// </summary>
        public static void callSystemToolbox()
        {
            DirectoryInfo rootDir = Directory.GetParent(Environment.CurrentDirectory);
            string root = rootDir.Parent.Parent.FullName;//路径最后不带\

            //using ESRI.ArcGIS.Geoprocessing
            //GeoGeoprocessing 是一个COM Interop程序集, COM Interop看上去像是介乎于COM和.Net之间的一条纽带，一座桥梁
            IGeoProcessor2 gp = new GeoProcessorClass();
            gp.OverwriteOutput = true;

            IVariantArray parameters = new VarArrayClass();
            parameters.Add(root + "\\NetCallArcObject105Toolbox\\resource\\data\\dawen.shp");
            parameters.Add(root + "\\NetCallArcObject105Toolbox\\resource\\result\\Copy4");

            object sev1 = null;
            try
            {
                gp.Execute("CopyFeatures", parameters, null);
                Console.WriteLine(gp.GetMessages(ref sev1));
            }
            catch (Exception ex)
            {
                Console.WriteLine(gp.GetMessages(ref sev1));
            }
        }

        /// <summary>
        /// 调用自定义toolbox
        /// 在调用自定义toolbox内工具时，传递的参数顺序一定要与工具接收的参数顺序一致
        /// </summary>
        private void callCustomerToolbox()
        {
            DirectoryInfo rootDir = Directory.GetParent(Environment.CurrentDirectory);
            string root = rootDir.Parent.Parent.FullName;

            //第 1 种调用方式：
            //using ESRI.ArcGIS.Geoprocessing
            //GeoGeoprocessing 是一个COM Interop程序集, COM Interop看上去像是介乎于COM和.Net之间的一条纽带，一座桥梁
            IGeoProcessor2 gpc = new GeoProcessorClass();
            gpc.OverwriteOutput = true;
            gpc.AddToolbox(root + "\\NetCallArcObject105Toolbox\\resource\\customertoolbox\\ZCustomer.tbx");
            IVariantArray parameters1 = new VarArrayClass();
            //parameters1.Add(@"E:\ArcGISGeoprocess\data\rain_2016_09_15__08_00_hourly.flt");
            //parameters1.Add(@"E:\ArcGISGeoprocess\data\rain_2016_prj.tif");

            parameters1.Add(root + "\\NetCallArcObject105Toolbox\\resource\\data\\rain_2016.flt");
            parameters1.Add("0 0.240362 1;0.240362 0.677384 2;0.677384 1.136257 3;1.136257 1.638832 4;1.638832 2.163258 5;2.163258 2.731386 6;2.731386 3.430621 7;3.430621 4.304665 8;4.304665 5.593879 9");
            parameters1.Add(root + "\\NetCallArcObject105Toolbox\\resource\\result\\rain_2016.json");

            object sev1 = null;
            IGeoProcessorResult result = new GeoProcessorResultClass();
            try
            {
                result = gpc.Execute("ProduceJsonFromFltWithNoProject", parameters1, null);
                Console.WriteLine(gpc.GetMessages(ref sev1));
            }
            catch (Exception ex)
            {
                Console.WriteLine(gpc.GetMessages(ref sev1));
            }

            //第 2 种调用方式：
            //using ESRI.ArcGIS.Geoprocessor
            //Geoprocessor 是一个托管程序集
            Geoprocessor GP = new Geoprocessor();
            GP.OverwriteOutput = true;
            GP.AddToolbox(root + "\\NetCallArcObject105Toolbox\\resource\\customertoolbox\\ZCustomer.tbx");

            IVariantArray parameters2 = new VarArrayClass();
            parameters2.Add(root + "\\NetCallArcObject105Toolbox\\resource\\data\\rain_2016.flt");
            parameters2.Add(root + "\\NetCallArcObject105Toolbox\\resource\\result\\rain_2016.tif");

            //parameters2.Add(@"E:\ArcGISGeoprocess\data\rain_2016_09_15__08_00_hourly.flt");
            //parameters2.Add("0 0.240362 1;0.240362 0.677384 2;0.677384 1.136257 3;1.136257 1.638832 4;1.638832 2.163258 5;2.163258 2.731386 6;2.731386 3.430621 7;3.430621 4.304665 8;4.304665 5.593879 9");
            //parameters2.Add(@"E:\ArcGISGeoprocess\data\rain_2016_1.json");

            object sev2 = null;
            try
            {
                GP.Execute("ModelTest", parameters2, null);
                Console.WriteLine(GP.GetMessages(ref sev2));
            }
            catch (Exception ex)
            {
                Console.WriteLine(GP.GetMessages(ref sev2));
            }
        }
    }
}
