using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XiaoYi;

namespace XGitSupport
{
    public partial class Form1 : Form
    {
        #region Values
        private List<XGit> _gitLst = null;
        private XGit _curGit;
        private List<XGitVersion> _curGitVersionLst = null;
        private XGitVersion _curGitVer;
        private List<XGitInfo> _curGitInfo = new List<XGitInfo>();
        private List<string> _updateGroup;

        private List<HashFile> hashA;
        private List<HashFile> hashB;
        #endregion

        #region Function
        #region 构造
        public Form1()
        {
            InitializeComponent();

            _gitLst = XFile.ReadLines("./Datas/Url.txt").Select(x => {
                var temp = new XGit();
                temp.SetUrl(x);
                return temp;
            }).ToList();

            if (_gitLst == null)
                _gitLst = new List<XGit>();
            UpdateUrlLst();
        }

        #endregion

        #region Private
        private void AddUrl(string url)
        {
            if (_gitLst.Find(x => x.GetUrl() == url) == null)
            {
                var temp = new XGit();
                temp.SetUrl(url);

                _gitLst.Add(temp);
                XFile.WriteLines("./Datas/Url.txt", _gitLst.Select(x => x.GetUrl()).ToList());
                UpdateUrlLst();
            }
        }
        private void UpdateUrlLst()
        {
            XUI.ItemClear(this, cbxUrl);

            foreach (var url in _gitLst)
                XUI.ItemAdd(this, cbxUrl, url.GetUrl());
        }
        private void UpdateCommitIDLst()
        {
            XUI.ItemClear(this, lbxNetGitVer);
            foreach (var xgit_ver in _curGitVersionLst)
            {
                XUI.ItemAdd(this, lbxNetGitVer, string.Format("{0}|{1}", xgit_ver.hash_code, xgit_ver.bert_version));
            }
        }
        private bool UpdateXGit(string dir, bool ignoreTip = false)
        {
            var filePath = dir + "/info.xgit";
            if (!XFile.Exists(filePath))
            {
                if (!ignoreTip)
                    MessageBox.Show("找不到 info.xgit, 无法继续执行");
                return false;
            }

            var lst = XFile.ReadLines(filePath)[0].YusToObject<List<XGitInfo>>();
            foreach (var xgit in lst)
            {
                var git = _gitLst.Find(x => x.GetUrl() == xgit.url);
                var fileLst = git.GetFileLst(xgit.commit_id);
                var cacheDir = string.Format("{0}/", git.GetCacheDir(xgit.commit_id));

                foreach (var file in xgit.files)
                {
                    var copySrc = string.Format("{0}/{1}", cacheDir, file.git_file);
                    var copyDest = string.Format("{0}/{1}", dir, file.cur_file);

                    XFile.Del(copyDest);
                    XFile.Copy(copySrc, copyDest);
                }
            }
            return true;
        }
        private void SaveToLst(List<HashFile> lst, TextBox tbx)
        {
            var gitFile = tbx.Text + "/info.xgit";
            gitFile = XPath.Format(gitFile);

            if (!XFile.Exists(gitFile))
            {
                MessageBox.Show("找不到 info.xgit, 无法进行信息记录");
                return;
            }

            lst.Clear();

            var fileLst = new List<string>();
            var gitInfos = XFile.ReadLines(gitFile)[0].YusToObject<List<XGitInfo>>();
            foreach (var gitInfo in gitInfos)
            {
                foreach (var gitFileInfo in gitInfo.files)
                {
                    fileLst.Add(XPath.Format(tbx.Text + "/" + gitFileInfo.cur_file));
                }
            }

            foreach (var file in fileLst)
            {
                if (XFile.Exists(file) == false)
                {
                    MessageBox.Show(string.Format("文件 [{0}] 不存在, 无法进行记录", file));
                    return;
                }
            }

            lst.AddRange(fileLst.Select(x => new HashFile() { Path = x, Hash = XFile.GetHash(x) }));
        }
        #endregion

        #region Form response
        private void btnScan_Click(object sender, EventArgs e)
        {
            var git = XGit.FromDir(tbxDirPath.Text);
            if (git != null)
                AddUrl(git.GetUrl());
        }
        private void cbxUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = cbxUrl.SelectedIndex;
            if (idx == -1)
                return;

            _curGit = _gitLst[idx];

