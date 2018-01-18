﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aliapoh.Overlay.GlobalHook
{
    /**
     * Code from OverlayPlugin Window.cs
     */
    public class Window : NativeWindow, IDisposable
    {
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public Window()
        {
            CreateHandle(new CreateParams());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x0312)
            {
                var key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                var modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);
                if (KeyPressed != null)
                    KeyPressed(this, new KeyPressedEventArgs(modifier, key));
            }
        }

        public void Dispose()
        {
            DestroyHandle();
        }
    }
}