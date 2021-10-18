using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	class Petey
	{
		private static Petey instance = null;

		private const string Gesture = "Gest!";

		public enum Animation
		{
			Acknowledge,
			Show,
			GetAttention,
			Confused,
			GestureDown,
			GestureUp,
			GestureLeft,
			GestureRight,
			Hearing_1,
			Hearing_2,
			Think,
			Alert,
			RestPose,
			DontRecognize,
			Greet,
			StartListening,
			LookDown,
			LookDownBlink,
			LookDownReturn,
			LookLeft,
			LookLeftBlink,
			LookLeftReturn,
			LookUp,
			LookUpBlink,
			LookUpReturn,
			Explain,
			Sad,
			StopListening,
			Surprised,
			Uncertain,
			Decline,
			Idle1_1,
			Idle1_2,
			Idle1_3,
			Idle1_4,
			Idle1_5,
			Hide,
			MoveUp,
			MoveDown,
			MoveRight,
			Idle3_3,
			MoveLeft,
			Suggest,
			Wave,
			Write,
			WriteReturn,
			Writing,
			Searching,
			Idle2_1,
			Congratulate,
			Read,
			ReadReturn,
			Reading,
			GetAttentionContinued,
			GetAttentionReturn,
			Blink,
			WriteContinued,
			Announce,
			ReadContinued,
			Pleased,
			Idle2_2,
			Processing,
			DoMagic1,
			DoMagic2,
			Idle3_1,
			LookDownLeft,
			LookDownLeftBlink,
			LookDownLeftReturn,
			LookDownRight,
			LookDownRightBlink,
			LookDownRightReturn,
			LookUpLeftBlink,
			LookUpLeft,
			LookUpLeftReturn,
			LookUpRight,
			LookUpRightBlink,
			LookUpRightReturn,
			Process,
			Search,
			LookRight,
			LookRightBlink,
			LookRightReturn,
			Idle3_2,
			Hearing_3,
			Thinking
		}

		private AgentObjects.Agent agent;
		private AgentObjects.IAgentCtlCharacterEx petey = null;

		private bool complete = false;
		private object requestObj = null;

		private Petey()
		{
			agent = new AgentObjects.AgentClass();
			agent.Connected = true;
			agent.Characters.Load("Petey", "peedy.acs");
			agent.RequestComplete += new AgentObjects._AgentEvents_RequestCompleteEventHandler(agent_RequestComplete);
			agent.AgentPropertyChange += new AgentObjects._AgentEvents_AgentPropertyChangeEventHandler(agent_AgentPropertyChange);
			petey = agent.Characters["Petey"];
			petey.LanguageID = 0x409;

			if (this.AudioOutputEnabled)
			{
				SetTextToSpeechMode();
			}
			else
			{
				StringBuilder message = new StringBuilder("eField Guide Viewer has detected that ");
				message.Append("the spoken audio output for Petey has been disabled.  ");
				message.Append("To hear Petey speak, select the \"Output\" tab, ");
				message.Append("and check the option for \"Play spoken audio\" on the ");
				message.Append("Advanced Character Options screen.\n\n");
				message.Append("If you choose not to change the settings now, you will be prompted ");
				message.Append("again the next time you run the eField Guide Viewer or you can ");
				message.Append("open Petey's Sandbox and click the \"Options...\" button.");
				message.Append("\n\nDo you want to open the Advanced Character Options screen now?");
				DialogResult result = MessageBox.Show(message.ToString(), "Petey's Audio Disabled", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					ShowAdvancedCharacterOptions();
					while (agent.PropertySheet.Visible)
					{
						Thread.Sleep(250);
					}
				}
			}
        }

		void agent_RequestComplete(object Request)
		{
			if (Request == requestObj)
			{
				complete = true;
			}
		}

		void agent_AgentPropertyChange()
		{
			if (agent.AudioOutput.Enabled)
			{
				SetTextToSpeechMode();
			}
		}

		public static Petey Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Petey();
				}

				return instance;
			}
		}

		public bool Visible
		{
			get
			{
				return petey.Visible;
			}
		}

		public bool AudioOutputEnabled
		{
			get
			{
				return agent.AudioOutput.Enabled;
			}
		}

		public void Hide()
		{
			complete = false;
			requestObj = null;
			petey.StopAll(null);
			requestObj = petey.Hide(null);

			while (!complete)
			{
				Application.DoEvents();
			}
		}

		public void MoveTo(short x, short y)
		{
			short peteyHeightAdjustment = (short)(petey.Height - 10);
			y -= peteyHeightAdjustment;

			if (x < 0)
			{
				x = 0;
			}

			if (y < 0)
			{
				y = 0;
			}

			petey.MoveTo(x, y, null);
		}

		public void Play(Animation animation)
		{
			petey.Play(animation.ToString());
		}

		public void Show()
		{
			complete = false;
			requestObj = null;
			requestObj = petey.Show(null);

			while(!complete)
			{
				Application.DoEvents();
			}
		}

		public void ShowAdvancedCharacterOptions()
		{
			agent.PropertySheet.Visible = true;
		}

		public void Speak(string phrase)
		{
			petey.Speak(phrase, null);
		}

		public void Stop()
		{
			petey.StopAll(null);
		}

		public void PeteySpeech(PeteySpeech speech)
		{
			foreach (string line in speech.Lines)
			{
				if (line.StartsWith(Gesture))
				{
					petey.Play(line.Remove(0, Gesture.Length));
				}
				else
				{
					Speak(line);
				}
			}
			Play(Animation.RestPose);
		}

		private void SetTextToSpeechMode()
		{
			// Note that setting the text to speech mode will throw an exception
			// if the MSAgent AudioOutputEnabled flag is set to false.
			petey.TTSModeID = "{CA141FD0-AC7F-11D1-97A3-006008273001}";
		}
	}
}
