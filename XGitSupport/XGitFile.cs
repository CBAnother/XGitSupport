using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGitSupport
{
    class XGitFile
    {
        #region Values
        /// <summary>
        /// 在当前项目中的相对地址, 例如根地址为 D:/Code/dev-xxx-xiaoyi, 文件地址为 D:/Code/dev-xxx-xiaoyi/inc/yyy.lib
        /// <para>则 cur_file = inc/yyy.lib</para>
        /// </summary>
        public string cur_file;
        /// <summary>
        /// 在git中它的相对地址, 例如根地址为 https/xxx/dev-xxx-xiaoyi, 文件地址为 https/xxx/dev-xxx-xiaoyi/inc/yyy.lib
        /// <para>则 git_file = inc/yyy.lib</para>
        /// </summary>
        public string git_file;
        #endregion
    }
}
