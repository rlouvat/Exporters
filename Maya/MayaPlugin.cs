using Autodesk.Maya.OpenMaya;
using Maya2Babylon.Forms;
using Maya2Babylon.Importer.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

[assembly: MPxCommandClass(typeof(Maya2Babylon.toBabylon), "toBabylon")]
[assembly: ExtensionPlugin(typeof(Maya2Babylon.MayaPlugin), "Any")]
[assembly: MPxCommandClass(typeof(Maya2Babylon.AnimationGroups), "AnimationGroups")]
[assembly: MPxCommandClass(typeof(Maya2Babylon.GltfImporter), "GltfImporter")]

namespace Maya2Babylon
{
    public class MayaPlugin : IExtensionPlugin
    {
        /// <summary>
        /// Path to the Babylon menu
        /// </summary>
        string MenuPath;

        bool IExtensionPlugin.InitializePlugin()
        {
            // Add menu to main menu bar
            MenuPath = MGlobal.executeCommandStringResult($@"menu - parent MayaWindow - label ""Babylon"";");
            // Add item to this menu
            MGlobal.executeCommand($@"menuItem - label ""Babylon File Exporter..."" - command ""toBabylon"";");
            MGlobal.executeCommand($@"menuItem - label ""Animation groups"" - command ""AnimationGroups"";");
            MGlobal.executeCommand($@"menuItem - label ""Import glTF file"" - command ""GltfImporter"";");

            MGlobal.displayInfo("Babylon plug-in initialized");
            return true;
        }

        bool IExtensionPlugin.UninitializePlugin()
        {
            // Remove menu from main menu bar and close the form
            MGlobal.executeCommand($@"deleteUI -menu ""{MenuPath}"";");

            MGlobal.displayInfo("Babylon plug-in uninitialized");

            toBabylon.disposeForm();
            
            return true;
        }

        string IExtensionPlugin.GetMayaDotNetSdkBuildVersion()
        {
            String version = "20171207";
            return version;
        }
    }

    public class toBabylon : MPxCommand, IMPxCommand
    {
        private static ExporterForm form;

        /// <summary>
        /// Entry point of the plug in
        /// Write "toBabylon" in the Maya console to start it
        /// </summary>
        /// <param name="argl"></param>
        public override void doIt(MArgList argl)
        {
            if (form == null)
                form = new ExporterForm();
            form.Show();
            form.BringToFront();
            form.WindowState = FormWindowState.Normal;
            form.closingByUser = () => { return disposeForm(); };
            // TODO - save states - FORM: checkboxes and inputs. MEL: reselected meshes / nodes?
            form.closingByShutDown = () => { return disposeForm(); };
            // form.closingByCrash = () => { return disposeForm(); };
        }
        public static bool disposeForm()
        {
            if (form != null)
            {
                form.Dispose();
                form = null;
            }
            return true;
        }
    }

    /// <summary>
    /// For the animation groups form
    /// </summary>
    public class AnimationGroups : MPxCommand, IMPxCommand
    {
        public static AnimationForm animationForm = null;

        public override void doIt(MArgList args)
        {
            if (animationForm == null)
            {
                animationForm = new AnimationForm();
                animationForm.On_animationFormClosed += On_animationFormClosed;
            }

            animationForm.Show();
            animationForm.BringToFront();
            animationForm.WindowState = FormWindowState.Normal;
        }

        private void On_animationFormClosed()
        {
            animationForm = null;
        }
    }

    /// <summary>
    /// For the glTF importer
    /// </summary>
    public class GltfImporter : MPxCommand, IMPxCommand
    {
        private static ImporterForm importerForm = null;

        public override void doIt(MArgList args)
        {
            if (importerForm == null)
            {
                importerForm = new ImporterForm();
                importerForm.On_importerFormClosed += On_importerFormClosed;
            }

            importerForm.Show();
            importerForm.BringToFront();
            importerForm.WindowState = FormWindowState.Normal;
        }

        private void On_importerFormClosed()
        {
            importerForm = null;
        }
    }
}
