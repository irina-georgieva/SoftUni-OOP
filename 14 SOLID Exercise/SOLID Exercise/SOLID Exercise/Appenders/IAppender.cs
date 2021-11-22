using SOLID_Exercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }

        void Append(string datetime, string reportLevel, string message);
    }
}
