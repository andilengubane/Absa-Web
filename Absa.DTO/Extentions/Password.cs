using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absa.DTO.Extentions
{
	public class Password
	{
		public char[] RandomPassword()
		{
			var numberOfChars = 8;
			var upperCase = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			var lowerCase = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
			var numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
			var specialCharacters = new char[] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+' };
			var random = new Random();

			var total = upperCase.Concat(lowerCase).Concat(numbers).Concat(specialCharacters).ToArray();
			var chars = Enumerable.Repeat<int>(0, numberOfChars).Select(i => total[random.Next(total.Length)]).ToArray();

			return chars;
		}
	}
}
