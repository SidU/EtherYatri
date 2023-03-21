#region Copyright
#endregion

#region Credits
/**
 * August 10, 2003, 1:25am: Written by Siddharth Uppal (siddharthuppal@yahoo.co.in).
 */
#endregion

using System;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace AgentHost2003
{
	/// <summary>
	/// Writes into the Textbox.
	/// </summary>
	public class TextBoxWriter : TextWriter
	{
		#region Instance Fields

		private TextBox textBox;
		
		#endregion

		#region Constructors
		
		public TextBoxWriter(TextBox textBox)
		{
			this.textBox = textBox;
		}
		
		#endregion 
		
		#region Properties
		
		public override Encoding Encoding	
		{
			get
			{
				return Encoding.Default;
			}
		}
		
		#endregion
		
		#region Methods

		public override void Write(char c)
		{
			this.textBox.Text = this.textBox.Text + c.ToString();
		}


		public override void Write(string s)
		{
			this.textBox.Text = this.textBox.Text + s;
		}


		public override void WriteLine(string s)
		{
			this.textBox.Text = this.textBox.Text + s + this.NewLine;
		}

		#endregion
	}
}
