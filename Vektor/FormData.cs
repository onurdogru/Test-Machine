using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace Vektor
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed class FormData : ApplicationSettingsBase
    {
        private static FormData defaultInstance = (FormData)SettingsBase.Synchronized((SettingsBase)new FormData());

        private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
        {
        }

        private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
        {
        }

        public static FormData Default
        {
            get
            {
                return FormData.defaultInstance;
            }
        }
        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("0")]
        public int formSayac
        {
            get
            {
                return (int)this[nameof(formSayac)];
            }
            set
            {
                this[nameof(formSayac)] = (object)value;
            }
        }

      
    }
}