﻿using System;
using UIKit;
using Foundation;
using EndoBindingXamarin;
using LilitabXamarinBinding;

namespace EndoClientDemo
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
		}

        partial void endoStopBtnClick(UIButton sender)
        {
            Endo.Stop();
		}

        partial void endoStartBtnClick(UIButton sender)
        {
            Endo.Start();
		}

        partial void lilitabStatusBtn(UIButton sender)
        {
			LilitabSDK.Singleton.Status((bool arg1, Foundation.NSDictionary arg2) =>
			{
				Endo.Log(arg2.Description);
				if (arg1)
				{
					textView.Text = "True:\n" + arg2.Description;
				}
				else
				{
					textView.Text = "False:\n" + arg2.Description;
				}
			});
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}