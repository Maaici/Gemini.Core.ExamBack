using Gemini.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gemini.IServices
{
    public interface IExamineeService
    {
        string Register(AccountViewModel model);
    }
}
