using System;

namespace Calculator.Wpf.Common.AppBehaviors
{
    public interface IAppBehavior
    {
        IDisposable Attach();
    }
}
