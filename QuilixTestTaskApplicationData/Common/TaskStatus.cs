using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Qulix.Data.Common
{
    /// <summary>
    /// Task status enum
    /// </summary>
    public enum TaskStatus
    {
        [Display(Name = "Not started")]
        NotStarted,
        [Display(Name = "In process")]
        InProcess,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Postponed")]
        Postponed
    }
}
