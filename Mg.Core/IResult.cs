using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mg.Core
{
    /// <summary>
    /// 结果对象接口。
    /// <remarks>应用于许多方法中的返回值。</remarks>
    /// </summary>
    public interface IResult
    {
        int ResultID { get; set; }
        string ResultMsg { get; set; }
        bool Succeed { get; }
        object ResultData { get; set; }

        string ResultUrl { get; set; }
    }
}
