using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week9_1.Shared.Services;

namespace Week9_1.Shared.Utilities
{
	public class PasswordGenerator
	{
		private readonly ITextService _textService;
		public int GeneratedPasswordsCount { get; set; } = 0; //for see the total generated passwords count using dependancy injection

		private readonly Random _random;

		private const string Numbers = "0123456789";
		private const string SpecialChars = "!@#$%^&*()";
		private const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
		private const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string Full = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()";

        public PasswordGenerator(ITextService textService)
        {
            _random = new Random();
            _textService = textService;
        }

        public string Generate(int passwordLength, bool includeNumbers, bool includeLowerCase, bool includeUpperCase, bool includeSpecialChars)
		{
			var charsBuilder = new StringBuilder();

			if (includeNumbers)
				charsBuilder.Append(Numbers);

			if (includeLowerCase)
				charsBuilder.Append(LowerCaseChars);

			if (includeUpperCase)
				charsBuilder.Append(UpperCaseChars);

			if (includeSpecialChars)
				charsBuilder.Append(SpecialChars);

			var acceptedChars = charsBuilder.ToString();

			var passwordBuilder = new StringBuilder();


			for (int i = 0; i < passwordLength; i++)
			{
				var randomIndex = _random.Next(0, acceptedChars.Length);

				passwordBuilder.Append(acceptedChars[randomIndex]);
			}

			GeneratedPasswordsCount++;

			//saving the password to a file
			var password = passwordBuilder.ToString();


			_textService.Save(password);

			return password;
		}
	}
}
