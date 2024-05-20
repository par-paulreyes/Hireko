using System;
using System.IO;
using System.Windows.Forms;

namespace Hireko.Forms
{
    internal abstract partial class BaseForm : Form
    {
        protected HirekoForm hirekoForm;

        protected BaseForm(HirekoForm form)
        {
            hirekoForm = form;
            InitializeMediaPlayer();
        }

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;

        protected void InitializeMediaPlayer()
        {
            mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            mediaPlayer.CreateControl();
            mediaPlayer.Visible = false;
            mediaPlayer.settings.autoStart = false;
            Controls.Add(mediaPlayer);
        }

        protected void PlayAudio(string file)
        {
            string solutionDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));
            string filePath = Path.Combine(solutionDirectory, $@"SFX\{file}");
            mediaPlayer.URL = filePath;
            mediaPlayer.Ctlcontrols.play();
        }

        protected void ShowForm(Form form)
        {
            hirekoForm.ShowForm(form);
        }
    }
}
