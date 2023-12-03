using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week9_1.Shared.Services;

namespace Week9_1.WebApi.Services
{
    public class TextService : ITextService
    {
        private readonly string _path;

        public TextService()
        {
            _path = "C:\\Users\\e\\Desktop\\passwords.txt";
        }
        //public TextService(string path)
        //{
        //    _path = path;
        //}
        public void Save(string text)
        {
            //File.WriteAllText(_path, text);
            File.AppendAllText(_path, text + "\n");
            
        }
    }
}
