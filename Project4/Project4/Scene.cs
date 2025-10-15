using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal abstract class Scene
    {
        /// <summary>
        /// 화면 호출하는 메서드.
        /// 화면에 출력해야하는 내용이 여기 들어가야 한다.
        /// </summary>
        internal abstract void Show();
    }
}
