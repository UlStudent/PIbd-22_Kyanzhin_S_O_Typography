using System;
using System.Collections.Generic;
using System.Text;
using TypographyBusinessLogic.Interfaces;

namespace TypographyBusinessLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }
        public int PopPort { get; set; }
        public IMessageInfoStorage Storage { get; set; }
        public IClientStorage ClientStorage { get; set; }
    }
}