            var commitIDLst = _curGit.GetCommitIDLst();
            if (commitIDLst != null)
            {
                _curGitVersionLst = commitIDLst;
                UpdateCommitIDLst();
            }

        }
        private void lbxNetGitVer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lbxNetGitVer.SelectedIndex;
            if (idx != -1)
            {
                _curGitVer = _curGitVersionLst[idx];
                var fileLst = _curGit.GetFileLst(_curGitVer.hash_code);

                XUI.ItemClear(this, lbxFile);
                fileLst.ForEach(x => XUI.ItemAdd(this, lbxFile, x));
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            XUI.AddToSaveList(this, tbxDirPath);
            XUI.AddToSaveList(this, rtbxBranchList);
            XUI.AddToSaveList(this, tbxCmpDir);
            XUI.LoadByList(this);

            _updateGroup = XFile.ReadLines("./Datas/UdpateDirs.txt");
            if (_updateGroup == null)
                _updateGroup = new List<string>();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            _curGitInfo.Clear();
            XUI.SetText(this, richTextBox1, "");
            Clipboard.SetText(" ");
        }
        private void btnUpdateXGitImport_Click(object sender, EventArgs e)
        {
            UpdateXGit(tbxDirPath.Text);
        }
        private void btnUpdateGroupImport_Click(object sender, EventArgs e)
        {
            List<string> delLst = new List<string>();
            foreach (var dir in _updateGroup)
            {
                UpdateXGit(dir, true);
            }

            foreach (var dir in delLst)
            {
                _updateGroup.Remove(dir);
            }

            if (delLst.Count > 0)
                XFile.WriteLines("./Datas/UdpateDirs.txt", _updateGroup);
        }
        private void btnAddToGroup_Click(object sender, EventArgs e)
        {
            var path = textBox2.Text;

            if (!_updateGroup.Contains(path))
            {
                _updateGroup.Add(path);
                XFile.WriteLines("./Datas/UdpateDirs.txt", _updateGroup);
            }
        }
        private void btnShowUnclean_Click(object sender, EventArgs e)
        {
            var exitStr = "&exit";

            XUI.ItemClear(this, lbxUnClean);
            foreach (var dir in _updateGroup)
            {
                var cmd = string.Format("E:&&cd {0}&&git status", dir);
                var ret = XConsole.RunCmdRet(cmd);
                ret = ret.Substring(ret.IndexOf(exitStr) + exitStr.Length + 2);
                if (!isClean(ret))
                {
                    XUI.ItemAdd(this, lbxUnClean, XDirectory.Direcotry(dir) + "|" + dir);
                }
            }
        }
        private bool isClean(string str)
        {
            string pattern = "On branch .+\\nYour branch is up to date with '.+'.\\n\\nnothing to commit, working tree clean\\n";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(str);
            return match.Success;
        }
        private void lbxUnClean_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lbxUnClean.SelectedIndex;
            if (idx == -1)
                return;

            string text = lbxUnClean.Items[idx].ToString();
            var splitLst = text.Split('|');

