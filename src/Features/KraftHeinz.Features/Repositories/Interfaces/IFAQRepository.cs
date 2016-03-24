using KraftHeinz.Features.Models.FAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KraftHeinz.Features.Repositories.Interfaces
{
    public interface IFAQRepository
    {
        FAQ GetFAQ();
    }
}
