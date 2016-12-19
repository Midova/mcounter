using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyCounter.Services
{
	public class ConfirmationRequestService : IConfirmationRequestService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		/// <param name="buttons"></param>
		/// <param name="image"></param>
		/// <returns></returns>
		public MessageBoxResult RequestConfirmation(string text, string caption, MessageBoxButton buttons, MessageBoxImage image)
		{
			return MessageBox.Show(text, caption, buttons, image);
		}
		
	}
}
