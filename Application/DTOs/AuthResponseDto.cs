using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
