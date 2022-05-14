using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XGitSupport
{
    class ThreadRun
    {
        #region delegate
        /// <summary>
        /// 无参事件3
        /// </summary>
        public delegate void NoParaEventHandle();
        /// <summary>
        /// 一个参数的事件
        /// </summary>
        /// <param name="para"></param>
        public delegate void OneParaEventHandle(object para);
        /// <summary>
        /// 完成时的回调
        /// </summary>
        public delegate void CompleteCallbackEventHandle();
        #endregion

        #region Values
        /// <summary>
        /// 日志记录类
        /// </summary>
        private log4net.ILog _log = log4net.LogManager.GetLogger("");
        /// <summary>
        /// 最大线程数
        /// </summary>
        private int _maxThread = 20;
        /// <summary>
        /// 用于判断 ThreadRun 的主线程是否退出
        /// True        已退出
        /// False       仍在运行
        /// </summary>
        private bool _mainThreadRunComplete = false;
        /// <summary>
        /// 线程数量
        /// </summary>
        private SafeInt _threadRunCnt = new SafeInt(0);
        /// <summary>
        /// 一个参数的事件
        /// </summary>
        private OneParaEventHandle _oneParaInvoker;
        /// <summary>
        /// 参数列表
        /// </summary>
        private List<object> _paras;
        /// <summary>
        /// 完成时的回调
        /// </summary>
        private CompleteCallbackEventHandle _completeCallback;
        #endregion

        #region 构造
        public ThreadRun(int maxThread = 20)
        {
            if (maxThread <= 0)
                maxThread = 20;

            _maxThread = maxThread;
        }
        #endregion

        #region Public
        public bool Start(OneParaEventHandle paraEvent, List<object> paras, CompleteCallbackEventHandle completeCallback)
        {
            if (_threadRunCnt.GetVal() != 0)
                return false;

            _oneParaInvoker = paraEvent;
            _completeCallback = completeCallback;
            _paras = paras;

            new Thread(Thread_Start) { IsBackground = true }.Start();
            return true;
        }
        #endregion

        #region Private
        private void Thread_Start()
        {
            _mainThreadRunComplete = false;
            foreach (var para in _paras)
            {

                while (_threadRunCnt.GetVal() >= _maxThread)
                    Thread.Sleep(1);

                //_oneParaInvoker?.Invoke(para);
                new Thread(Thread_OneParaEventRun) { IsBackground = true }.Start(para);
                _threadRunCnt.Add(1);
            }

            _mainThreadRunComplete = true;
            if (_threadRunCnt.GetVal() == 0)
                _completeCallback?.Invoke();
        }

        private void Thread_OneParaEventRun(object para)
        {
            _oneParaInvoker?.Invoke(para);

            if (_threadRunCnt.Add(-1) == 0 && _mainThreadRunComplete)
                _completeCallback?.Invoke();
        }
        #endregion
    }
}
