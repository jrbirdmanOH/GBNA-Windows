using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Thayer.Birding;

namespace Thayer.Birding.UI.Windows.Quiz
{
    public partial class QuizWizardPanel : UserControl
    {
        private QuizSettings quizSettings = null;
        protected bool wizardEnabled = true;
        protected bool backEnabled = false;
        protected bool nextEnabled = false;
        protected bool finishEnabled = false;

		private event EventHandler navigationStatusChanged;

		[Browsable(false)]
		public QuizSettings QuizSettings
        {
            get
            {
				if (!DesignMode)
				{
					if (quizSettings == null)
					{
						quizSettings = new QuizSettings();
					}
				}
                return quizSettings;
            }

            set
            {
                quizSettings = value;
            }

        }

		[Browsable(false)]
		public virtual bool WizardEnabled
        {
            get
            {
                return wizardEnabled;
            }

            set
            {
                wizardEnabled = value;
            }
        }

		[Browsable(false)]
		public bool BackEnabled
        {
            get
            {
                return backEnabled;
            }

            set
            {
                backEnabled = value;
				OnNavigationStatusChanged(new EventArgs());
            }
        }

		[Browsable(false)]
		public bool NextEnabled
        {
            get
            {
                return nextEnabled;
            }

            set
            {
                nextEnabled = value;
				OnNavigationStatusChanged(new EventArgs());
            }
        }

		[Browsable(false)]
		public bool FinishEnabled
        {
            get
            {
                return finishEnabled;
            }

            set
            {
                finishEnabled = value;
				OnNavigationStatusChanged(new EventArgs());
            }
        }

		public event EventHandler NavigationStatusChanged
		{
			add
			{
				navigationStatusChanged += value;
			}

			remove
			{
				navigationStatusChanged -= value;
			}
		}

        public QuizWizardPanel()
        {
//            InitializeComponent();
//            Size = new System.Drawing.Size(510, 353);
        }

        public virtual void LoadSettings()
        {
        }

        public virtual void SaveSettings()
        {
        }

        protected virtual void OnNavigationStatusChanged(EventArgs e)
        {
            if (navigationStatusChanged != null)
            {
				navigationStatusChanged(this, e);
            }
        }
    }
}