            XDirectory.Open(splitLst[1]);
            XUI.SetText(this, tbxCmpDir, splitLst[1]);
        }
        private void tbxSaveHashToA_Click(object sender, EventArgs e)
        {
            if (hashA == null)
                hashA = new List<HashFile>();
            SaveToLst(hashA, tbxCmpDir);
        }
        private void tbxSaveHashToB_Click(object sender, EventArgs e)
        {
            if (hashB == null)
                hashB = new List<HashFile>();

            SaveToLst(hashB, tbxCmpDir);
        }
        private void btnCompareLocal_Click(object sender, EventArgs e)
        {
            if (hashA == null || hashB == null)
            {
                MessageBox.Show("有信息为空, 无法比较");
                return;
            }

            List<string> cmpFail = new List<string>();
            for (int i = 0; i < hashA.Count; i++)
            {
                var aTemp = hashA[i];
                var bTemp = hashB.Find(x => x.Path == hashA[i].Path);
                if (bTemp != null)
                {
                    hashA.Remove(aTemp);
                    hashB.Remove(bTemp);
                    i--;

                    if (aTemp.Hash != bTemp.Hash)
                    {
                        cmpFail.Add(XFile.GetName(aTemp.Path, true));
                    }
                }
            }

            if (cmpFail.Count != 0)
            {
                MessageBox.Show(string.Format("以下文件不同：\n    {0}", string.Join(", ", cmpFail)));
            }
            else
            {
                MessageBox.Show("完全 ok");
            }
        }
        private void btnAutoCmp_Click(object sender, EventArgs e)
        {
            tbxSaveHashToA_Click(null, null);
            UpdateXGit(tbxCmpDir.Text);
            tbxSaveHashToB_Click(null, null);
            btnCompareLocal_Click(null, null);
        }
        private void btnParseXGit_Click(object sender, EventArgs e)
        {
            var gitFile = tbxCmpDir.Text + "/info.xgit";
            gitFile = XPath.Format(gitFile);

            if (!XFile.Exists(gitFile))
            {
                MessageBox.Show("找不到 info.xgit, 无法进行操作");
                return;
            }
            var gitInfos = XFile.ReadLines(gitFile)[0].YusToObject<List<XGitInfo>>();
            var branchLst = rtbxBranchList.Text.Split('\n').Select(x=>x.Replace("\r", "")).ToList();

            XUI.ItemClear(this, lbxOldVersion);
            foreach (var info in gitInfos)
            {
                var git = _gitLst.Find(x => x.GetUrl() == info.url);

                List<XGitVersion> commitLst = null;
                foreach(var branch in branchLst)
                {
                    var commitLstTmp = git.GetCommitIDLst(cbxFromServer.Checked, branch);
                    if(commitLstTmp != null)
                    {
                        commitLst = commitLstTmp;
                        break;
                    }
                }
                if(commitLst == null)
                    commitLst = git.GetCommitIDLst(cbxFromServer.Checked);

                if (info.commit_id != commitLst[0].hash_code)
                {
                    XUI.ItemAdd(this, lbxOldVersion, string.Format("{0}|{1}", git.GetName(), git.GetUrl()));
                }
            }
        }
        private void btnUpdateXGit_Click(object sender, EventArgs e)
        {
            var gitFile = tbxCmpDir.Text + "/info.xgit";
            gitFile = XPath.Format(gitFile);

            if (!XFile.Exists(gitFile))
            {
                MessageBox.Show("找不到 info.xgit, 无法进行操作");
                return;
            }
            var gitInfos = XFile.ReadLines(gitFile)[0].YusToObject<List<XGitInfo>>();

            foreach (var item in lbxOldVersion.Items)
            {
                var url = item.ToString().Split('|')[1];
                var info = gitInfos.Find(x => x.url == url);
                var git = _gitLst.Find(x => x.GetUrl() == info.url);

                var commitLstTmp = git.GetCommitIDLst(false);
                info.commit_id = commitLstTmp[0].hash_code;
            }

            XFile.WriteLines(gitFile, gitInfos.YusToJson());
        }
        private void btnCheckInVersion_Click(object sender, EventArgs e)
        {
            List<string> notInVersion = new List<string>();
            foreach (var dir in _updateGroup)
            {
                var text = XConsole.RunCmdRet("E:&&cd {0}&&git log --pretty=oneline", dir);
                text = text.Substring(text.IndexOf("&exit") + 7);
                var splitLst = text.Split('\n');
                var hash = splitLst[0].Substring(0, splitLst[0].IndexOf(' '));

                var verText = splitLst[0];

                var ok = System.Text.RegularExpressions.Regex.IsMatch(verText, "BertVu.+6\\.[0-9]{1,4}\\.[0-9]{1,4}", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                if (!ok)
                {
                    text = XConsole.RunCmdRet("E:&&cd {0}&&git tag", dir);
                    text = text.Substring(text.IndexOf("&exit") + 7);
                    if (text.Length > 0)
                    {
                        splitLst = text.Split('\n').Where(x => x != "").ToArray();
                        var tagName = splitLst.Last();

                        text = XConsole.RunCmdRet("E:&&cd {0}&&git show {1}", dir, tagName);
                        text = text.Substring(text.IndexOf("&exit") + 7);

                        var hash2 = XString.SubStr(text, " ", "\n");

                        ok = hash == hash2;
                    }
                }
                else
                {

                }

                if (!ok)
                {
                    notInVersion.Add(XDirectory.Direcotry(dir));
                }
            }

            if (notInVersion.Count > 0)
            {
                MessageBox.Show(string.Format("以下文件夹不存在版本\r\n{0}", string.Join("\r\n", notInVersion.Select(x => "    " + x))));
            }
        }
        private void btnImportGitFile_Click(object sender, EventArgs e)
        {
            var gitInfo = _curGitInfo.Find(x => x.url == _curGit.GetUrl() && x.commit_id == _curGitVer.hash_code);
            if (gitInfo == null)
            {
                gitInfo = new XGitInfo();
                gitInfo.url = _curGit.GetUrl();
                gitInfo.commit_id = _curGitVer.hash_code;
                gitInfo.files = new List<XGitFile>();
                _curGitInfo.Add(gitInfo);
            }

            XGitFile file = new XGitFile();
            file.git_file = lbxFile.Items[lbxFile.SelectedIndex].ToString();
            file.cur_file = lbxFile.Items[lbxFile.SelectedIndex].ToString();

            var pre = textBox1.Text;
            if (pre != "")
            {
                file.cur_file = pre + file.cur_file;
            }
            gitInfo.files.Add(file);

            var text = _curGitInfo.YusToJson();
            XUI.SetText(this, richTextBox1, text);
            Clipboard.SetText(text);
        }
        #endregion

        #endregion
    }

    class HashFile
    {
        public string Path;
        public string Hash;
    }
}

