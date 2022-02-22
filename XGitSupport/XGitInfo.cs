using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGitSupport
{
    class XGitInfo
    {
        #region Values
        /// <summary>
        /// git 网址
        /// </summary>
        public string url;

        /// <summary>
        /// commit 的 id
        /// </summary>
        public string commit_id;

        /// <summary>
        /// 所有文件的地址
        /// </summary>
        public List<XGitFile> files;
        #endregion
    }
}
