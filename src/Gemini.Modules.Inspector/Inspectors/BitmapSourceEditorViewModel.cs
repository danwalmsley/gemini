﻿using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Caliburn.Micro;
using Gemini.Framework.Results;
using Microsoft.Win32;

namespace Gemini.Modules.Inspector.Inspectors
{
    public class BitmapSourceEditorViewModel : EditorBase<BitmapSource>
    {
        public IEnumerable<IResult> Choose()
        {
            var fileDialog = new OpenFileDialog();
            yield return Show.Dialog(fileDialog);
            
            using (var stream = fileDialog.OpenFile())
            {
                var result = new BitmapImage();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();

                Value = result;
            }
        }
    }
}